using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            List<int> deviders = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Distinct()
                .ToList();
            List<int> numbers = new List<int>();
            for (int i = 1; i <= length; i++)
            {
                if (GetDevidetNum(i, deviders))
                {
                    numbers.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static bool GetDevidetNum(int n, List<int> deviders)
        {
            bool isTrue = true;
            foreach (int divaider in deviders)
            {
                if (n % divaider != 0)
                {
                    isTrue = false;
                }
            }
            return isTrue;
        }
    }
}

