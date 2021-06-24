using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CustomStack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ",2);
            var toPush = input[1].Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            var stack = new CustomStack<string>();
            
            while (input[0] != "END")
            {
                switch (input[0])
                {
                    case "Push":
                        stack.Push(toPush);
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();

                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                        }
                        break;
                }
                input[0] = Console.ReadLine();
            }
            for (int i = 0; i < 2; i++)
            {
                foreach (var num in stack)
                {
                    Console.WriteLine(num);
                }
            }
        }
    }
}
