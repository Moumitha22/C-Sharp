using System;
using System.IO;

namespace Task_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "input.txt";
            string outputFile = "output.txt";

            try
            {
                string[] lines = File.ReadAllLines(inputFile);
                int linesCount = lines.Length;
                int wordsCount = 0;

                foreach (string line in lines)
                {
                    wordsCount += line.Split(' ', '\t').Length;
                }

                string result = $"Result:\nLines: {linesCount}\nWords: {wordsCount}";
                File.WriteAllText(outputFile, result);

                Console.WriteLine(result);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Input file not found.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"IO Error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unexpected error: {e.Message}");
            }
        }
    }
}
