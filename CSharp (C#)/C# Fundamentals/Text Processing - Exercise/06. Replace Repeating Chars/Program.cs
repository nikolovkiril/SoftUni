using System;

namespace _05._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();


            for (int i = 0; i < input.Length; i++)
            {
                char simbol = input[i];
                int deletChar = 0;
                for (int j = i + 1; j < input.Length; j++)
                {
                    char nextSimbol = input[j];
                    if (simbol == nextSimbol)
                    {
                        deletChar++;
                    }
                    else
                    {
                        break;
                    }
                }
                input = input.Remove(i + 1, deletChar);
            }
            Console.WriteLine(input);
        }
    }
}

