using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();
            Predicate<int> evenOrOdd = n => n % 2 == 0;
            if (command == "odd")
            {
                evenOrOdd = n => n % 2 != 0;
            }

            numbers = GetOddOrEven(numbers, evenOrOdd);
            Console.WriteLine(string.Join(" ",numbers));
        }
        private static List<int> GetOddOrEven(List<int> num, Predicate<int> predicate)
        {
            var result = new List<int>();
            int start = num[0];
            int end = num[1];
            for (int i = start; i <= end; i++)
            {
                if (predicate(i))
                {
                    result.Add(i);
                }
            }
            return result;

        }

    }
}

