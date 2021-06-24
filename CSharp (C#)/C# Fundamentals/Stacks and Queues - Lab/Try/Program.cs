using System;
using System.Collections.Generic;

namespace Try
{
    class Program
    {
        static void Main(string[] args)
        {
            var asd = new Stack<char>();
            var inp = Console.ReadLine();

            foreach (var symbol in inp)
            {
                asd.Push(symbol);
            }

            while (asd.Count != 0)
            {
                
            }
        }
    }
}
