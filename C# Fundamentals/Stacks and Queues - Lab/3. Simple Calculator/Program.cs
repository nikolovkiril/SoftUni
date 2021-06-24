using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var symbols = new Stack<string>(input.Reverse());

            var resul = int.Parse(symbols.Pop());

            while (symbols.Any())
            {
                var nextSym = symbols.Pop();
                if (nextSym == "+")
                {
                    resul += int.Parse(symbols.Pop());
                }
                else if (nextSym == "-")
                {
                    resul -= int.Parse(symbols.Pop());
                }
            }
            Console.WriteLine(resul);
        }
    }
}
