using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            int secInput = int.Parse(Console.ReadLine());

            if (secInput == 0)
            {
                Console.WriteLine(0);
                return;
            }
            StringBuilder sb = new StringBuilder();
            int reminder = 0;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                char currChar = input[i];
                int currNum = int.Parse(currChar.ToString());
                int result = (currNum * secInput) + reminder;
                sb.Append(result % 10);
                reminder = result / 10;
            }
            if (reminder != 0)
            {
                sb.Append(reminder);
            }

            List<char> resultFinal = sb.ToString().Reverse().ToList();
            removeZero(resultFinal);
            Console.WriteLine(string.Join("", resultFinal));
        }
        private static void removeZero(List<char> resultFinal)
        {
            if (resultFinal[0] == '0')
            {
                int endIndex = 0;
                for (int i = 1; i < resultFinal.Count; i++)
                {
                    if (resultFinal[i] != '0')
                    {
                        endIndex = i;
                    }
                }
                for (int j = 0; j < endIndex; j++)
                {
                    resultFinal.RemoveAt(0);
                }
            }
        }
    }
}

