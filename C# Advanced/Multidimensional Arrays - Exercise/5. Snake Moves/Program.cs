using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = input[0];
            var cols = input[1];
            var matrix = new char[rows, cols];

            string snake = Console.ReadLine();

            var queue = new Queue<char>();
            int capacity = rows * cols;
            int count = 0;

            for (int i = 0; i < snake.Length; i++)
            {
                queue.Enqueue(snake[i]);
                count++;
                if (count == capacity)
                {
                    break;
                }
                if (i == snake.Length - 1)
                {
                    i  = -1;
                }
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = queue.Dequeue();
                    }
                }
                if (row % 2 != 0)
                {
                    for (int col = cols - 1; col > -1; col--)
                    {
                        matrix[row, col] = queue.Dequeue();
                    }
                }

            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0}", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
