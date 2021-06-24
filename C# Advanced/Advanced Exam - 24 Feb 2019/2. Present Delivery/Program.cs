using System;
using System.Diagnostics;
using System.Linq;

namespace _2._Present_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfPresents = int.Parse(Console.ReadLine());
            int sizeOfmatrix = int.Parse(Console.ReadLine());
            var matrix = new char[sizeOfmatrix, sizeOfmatrix];
            var santaRow = 0;
            var santaCol = 0;
            int happyKids = 0;

            for (int row = 0; row < sizeOfmatrix; row++)
            {
                char[] inputOfMatrix = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int col = 0; col < sizeOfmatrix; col++)
                {
                    matrix[row, col] = inputOfMatrix[col];
                    switch (inputOfMatrix[col])
                    {
                        case 'S':
                            santaRow = row;
                            santaCol = col;
                            break;
                        case 'V':
                            happyKids++;
                            break;
                    }

                }
            }
            string commands;

            while ((commands = Console.ReadLine()) != "Christmas morning" && numOfPresents > 0)
            {
                matrix[santaRow, santaCol] = '-';

                switch (commands)
                {
                    case "up":
                        santaRow--;
                        break;
                    case "down":
                        santaRow++;
                        break;
                    case "left":
                        santaCol--;
                        break;
                    case "right":
                        santaCol++;
                        break;
                }

                if (CheckIfSantaGoesOut(matrix, santaRow, santaCol))
                {
                    Console.WriteLine("Santa ran out of presents.");
                    break;
                }
                if (matrix[santaRow, santaCol] == '-')
                {
                    matrix[santaRow, santaCol] = 'S';
                }
                if (matrix[santaRow, santaCol] == 'X')
                {
                    continue;
                }

                if (matrix[santaRow, santaCol] == 'V')
                {
                    matrix[santaRow, santaCol] = 'S';
                    numOfPresents--;
                    if (numOfPresents == 0)
                    {
                        Console.WriteLine("Santa ran out of presents!");
                        break;
                    }
                }

                if (matrix[santaRow, santaCol] == 'C')
                {
                    matrix[santaRow, santaCol] = 'S';

                    if (matrix[santaRow - 1, santaCol] != '-')//UP
                    {
                        numOfPresents--;
                        matrix[santaRow - 1, santaCol] = '-';
                        if (numOfPresents == 0)
                        {
                            break;
                        }
                    }
                    if (matrix[santaRow + 1, santaCol] != '-')//DOWN
                    {
                        numOfPresents--;
                        matrix[santaRow + 1, santaCol] = '-';
                        if (numOfPresents == 0)
                        {
                            break;
                        }
                    }
                    if (matrix[santaRow, santaCol + 1] != '-')//RIGHT
                    {
                        numOfPresents--;
                        matrix[santaRow, santaCol + 1] = '-';
                        if (numOfPresents == 0)
                        {
                            break;
                        }
                    }
                    if (matrix[santaRow, santaCol - 1] != '-')//LEfT
                    {
                        numOfPresents--;
                        matrix[santaRow, santaCol - 1] = '-';
                        if (numOfPresents == 0)
                        {
                            break;
                        }
                    }
                }
            }

            int goodKidsLeft = 0;
            foreach (var item in matrix)
            {
                if (item == 'V')
                {
                    goodKidsLeft++;
                }
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
            if (goodKidsLeft == 0)
            {
                Console.WriteLine($"Good job, Santa! {happyKids} happy nice kid/s.");
            }
            else
            {
                Console.WriteLine($"No presents for {goodKidsLeft} nice kid/s.");
            }
        }

        private static bool CheckIfSantaGoesOut(char[,] matrix, int santaRow, int santaCol)
        {
            return santaRow < 0 || santaRow >= matrix.GetLength(0) || santaCol < 0 || santaCol >= matrix.GetLength(1);
        }

    }
}
