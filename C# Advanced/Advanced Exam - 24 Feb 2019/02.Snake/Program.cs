using System;
using System.Diagnostics;
using System.Linq;

namespace _02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];
            var snakeRow = 0;
            var snakeCol = 0;
            int foodEaten = 0;

            for (int row = 0; row < n; row++)
            {
                var inputOfMatrix = Console.ReadLine();
                for (int col = 0; col < inputOfMatrix.Length; col++)
                {
                    matrix[row, col] = inputOfMatrix[col];
                    switch (inputOfMatrix[col])
                    {
                        case 'S':
                            snakeRow = row;
                            snakeCol = col;
                            break;
                        case 'B':

                            break;
                    }

                }
            }
            string commands = Console.ReadLine();

            while (!CheckIfSnakeGoesOut(matrix, snakeRow, snakeCol))
            {

                matrix[snakeRow, snakeCol] = '.';

                switch (commands)
                {
                    case "up":
                        snakeRow--;
                        break;
                    case "down":
                        snakeRow++;
                        break;
                    case "left":
                        snakeCol--;
                        break;
                    case "right":
                        snakeCol++;
                        break;
                }

                if (CheckIfSnakeGoesOut(matrix, snakeRow, snakeCol))
                {
                    Console.WriteLine("Game over!");
                    Console.WriteLine($"Food eaten: {foodEaten}");
                    break;
                }
                if (matrix[snakeRow, snakeCol] == '-')
                {
                    matrix[snakeRow, snakeCol] = '.';
                }
                if (matrix[snakeRow, snakeCol] == '*')
                {
                    matrix[snakeRow, snakeCol] = '.';
                    foodEaten++;
                }

                if (matrix[snakeRow, snakeCol] == 'B')
                {
                    matrix[snakeRow, snakeCol] = '.';
                    for (int r = 0; r < matrix.GetLength(0); r++)
                    {
                        for (int c = 0; c < matrix.GetLength(1); c++)
                        {
                            if (matrix[r, c] == 'B')
                            {
                                matrix[snakeRow, snakeCol] = '.';
                                snakeRow = r;
                                snakeCol = c;
                            }
                        }
                    }
                }
                if (foodEaten >= 10)
                {
                    break;
                }
                commands = Console.ReadLine();
            }
            if (foodEaten >= 10)
            {
                matrix[snakeRow, snakeCol] = 'S';
                Console.WriteLine("You won! You fed the snake.");
                Console.WriteLine($"Food eaten: {foodEaten}");
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }

        }

        private static bool CheckIfSnakeGoesOut(char[,] matrix, int snakeRow, int snakeCol)
        {
            return snakeRow < 0 || snakeRow >= matrix.GetLength(0) || snakeCol < 0 || snakeCol >= matrix.GetLength(1);
        }

    }
}
