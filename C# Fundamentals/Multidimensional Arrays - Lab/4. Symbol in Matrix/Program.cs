using System;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            char[,] matrix = new char[N, N];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] symbol = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = symbol[col];
                }
            }
            string last = Console.ReadLine();
            bool isFound = false;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col].ToString() == last)
                    {
                        Console.WriteLine($"({row}, {col})");
                        isFound = true;
                        break;
                    }
                }
            }
            if (isFound == false)
            {
                Console.WriteLine($"{last} does not occur in the matrix");
            }

        }
    }
}

