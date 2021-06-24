using System;

namespace _06._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            PrintMiddCharackter(input);
        }

        static void PrintMiddCharackter(string text)
        {
            if (text.Length % 2 == 0)
            {
                char firstSymbol = text[text.Length / 2 - 1];
                char secondSymbol = text[text.Length / 2];
                Console.WriteLine(firstSymbol + "" + secondSymbol);
            }
            else
            {
                char symbol = text[text.Length / 2];
                Console.WriteLine(symbol);
            }
        }
    }
}
