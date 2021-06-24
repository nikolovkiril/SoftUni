using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputLenght = int.Parse(Console.ReadLine());
            var numbers = new HashSet<int>();
            var appears = 0;
            for (int i = 0; i < inputLenght; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (!numbers.Contains(num))
                {
                    numbers.Add(num);
                }
                else
                {
                    numbers.Remove(num);
                    appears = num;
                }
            }            
            Console.WriteLine(appears);
        }
    }
}
