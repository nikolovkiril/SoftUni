using System;

namespace String_Manipulator___Group_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string secInput;

            while ((secInput = Console.ReadLine()) != "End")
            {
                string[] commSplit = secInput.Split(" ");
                string comm = commSplit[0];
                if (comm == "Translate")
                {
                    input = ReplaceChar(input, commSplit);
                }
                else if (comm == "Includes")
                {
                    Includes(input, commSplit);
                }
                else if (comm == "Start")
                {
                    StartWith(input, commSplit);
                }
                else if (comm == "Lowercase")
                {
                    input = input.ToLower();
                    Console.WriteLine(input);
                }
                else if (comm == "FindIndex")
                {
                    FindIndex(input, commSplit);
                }
                else if (comm == "Remove")
                {
                    input = RemoveChar(input, commSplit);
                }
            }
        }

        private static string RemoveChar(string input, string[] commSplit)
        {
            int startIndex = int.Parse(commSplit[1]);
            int count = int.Parse(commSplit[2]);
            input = input.Remove(startIndex, count);
            Console.WriteLine(input);
            return input;
        }

        private static void FindIndex(string input, string[] commSplit)
        {
            char findCharIndex = char.Parse(commSplit[1]);
            if (input.Contains(findCharIndex))
            {
                Console.WriteLine(input.LastIndexOf(findCharIndex));
            }
        }

        private static void StartWith(string input, string[] commSplit)
        {
            string word = commSplit[1];
            if (input.StartsWith(word))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }

        private static void Includes(string input, string[] commSplit)
        {
            string check = commSplit[1];
            if (input.Contains(check))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }

        private static string ReplaceChar(string input, string[] commSplit)
        {
            string old = commSplit[1];
            string current = commSplit[2];
            input = input.Replace(old, current);
            Console.WriteLine(input);
            return input;
        }
    }
}
