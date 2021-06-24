using System;
using System.Linq;

namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] charSplit = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            string one = charSplit[0];
            string two = charSplit[1];
            int minLen = Math.Min(one.Length, two.Length);
            int maxLen = Math.Max(one.Length, two.Length);

            int sum = 0;

            for (int i = 0; i < minLen; i++)
            {
                sum += one[i] * two[i];
            }
            if (maxLen == one.Length)
            {
                for (int j = minLen; j < maxLen; j++)
                {
                    sum += one[j];
                }
            }
            else
            {
                for (int k = minLen; k < maxLen; k++)
                {
                    sum += two[k];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
