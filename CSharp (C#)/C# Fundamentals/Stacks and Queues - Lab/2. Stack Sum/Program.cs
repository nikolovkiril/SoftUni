using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            var numbers = new Stack<string>(input);
            var command = Console.ReadLine().ToLower().Split();

            var sum = 0;
            while (command[0] != "end")
            {
                if (command[0] == "add")
                {
                    numbers.Push(command[1]);
                    numbers.Push(command[2]);
                }
                else if (command[0] == "remove")
                {
                    var removed = int.Parse(command[1]);
                    if (numbers.Count > removed)
                    {
                        for (int i = 0; i < removed; i++)
                        {
                            numbers.Pop();
                        }
                    }
                    
                }
                command = Console.ReadLine().ToLower().Split();

            }
            foreach (var item in numbers)
           {
                sum += int.Parse(item);
            }
            Console.WriteLine($"Sum: {sum}");
        
        }
    }
}
