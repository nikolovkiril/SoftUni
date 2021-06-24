using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine().Split();
            int elements = int.Parse(input[0]);
            int toPop = int.Parse(input[1]);
            int look = int.Parse(input[2]);


            var secInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var playStack = new Stack<int>();


            for (int i = 0; i < elements; i++)
            {
                playStack.Push(secInput[i]);
            }
            for (int i = 0; i < toPop; i++)
            {
                playStack.Pop();
            }
            if (playStack.Count() == 0)
            {
                Console.WriteLine("0");
            }
            else if (playStack.Contains(look))
            {
                Console.WriteLine("true");
            }
            else if (!playStack.Contains(look))
            {
                Console.WriteLine(playStack.Min());
            }
        }
    }
}
