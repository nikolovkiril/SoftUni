using System;

namespace _01._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstInput = Console.ReadLine();
            string secInput;

            while ((secInput = Console.ReadLine()) != "Generate")
            {
                string[] split = secInput.Split(">>>", StringSplitOptions.RemoveEmptyEntries);
                string command = split[0];
                int count = 0;

                if (command == "Contains")
                {
                    string substring = split[1];
                    if (firstInput.Contains(substring))
                    {
                        Console.WriteLine($"{firstInput} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine($"Substring not found!");
                    }
                }
                else if (command == "Flip")
                {
                    string secCom = split[1];
                    int startIndex = int.Parse(split[2]);
                    int endIndex = int.Parse(split[3]);
                    for (int i = startIndex; i < endIndex; i++)
                    {
                        count++;
                    }
                    if (secCom == "Upper")
                    {
                        string replace = firstInput.Substring(startIndex, count);

                        firstInput = firstInput.Replace(replace,replace.ToUpper());
                        Console.WriteLine(firstInput);

                    }
                    else if (secCom == "Lower")
                    {
                        string replace = firstInput.Substring(startIndex, count);

                        firstInput = firstInput.Replace(replace, replace.ToLower());
                        Console.WriteLine(firstInput);
                    }
                }
                else if (command == "Slice")
                {
                    int startIndex = int.Parse(split[1]);
                    int endIndex = int.Parse(split[2]);
                    for (int i = startIndex; i < endIndex; i++)
                    {
                        count++;
                    }
                    firstInput = firstInput.Remove(startIndex, count);
                    Console.WriteLine(firstInput);
                }
            }
            Console.WriteLine($"Your activation key is: {firstInput}");
        }
    }
}
