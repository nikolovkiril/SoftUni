using System;
using System.Text;

namespace _01.String_Manipulator___Group_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string whiInput;

            while ((whiInput = Console.ReadLine()) != "Done")
            {
                string[] commSplit = whiInput.Split(" ");
                if (commSplit[0] == "Change")
                {
                    input = ReplaceChar(input, commSplit);
                }
                else if (commSplit[0] == "Includes")
                {
                    FIndIfIncludeString(input, commSplit);
                }
                else if (commSplit[0] == "End")
                {
                    FindIfEndsWith(input, commSplit);
                }
                else if (commSplit[0] == "Uppercase")
                {
                    input = input.ToUpper();
                    Console.WriteLine(input);
                }
                else if (commSplit[0] == "FindIndex")
                {
                    FindIndexOf(input, commSplit);
                }
                else if (commSplit[0] == "Cut")
                {
                    input = Cut(input, commSplit);
                }

            }
        }

        private static void FIndIfIncludeString(string input, string[] commSplit)
        {
            string word = commSplit[1];
            if (input.Contains(word))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }

        private static void FindIfEndsWith(string input, string[] commSplit)
        {
            string word = commSplit[1];
            if (input.EndsWith(word))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }

        private static void FindIndexOf(string input, string[] commSplit)
        {
            char findCharIndex = char.Parse(commSplit[1]);
            if (input.Contains(findCharIndex))
            {
                Console.WriteLine(input.IndexOf(findCharIndex));
            }
        }

        private static string Cut(string input, string[] commSplit)
        {
            int startIndex = int.Parse(commSplit[1]);
            int lenght = int.Parse(commSplit[1]);
            //input = input.Remove(startIndex, lenght);

            input = input.Substring(startIndex, lenght);
            Console.WriteLine(input);
            return input;
        }

        private static string ReplaceChar(string input, string[] commSplit)
        {
            char old = char.Parse(commSplit[1]);
            char current = char.Parse(commSplit[2]);
            input = input.Replace(old, current);
            Console.WriteLine(input);
            return input;
        }
    }
}
