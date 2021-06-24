using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stackInput = new Stack<char>();

            foreach (var symbol in input)
            {
                stackInput.Push(symbol);
            }
            while (stackInput.Count != 0)
            {
                Console.Write(stackInput.Pop());
            }

        }
    }
}
