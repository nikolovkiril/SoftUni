using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var stack = new Stack<char>();
            
            foreach (var symbol in input) 
            {
                stack.Push(symbol);
            }

            Console.WriteLine(string.Join ("" , stack));

        }
    }
}
