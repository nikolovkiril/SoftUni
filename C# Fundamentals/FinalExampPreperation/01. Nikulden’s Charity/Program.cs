    using System;
using System.Text;

namespace _01._Nikulden_s_Charity
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string input = "";
            int sum = 0;


            while (!(input = Console.ReadLine()).Contains("Finish"))
            {
                string[] commSplit = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (commSplit[0] == "Replace" && name.Length > 0)
                {
                    name = Replace(name, commSplit);
                }
                else if (commSplit[0] == "Cut" && name.Length > 0)
                {
                    Cut(name, commSplit);
                }
                else if (commSplit[0] == "Make" && name.Length > 0)
                {
                    name = UpperLower(name, commSplit);
                }
                else if (commSplit[0] == "Check" && name.Length > 0)
                {
                    Check(name, commSplit);
                }
                else if (commSplit[0] == "Sum" && name.Length > 0)
                {
                    sum = Sum(name, input, sum, commSplit);
                }
            }
        }

        private static int Sum(string name, string input, int sum, string[] commSplit)
        {
            int startIndex = int.Parse(commSplit[1]);
            int endIndex = int.Parse(commSplit[2]);

            if (startIndex >= 0 && endIndex < name.Length && startIndex != endIndex)
            {
                string subString = name.Substring(startIndex, endIndex);
                for (int j = 0; j < subString.Length; j++)
                {
                    sum += subString[j];
                }
                Console.WriteLine(sum);
            }
            else
            {
                Console.WriteLine("Invalid indexes!");
            }

            return sum;
        }

        private static void Check(string name, string[] commSplit)
        {
            if (name.Contains(commSplit[1]))
            {
                Console.WriteLine($"Message contains {commSplit[1]}");
            }
            else
            {
                Console.WriteLine($"Message doesn't contain {commSplit[1]}");
            }
        }

        private static string Replace(string name,  string[] commSplit)
        {
            char old = char.Parse(commSplit[1]);
            char newOne = char.Parse(commSplit[2]);

            name = name.Replace(old, newOne);
            Console.WriteLine(name);
            return name;
        }

        private static void Cut(string name, string[] commSplit)
        {
            int startIndex = int.Parse(commSplit[1]);
            int endIndex = int.Parse(commSplit[2]);
            int length = endIndex - startIndex  + 1;
            if (startIndex >= 0 && endIndex >= 0 && endIndex <= name.Length - 1)
            {
                string newName = name.Remove(startIndex, length);
                Console.WriteLine(newName);
            }
            else
            {
                Console.WriteLine("Invalid indexes!");
            }
        }

        private static string UpperLower(string name, string[] commSplit)
        {
            if (commSplit[1] == "Upper")
            {
                name = name.ToUpper();
                Console.WriteLine(name);
            }
            else if (commSplit[1] == "Lower")
            {
                name = name.ToLower();
                Console.WriteLine(name);
            }

            return name;
        }
    }
}
