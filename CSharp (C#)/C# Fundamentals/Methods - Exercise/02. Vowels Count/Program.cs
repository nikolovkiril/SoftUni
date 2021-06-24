using System;

namespace _02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();
            PrintVowels(text);
        }

        static bool IsVowelsNum(char letters)
        {
            return letters == 'a' || letters == 'o' || letters == 'u' || letters == 'e' || letters == 'y' || letters == 'i';
        }

        static void PrintVowels(string text)
        {
            int vowelsCount = 0;
            for (int i = 0; i < text.Length; i++)
            {
                char symbol = text[i];
                if (IsVowelsNum(symbol))
                {
                    vowelsCount++;
                }
            }
            Console.WriteLine(vowelsCount);
        }
    }
}
