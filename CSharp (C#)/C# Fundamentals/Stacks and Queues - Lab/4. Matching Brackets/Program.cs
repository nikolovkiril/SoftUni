using System;
using System.Collections.Generic;
using System.Linq;


namespace _4._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var arithmetics = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    arithmetics.Push(i);
                }
                else if (input[i] == ')')
                {
                    var last = arithmetics.Pop();
                    Console.WriteLine(input.Substring(last, i - last + 1));
                }
            }
        }
    }
}
