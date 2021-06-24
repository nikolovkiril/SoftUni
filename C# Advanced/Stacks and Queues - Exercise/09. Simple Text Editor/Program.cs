using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {

            var stackOfText = new Stack<string>();

            string empty = string.Empty;

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                switch (input[0])
                {
                    case "1":
                        stackOfText.Push(empty);
                        empty += input[1];
                        break;
                    case "2":
                        int index = int.Parse(input[1]);
                        stackOfText.Push(empty);
                        empty = empty.Substring(0, empty.Length - index);
                        break;
                    case "3":
                        index = int.Parse(input[1]);
                        Console.WriteLine(empty[index - 1]);
                        break;
                    case "4":
                        empty = stackOfText.Pop();
                        break;
                }
            }

        }
    }
}
