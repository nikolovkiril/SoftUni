using System;

namespace Vacation
{
    class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            int sameNum = num;
            int sum = 0;

            while (num > 0)
            {
                int factoriel = 1;
                int number = num % 10;
                num /= 10;

                for (int i = 2; i <= number; i++)
                {
                    factoriel *= i;
                }
                sum += factoriel;
            }
            if (sum == sameNum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}