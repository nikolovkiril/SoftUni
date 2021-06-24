using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = input[0];
            var cols = input[1];
            var matrix = new string[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var numbers = Console.ReadLine().Split().ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }
            string commad;
            while ((commad = Console.ReadLine()) != "END")
            {
                var splitCommand = commad.Split();
                string toDo = splitCommand[0];
                if (splitCommand.Length == 5)
                {
                    int row1 = int.Parse(splitCommand[1]);
                    int col1 = int.Parse(splitCommand[2]);
                    int row2 = int.Parse(splitCommand[3]);
                    int col2 = int.Parse(splitCommand[4]);
                    if (rows > row1 && cols > col1 && rows > row2 && cols > col2)
                    {
                        if (toDo == "swap")
                        {
                            string temp1, temp2;
                            temp2 = matrix[row1, col1];
                            matrix[row1, col1] = matrix[row2, col2];
                            matrix[row2, col2] = temp2;
                            for (int row = 0; row < matrix.GetLength(0); row++)
                            {
                                for (int col = 0; col < matrix.GetLength(1); col++)
                                {
                                    Console.Write(matrix[row, col] + " ");
                                }
                                Console.WriteLine();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
