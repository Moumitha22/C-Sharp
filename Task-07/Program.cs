using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        List<Student> students = new List<Student>
        {
            new Student { Name = "Aarav", RollNo = "SKCET101" },
            new Student { Name = "Meera", RollNo = "SKCET102" },
            new Student { Name = "Kalki", RollNo = "SKCET103" }
        };

        List<Task<string>> tasks = new List<Task<string>>();

        foreach (var student in students)
        {
            tasks.Add(GenerateMarksheet(student));// Start Asynchronous task to generate mark sheet for each student
        }

        try
        {
            // Await all mark sheet generation tasks to complete and gather the results once all tasks are done
            string[] results = await Task.WhenAll(tasks);
            Console.WriteLine("\nAll Mark Sheets Generated:\n");
            foreach (var res in results)
            {
                Console.WriteLine(res);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    // Asynchronous method to simulate generating a mark sheet for a student
    static async Task<string> GenerateMarksheet(Student s)
    {
        Console.WriteLine($"Generating mark sheet for {s.Name} ({s.RollNo})...");
        await Task.Delay(2000); // Simulate processing delay to mimic API processing

        int math = new Random().Next(60, 100);
        int science = new Random().Next(60, 100);
        int english = new Random().Next(60, 100);
        int total = math + science + english;
        double percentage = total / 3.0;

        return $"{s.Name} - Roll No: {s.RollNo} | Math: {math}, Science: {science}, English: {english} | Total: {total} | Percentage: {percentage:F2}%";
    }
}

class Student
{
    public string Name { get; set; }
    public string RollNo { get; set; }
}
