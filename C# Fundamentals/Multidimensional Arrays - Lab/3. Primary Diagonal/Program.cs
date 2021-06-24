using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            int diagonalSum = 0;
            for (int row = 0; row < matrix.GetLength(1); row++)
            {
                diagonalSum += matrix[row, row];
            }
            Console.WriteLine(diagonalSum);
        }
    }
}
