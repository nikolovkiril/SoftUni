using System;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i < num; i++)
            {
                if (IsTopNumber(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool IsTopNumber(int num)
        {
            bool isDivisible = false;
            bool isOddNum = false;
            int temp = num;
            int sum = 0;
            while (temp>0)
            {
                int digit = temp % 10;
                sum += digit; 
                temp /= 10;

                if (digit % 2 != 0)
                {
                    isOddNum = true;
                }

            }
            if (sum % 8 == 0)
            {
                isDivisible = true;
            }
            return isDivisible && isOddNum;
        }
    }
}
