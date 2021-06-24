using System;
using System.Linq;

namespace _03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] inputSplit = input.Split('\\',StringSplitOptions.RemoveEmptyEntries).ToArray();

            string fileInfo = inputSplit.Last();
            string[] lastFile = fileInfo.Split('.');

            Console.WriteLine($"File name: {lastFile[0]}");
            Console.WriteLine($"File extension: {lastFile[1]}");
        }
    }
}
