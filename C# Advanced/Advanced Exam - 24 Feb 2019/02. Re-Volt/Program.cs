using System;
using System.Security.Cryptography;
using System.Threading.Tasks.Sources;

namespace _02._Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int commands = int.Parse(Console.ReadLine());
            var matrix = new char[matrixSize, matrixSize];
            var playerPosition = new int[2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string symbol = Console.ReadLine();
                for (int col = 0; col < symbol.Length; col++)
                {
                    char cur = symbol[col];
                    matrix[row, col] = cur;
                    switch (symbol[col])
                    {
                        case 'f':
                            playerPosition[0] = row;
                            playerPosition[1] = col;

                            break;
                    }
                }
            }
            for (int i = 0; i < commands; i++)
            {
                string command = Console.ReadLine();
                playerPosition = PlayerMove(matrix, playerPosition, command);
                if (matrix[playerPosition[0], playerPosition[1]] == '-')
                {
                    matrix[playerPosition[0], playerPosition[1]] = 'f';
                }
                else if (matrix[playerPosition[0], playerPosition[1]] == 'B')
                {
                    playerPosition = PlayerMove(matrix, playerPosition, command);
                    matrix[playerPosition[0], playerPosition[1]] = 'f';
                }
                else if (matrix[playerPosition[0], playerPosition[1]] == 'T')
                {
                    playerPosition = PlayerMove(matrix, playerPosition, command);
                }
                if (matrix[playerPosition[0], playerPosition[1]] == 'F')
                {
                    matrix[playerPosition[0], playerPosition[1]] = 'f';
                    Console.WriteLine("Player won!");
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            Console.Write(matrix[row, col]);
                        }
                        Console.WriteLine();
                    }
                    return;
                }
            }
            Console.WriteLine("Player lost!");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
        private static int[] PlayerMove(char[,] matrix, int[] playerPosition, string command)
        {
            switch (command)
            {
                case "up":
                    if (matrix[playerPosition[0], playerPosition[1]] != 'B' &&
                        matrix[playerPosition[0], playerPosition[1]] != 'T')
                    {
                        matrix[playerPosition[0], playerPosition[1]] = '-';
                    }
                    if (matrix[playerPosition[0], playerPosition[1]] == 'T')
                    {
                        playerPosition[0]++;
                        break;
                    }
                    playerPosition[0]--;
                    break;
                case "down":
                    if (matrix[playerPosition[0], playerPosition[1]] != 'B' &&
                        matrix[playerPosition[0], playerPosition[1]] != 'T')
                    {
                        matrix[playerPosition[0], playerPosition[1]] = '-';
                    }
                    if (matrix[playerPosition[0], playerPosition[1]] == 'T')
                    {
                        playerPosition[0]--;
                        break;
                    }
                    playerPosition[0]++;
                    break;
                case "left":
                    if (matrix[playerPosition[0], playerPosition[1]] != 'B' &&
                        matrix[playerPosition[0], playerPosition[1]] != 'T')
                    {
                        matrix[playerPosition[0], playerPosition[1]] = '-';
                    }
                    if (matrix[playerPosition[0], playerPosition[1]] == 'T')
                    {
                        playerPosition[1]++;
                        break;
                    }
                    playerPosition[1]--;
                    break;
                case "right":
                    if (matrix[playerPosition[0], playerPosition[1]] != 'B' &&
                        matrix[playerPosition[0], playerPosition[1]] != 'T')
                    {
                        matrix[playerPosition[0], playerPosition[1]] = '-';
                    }
                    if (matrix[playerPosition[0], playerPosition[1]] == 'T')
                    {
                        playerPosition[1]--;
                        break;
                    }
                    playerPosition[1]++;
                    break;

            }

            if (playerPosition[0] == -1)
            {
                playerPosition[0] = matrix.GetLength(0) - 1;
            }
            else if (playerPosition[0] == matrix.GetLength(0))
            {
                playerPosition[0] = 0;
            }

            if (playerPosition[1] == -1)
            {
                playerPosition[1] = matrix.GetLength(0) - 1;
            }
            else if (playerPosition[1] == matrix.GetLength(0))
            {
                playerPosition[1] = 0;
            }

            return playerPosition;
        }
    }
}
