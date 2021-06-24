using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse);
            var stack = new Stack<int>();

            foreach (var num in input)
            {
                stack.Push(num);
            }

            var secInput = Console.ReadLine().ToLower().Split();
            var command = secInput[0];
            while (true)
            {
                command = secInput[0];
                if (command == "add")
                {
                    var num1 = int.Parse(secInput[1]);
                    var num2 = int.Parse(secInput[2]);

                    stack.Push(num1);
                    stack.Push(num2);
                }
                else if (command == "remove")
                {
                    var num = int.Parse(secInput[1]);
                    if (stack.Count > num)
                    {
                        for (int i = 0; i < num; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                else if (command == "end")
                {
                    break;
                }
                secInput = Console.ReadLine().ToLower().Split();
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
