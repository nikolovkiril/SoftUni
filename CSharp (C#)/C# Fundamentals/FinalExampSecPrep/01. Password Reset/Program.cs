using System;
using System.Linq;

namespace _01._Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstInput = Console.ReadLine();

            string secInput;
            while ((secInput = Console.ReadLine()) != "Done")
            {
                string[] commSplit = secInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string commands = commSplit[0];

                if (commands == "TakeOdd")
                {
                    string result = string.Concat(firstInput.Where((c, i) => i % 2 != 0));
                    firstInput = result;
                    Console.WriteLine(result);
                }
                else if (commands == "Cut")
                {
                    int index = int.Parse(commSplit[1]);
                    int length = int.Parse(commSplit[2]);
                    firstInput = firstInput.Remove(index, length);
                    Console.WriteLine(firstInput);
                }
                else if (commands == "Substitute")
                {
                    string substring = commSplit[1];
                    string substitute = commSplit[2];
                    if (firstInput.Contains(substring))
                    {
                        firstInput = firstInput.Replace(substring, substitute);
                        Console.WriteLine(firstInput);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
            }
            Console.WriteLine($"Your password is: {firstInput}");
        }
    }
}
