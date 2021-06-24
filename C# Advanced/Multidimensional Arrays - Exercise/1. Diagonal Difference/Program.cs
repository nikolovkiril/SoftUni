using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that finds the difference between the sums of the square matrix diagonals (absolute value).
            //    ⦁	On the first line, you are given the integer N – the size of the square matrix
            int size = int.Parse(Console.ReadLine());
            int rows = size;
            int columns = size;
            var matrix = new int[rows, columns];
            //    ⦁	The next N lines holds the values for every row – N numbers separated by a space
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            int sum = 0;
            int secondSum = 0;

            for (int row = 0; row < size; row++)
            {
                sum += matrix[row,row];
            }

            //Secondary diagonal:

            for (int row = 0, col = size - 1; row < size; row++, col--)
            {
                secondSum += matrix[row,col];
            }
           
            Console.WriteLine(Math.Abs(sum - secondSum));

            //⦁	Print the absolute difference between the sums of the primary and the secondary diagonal

            //              Primary diagonal: sum = 11 + 5 + (-12) = 4
            //              Secondary diagonal: sum = 4 + 5 + 10 = 19
            //              Difference: | 4 - 19 | = 15
            //3
            //11 2 4
            //4 5 6
            //10 8 - 12
        }
    }
}
