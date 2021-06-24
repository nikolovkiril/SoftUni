using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var symbols = new Stack<string>(input.Reverse());

            var result = int.Parse(symbols.Pop());

            while (symbols.Any())
            {
                var nextSymbol = symbols.Pop();
                if (nextSymbol == "+")
                {
                    var num = int.Parse(symbols.Pop());
                    result += num;
                }
                else if (nextSymbol == "-")
                {
                    var num = int.Parse(symbols.Pop());
                    result -= num;
                }
            }
            Console.WriteLine(result);
        }
    }
}
