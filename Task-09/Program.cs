using System;
using System.Reflection;

// Define custom attribute 
[AttributeUsage(AttributeTargets.Method)]
public class RunnableAttribute : Attribute { }

public class ClassA
{
    public ClassA()
    {
        Console.WriteLine("ClassA Constructor executed.");
    }

    [Runnable]
    public void RunnableMethod()
    {
        Console.WriteLine("ClassA: [Runnable] method executed.");
    }

    public void NonRunnableMethod()
    {
        Console.WriteLine("ClassA: Non-runnable method (not marked with attribute).");
    }
}
public class ClassB
{
    public ClassB()
    {
        Console.WriteLine("\nClassB Constructor executed.");
    }

    [Runnable]
    public void RunnableMethod()
    {
        Console.WriteLine("ClassB: [Runnable] method executed.");
    }

    public void NonRunnableMethod()
    {
        Console.WriteLine("ClassB: Non-runnable method (not marked with attribute).");
    }
}

public class Program
{
    public static void Main()
    {
        // Get the current executing assembly (your project’s compiled code)
        Assembly assembly = Assembly.GetExecutingAssembly();

        // Loop through all types (classes) in the assembly
        foreach (Type type in assembly.GetTypes())
        {
            // Skip non-class or abstract types
            if (!type.IsClass || type.IsAbstract)
                continue;

            // Get all public instance methods declared in this class with the [Runnable] attribute
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                      .Where(m => m.GetCustomAttribute<RunnableAttribute>() != null);

            // If any methods with [Runnable] are found, create an instance and invoke them
            if (methods.Any())
            {
                // Create an instance of the class
                object? instance = Activator.CreateInstance(type);

                foreach (MethodInfo method in methods)
                {
                    Console.WriteLine($"=> Executing method: {type.Name}.{method.Name}()");
                    // Dynamically invoke the method
                    method.Invoke(instance, null);
                }
            }
        }
    }
}