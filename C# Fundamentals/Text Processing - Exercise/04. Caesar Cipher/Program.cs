using System;

namespace _04._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence = Console.ReadLine();
            string result = "";

            for (int i = 0; i < sentence.Length; i++)
            {

                result += (char)(sentence[i] + 3);
            }
            Console.WriteLine(result);
        }
    }
}