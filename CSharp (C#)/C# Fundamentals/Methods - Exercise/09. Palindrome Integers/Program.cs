using System;

namespace _09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            while (line != "END")
            {
                Console.WriteLine(IsPalindrome(line).ToString().ToLower());
                line = Console.ReadLine();
            }
        }

        static bool IsPalindrome(string number)
        {
            for (int i = 0; i < number.Length / 2; i++)
            {
                if (number[i] != number[number.Length -1 -i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
