using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowSize = int.Parse(Console.ReadLine());
            int[][] jagged = new int[rowSize][];

            for (int row = 0; row < jagged.Length; row++)
            {
                var command = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jagged[row] = command;
            }
            string line;
            while ((line = Console.ReadLine()) != "END")
            {
                string[] lineSplit = line.Split();
                string command = lineSplit[0];
                int row = int.Parse(lineSplit[1]);
                int col = int.Parse(lineSplit[2]);
                int value = int.Parse(lineSplit[3]);
                if (row < 0 || row >= jagged.Length || col < 0 || col >= jagged.Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }
                if (command == "Add")
                {
                    jagged[row][col] += value;
                }
                else if (command == "Subtract")
                {
                    jagged[row][col] -= value;
                }
            }
            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged.Length; col++)
                {
                    Console.Write($"{jagged[row][col]} ");
                }
                Console.WriteLine();

            }
        }
    }
}
