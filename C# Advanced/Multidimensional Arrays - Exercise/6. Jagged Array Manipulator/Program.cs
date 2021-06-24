using System;
using System.Linq;


namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            double[][] juggedArray = new double[numberOfRows][];

            for (int row = 0; row < juggedArray.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split().Select(double.Parse).ToArray();
                juggedArray[row] = input;
            }
            //After populating the matrix, start analyzing it. 
            //If a row and the one below it have equal length, multiply each element in both of them by 2,
            //otherwise - divide by 2.

            for (int row = 0; row < juggedArray.Length - 1; row++)
            {
                if (juggedArray[row].Count() == juggedArray[row + 1].Count())
                {
                    juggedArray[row] = juggedArray[row].Select(x => x * 2).ToArray();
                    juggedArray[row + 1] = juggedArray[row + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    juggedArray[row] = juggedArray[row].Select(x => x / 2).ToArray();
                    juggedArray[row + 1] = juggedArray[row + 1].Select(x => x / 2).ToArray();
                }
            }

            string commands;
            while ((commands = Console.ReadLine()) != "End")
            {
                var commandsSplit = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = commandsSplit[0];
                int row = int.Parse(commandsSplit[1]);
                int column = int.Parse(commandsSplit[2]);
                int value = int.Parse(commandsSplit[3]);
                if (!IsValidIndexes(juggedArray, row, column))
                {
                    continue;
                }

                if (command == "Add")
                {
                    juggedArray[row][column] += value;
                }
                else if (command == "Subtract")
                {
                    juggedArray[row][column] -= value;
                }
            }
            foreach (double[] row in juggedArray)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
        private static bool IsValidIndexes(double[][] juggedArray, int row, int column)
        {
            if (row >= 0 && row < juggedArray.Length)
            {
                if (column >= 0 && column < juggedArray[row].Length)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
