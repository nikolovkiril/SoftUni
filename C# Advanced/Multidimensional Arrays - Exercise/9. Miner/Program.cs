using System;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace _9._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());
            var matrix = new char[sizeMatrix, sizeMatrix];
            var moves = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int coalsCount = 0;
            var minerRow = -1;
            var minerCol = -1;
            var remainingCoals = 0;
            var movesLength = moves.Length;

            for (int row = 0; row < sizeMatrix; row++)
            {
                char[] charMatrix = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < sizeMatrix; col++)
                {
                    matrix[row, col] = charMatrix[col];
                    switch (charMatrix[col])
                    {
                        case 's':
                            minerRow = row;
                            minerCol = col;
                            break;
                        case 'c':
                            remainingCoals++;
                            break;
                    }
                }
            }
            if (movesLength > 0)
            {
                for (int i = 0; i < moves.Length; i++)
                {
                    movesLength--;
                    var current = moves[i];
                    switch (current)
                    {
                        case "up":
                            matrix[minerRow, minerCol] = '*';
                            minerRow--;
                            if (IsValidIndex(matrix, minerRow, minerCol))
                            {
                                coalsCount = CheckForCoals(matrix, coalsCount, minerRow, minerCol);
                                if (remainingCoals == coalsCount)
                                {
                                    PrintIfCollected(minerRow, minerCol);
                                    return;
                                }
                                if (CheckChar(matrix, minerRow, minerCol))
                                {
                                    PrintGameOver(minerRow, minerCol);
                                    return;
                                }
                            }
                            else
                            {
                                minerRow++;
                            }
                            break;
                        case "down":
                            matrix[minerRow, minerCol] = '*';
                            minerRow++;
                            if (IsValidIndex(matrix, minerRow, minerCol))
                            {
                                coalsCount = CheckForCoals(matrix, coalsCount, minerRow, minerCol);
                                if (remainingCoals == coalsCount)
                                {
                                    PrintIfCollected(minerRow, minerCol);
                                    return;
                                }
                                if (CheckChar(matrix, minerRow, minerCol))
                                {
                                    PrintGameOver(minerRow, minerCol);
                                    return;
                                }
                            }
                            else
                            {
                                minerCol--;
                            }
                            break;
                        case "right":
                            matrix[minerRow, minerCol] = '*';
                            minerCol++;
                            if (IsValidIndex(matrix, minerRow, minerCol))
                            {
                                coalsCount = CheckForCoals(matrix, coalsCount, minerRow, minerCol);
                                if (remainingCoals == coalsCount)
                                {
                                    PrintIfCollected(minerRow, minerCol);
                                    return;
                                }
                                if (CheckChar(matrix, minerRow, minerCol))
                                {
                                    PrintGameOver(minerRow, minerCol);
                                    return;
                                }
                            }
                            else
                            {
                                minerCol--;
                            }
                            break;
                        case "left":
                            matrix[minerRow, minerCol] = '*';
                            minerCol--;
                            if (IsValidIndex(matrix, minerRow, minerCol))
                            {
                                coalsCount = CheckForCoals(matrix, coalsCount, minerRow, minerCol);
                                if (remainingCoals == coalsCount)
                                {
                                    PrintIfCollected(minerRow, minerCol);
                                    return;
                                }
                                if (CheckChar(matrix, minerRow, minerCol))
                                {
                                    PrintGameOver(minerRow, minerCol);
                                    return;
                                }
                            }
                            else
                            {
                                minerCol++;
                            }
                            break;
                    }
                }
            }
            if (movesLength == 0)
            {
                var result = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row,col] == 'c')
                        {
                            result++;
                        }
                    }
                }
                Console.WriteLine($"{result} coals left. ({minerRow}, {minerCol})");
            }
        }

        private static void PrintIfCollected(int minerRow, int minerCol)
        {
            Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
        }

        private static int CheckForCoals(char[,] matrix, int coalsCount, int minerRow, int minerCol)
        {
            if (matrix[minerRow, minerCol] != '*')
            {
                if (matrix[minerRow, minerCol] == 'c')
                {
                    matrix[minerRow, minerCol] = '*';
                    coalsCount++;
                }
            }

            return coalsCount;
        }

        private static bool CheckChar(char[,] matrix, int row, int col)
        {
            if (matrix[row, col] == 'e')
            {
                return true;
            }
            return false;
        }
        public static bool IsValidIndex(char[,] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
        public static void PrintGameOver(int row, int col)
        {
            Console.WriteLine($"Game over! ({row}, {col})");
        }
    }
}
