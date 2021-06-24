using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int min = int.MinValue;
            int max = int.MaxValue;

            int inputLenght = int.Parse(Console.ReadLine());

            var myStack = new Stack<int>();

            for (int i = 0; i < inputLenght; i++)
            {
                var inputSplit = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var command = inputSplit[0];
                switch (command)
                {
                    case 1:
                        var num = inputSplit[1];
                        myStack.Push(num);
                        break;
                    case 2:
                        if (myStack.Count >= 1)
                        {
                            myStack.Pop();
                        }
                        break;
                    case 3:
                        if (myStack.Count >= 1)
                        {
                            Console.WriteLine(myStack.Max());
                        }
                        break;
                    case 4:
                        if (myStack.Count >= 1)
                        {
                            Console.WriteLine(myStack.Min());
                        }
                        break;
                }
            }

            Console.Write(string.Join(", ", myStack));

        }
    }
}
