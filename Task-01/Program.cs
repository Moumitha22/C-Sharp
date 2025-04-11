using System;

namespace Task01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a positive number : ");
            // int num = Convert.ToInt32(Console.ReadLine());  // This throws an exception if the input is not a valid integer

            string? input = Console.ReadLine();

            Console.WriteLine("");
            if (int.TryParse(input, out int num) && num >= 0)
            {
                Console.WriteLine($"Factorial of {num} using loop: {FactorialByLoop(num)}");
                Console.WriteLine($"Factorial of {num} using recursion: {FactorialByRecursion(num)}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
            }
        }

        static long FactorialByLoop(int num)
        {
            if (num == 0 || num == 1)
                return 1;

            long fact = 1L;
            for (int i = 1; i <= num; i++)
            {
                fact *= i;
            }
            return fact;
        }

        static long FactorialByRecursion(int num)
        {
            if (num == 0 || num == 1)
            {
                return 1;
            }
            return num * FactorialByRecursion(num - 1);
        }
    }
}
