using System;
using System.Collections.Generic;

namespace Task_03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> students = new List<string>();

            bool exit = false;

            Console.WriteLine("------------ Student Management ------------");
            while (!exit)
            {
                Console.WriteLine("\nChoose an option :");
                Console.WriteLine("1 -> Add new name to the list.");
                Console.WriteLine("2 -> Remove existing name from the list.");
                Console.WriteLine("3 -> Display the list.");
                Console.WriteLine("4 -> Exit.\n");

                int.TryParse(Console.ReadLine(), out int choice);

                string name = string.Empty;

                switch (choice)
                {
                    case 1:
                        Console.Write("\nEnter a name to add to the list : ");
                        name = Console.ReadLine()?.Trim().ToUpper();
                        if (!string.IsNullOrWhiteSpace(name))
                        {
                            students.Add(name);
                            Console.WriteLine($"{name} was added to the list.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        break;
                        
                    case 2:
                        Console.Write("\nEnter the name to remove from the list : ");
                        name = Console.ReadLine()?.Trim().ToUpper();
                        if (students.Contains(name))
                        {
                            students.Remove(name);
                            Console.WriteLine($"{name} was removed from the list.");
                        }
                        else
                        {
                            Console.WriteLine($"The list doesn't contain the name {name}");
                        }
                        break;

                    case 3:
                        Console.WriteLine("---------- Students ----------");
                        if (students.Count > 0)
                        {
                            foreach (string student in students)
                            {
                                Console.WriteLine(student);
                            }
                        }
                        else
                        {
                            Console.WriteLine("There are no names to display.");
                        }
                        break;

                    case 4:
                        exit = true;
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Enter a valid choice.");
                        break;
                }

            }
        }
    }
}
