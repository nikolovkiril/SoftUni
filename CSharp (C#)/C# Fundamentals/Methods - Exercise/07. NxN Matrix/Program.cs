using System;

namespace _07._NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix();
        }

        static void Matrix()
        {
            int num = int.Parse(Console.ReadLine());
            int one = num;
            int[,] numbers = new int[one, one];
            for (int i = 0; i < one; i++)
            {
                for (int j = 0; j < one; j++)
                {
                    numbers[i, j] = num;
                    Console.Write(numbers[i, j] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
