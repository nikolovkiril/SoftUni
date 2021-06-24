using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputLength = int.Parse(Console.ReadLine());
            var numbers = new HashSet<int>();
            int count = 0;
            int res = 0;
            for (int i = 0; i < inputLength; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (!numbers.Contains(num))
                {
                    numbers.Add(num);
                }
                else
                {
                    numbers.Remove(num);
                    res = num;
                }
            }
            Console.WriteLine(res);
        }
    }
}
