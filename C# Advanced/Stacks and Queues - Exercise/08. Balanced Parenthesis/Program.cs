using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var listOfChars = new List<char>(input);

            var left = new Stack<char>();
            var right = new Queue<char>();

            char current;
            int secondPart = listOfChars.Count / 2;

            if (listOfChars.Count % 2 == 1)
            {
                Console.WriteLine("NO");
                return;
            }
            for (int i = 0; i < listOfChars.Count/2; i++)
            {
                var currentChar = input[i];
                if (currentChar == '(' || currentChar == '[' || currentChar == '{' || currentChar == ' ' ||
                    currentChar == ')' || currentChar == '}' || currentChar == ']')
                {
                    left.Push(currentChar);
                }                
            }
            for (int i = secondPart; i < listOfChars.Count; i++)
            {
                var currentChar = input[i];
                if (currentChar == '(' || currentChar == '[' || currentChar == '{' || currentChar == ' ' ||
                    currentChar == ')' || currentChar == '}' || currentChar == ']')
                {
                    right.Enqueue(currentChar);
                }
            }
            while (left.Count != 0)
            {
                current = left.Peek();
                char curRight = right.Peek();
                if (current == '(' && curRight == ')' ||
                    current == '[' && curRight == ']' ||
                    current == '{' && curRight == '}' ||
                    current == ' ' && curRight == ' ' ||
                    current == ')' && curRight == '(' || 
                    current == '}' && curRight == '{' ||
                    current == ']' && curRight == '[')
                {
                    left.Pop();
                    right.Dequeue();
                }
                else
                {
                    Console.WriteLine("NO");
                    return;
                }
                if (left.Count == 0)
                {
                    Console.WriteLine("YES");
                }
            }
        }
    }
}
