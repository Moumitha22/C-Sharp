using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_04
{
    class Student
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public int Grade { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student { Name = "Yash", Age = 22, Grade = 88 },
                new Student { Name = "Dia", Age = 20, Grade = 88 },
                new Student { Name = "Dhruv", Age = 21, Grade = 72 },
                new Student { Name = "Thara", Age = 22, Grade = 95 },
                new Student { Name = "Kushi", Age = 19, Grade = 66 },
                new Student { Name = "Nila", Age = 20, Grade = 88 },
                new Student { Name = "Ashwin", Age = 23, Grade = 91 },
                new Student { Name = "Meera", Age = 21, Grade = 77 },
                new Student { Name = "Kalki", Age = 24, Grade = 60 },
                new Student { Name = "Abhi", Age = 20, Grade = 93 }
            };

            Console.WriteLine($"Students List :\n"); 
            Console.WriteLine($"\n{"Name",-10} {"Age",-5} {"Grade",-6}");
            Console.WriteLine(new string('-', 25));

            foreach (Student student in students)
            {
                Console.WriteLine($"{student.Name,-10} {student.Age,-5} {student.Grade,-6}");
            }

            Console.Write("\nEnter grade threshold: ");
            if (!int.TryParse(Console.ReadLine(), out int threshold))
            {
                Console.WriteLine("Invalid input. Exiting...");
                return;
            }

            List<Student> filteredStudents = students
                .Where(s => s.Grade > threshold)
                .OrderByDescending(s => s.Grade).ThenBy(s => s.Name).ToList();

            Console.WriteLine($"\nStudents with grades above {threshold} :\n");
            Console.WriteLine($"\n{"Name",-10} {"Age",-5} {"Grade",-6}");
            Console.WriteLine(new string('-', 25)); 

            foreach (Student student in filteredStudents)
            {
                Console.WriteLine($"{student.Name,-10} {student.Age,-5} {student.Grade,-6}");
            }

        }
    }
}
