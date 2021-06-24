using System;
using System.Linq;
using System.Security.Cryptography;

namespace _8._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            var matrix = new int[sizeMatrix, sizeMatrix];
            //  8 3 2 5
            //  6 4 7 9
            //  9 9 3 6
            //  6 8 1 2
            //   1,2    |   2,1    |     2,0
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            var comInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < comInput.Length; i++)

            {
                var rowColumn = comInput[i].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int firstRow = rowColumn[0];
                int firstCol = rowColumn[1];
                int current = matrix[firstRow, firstCol];
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (firstRow == row && firstCol == col)
                        {
                            if (matrix[firstRow, firstCol] >= 0)
                            {
                                ExplodedBomb(matrix, firstRow, firstCol + 1, current);
                                ExplodedBomb(matrix, firstRow, firstCol - 1, current);
                                ExplodedBomb(matrix, firstRow - 1, firstCol, current);
                                ExplodedBomb(matrix, firstRow - 1, firstCol + 1, current);
                                ExplodedBomb(matrix, firstRow - 1, firstCol - 1, current);
                                ExplodedBomb(matrix, firstRow + 1, firstCol, current);
                                ExplodedBomb(matrix, firstRow + 1, firstCol + 1, current);
                                ExplodedBomb(matrix, firstRow + 1, firstCol - 1, current);
                                matrix[firstRow, firstCol] = 0;
                            }
                        }
                    }
                }

                
            }
            AliveCellsAndSum(matrix); 
            PrintMatrix(matrix);

            //First the bomb with value 7 will explode and reduce the values of the cells around it.
            //Next the bomb with coordinates 2,1 and value 2(initially 9 - 7)
            //will explode and reduce its neighbour cells.
            //In the end the bomb with coordinates 2,0 and value 7(initially 9 - 2) will explode.
            //After that you have to print the count of the alive cells, which is 3,
            //and their sum is 12.Print the matrix after the explosions.;
        }
        public static void AliveCellsAndSum(int[,] matrix)
        {
            var alliveCells = 0;
            var sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var currentNum = matrix[row, col];
                    if (currentNum > 0)
                    {
                        sum += currentNum;
                        alliveCells++;
                    }
                }
            }

            Console.WriteLine($"Alive cells: {alliveCells}");
            Console.WriteLine($"Sum: {sum}");
        }
        public static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
        private static int[,] ExplodedBomb(int[,] matrix, int row, int col, int currentNumber)
        {
            if (CheckIndex(matrix, row, col))
            {
                if (matrix[row, col] > 0)
                {
                    matrix[row, col] -= currentNumber;
                }
            }

            return matrix;
        }

        private static bool CheckIndex(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(1) && col >= 0 && col < matrix.GetLength(1);
        }   
    }
}
