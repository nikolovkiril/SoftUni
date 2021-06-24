using System;

namespace _01._Nikulden_s_Charity
{
    class Program
    {
        static void Main(string[] args)
        {
            string workInput = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "Finish")
            {
                string[] commSplit = input.Split(" ");
                if (commSplit[0] == "Replace")
                {
                    char currentChar = char.Parse(commSplit[1]);
                    char newChar = char.Parse(commSplit[2]);
                    workInput = workInput.Replace(currentChar, newChar);
                    Console.WriteLine(workInput);
                }
                else if (commSplit[0] == "Cut")
                {
                    int startIndex = int.Parse(commSplit[1]);
                    int endIndex = int.Parse(commSplit[2]);
                    if (startIndex >= 0 && endIndex >= 0 && endIndex <= workInput.Length - 1)
                    {
                        int length = endIndex - startIndex + 1;
                        workInput = workInput.Remove(startIndex, length);
                        Console.WriteLine(workInput);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }
                else if (commSplit[0] == "Make")
                {
                    if (commSplit[1] == "Upper")
                    {
                        workInput = workInput.ToUpper();
                        Console.WriteLine(workInput);
                    }
                    else if (commSplit[1] == "Lower")
                    {
                        workInput = workInput.ToLower();
                        Console.WriteLine(workInput);
                    }
                }
                else if (commSplit[0] == "Check")
                {
                    string temp = commSplit[1];
                    if (workInput.Contains(temp))
                    {
                        Console.WriteLine($"Message contains {temp}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {temp}");
                    }
                }
                else if (commSplit[0] == "Sum")
                {
                    int startIndex = int.Parse(commSplit[1]);
                    int endIndex = int.Parse(commSplit[2]);
                    int sum = 0;
                    if (startIndex >= 0 && endIndex < input.Length)
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            sum += workInput[i];
                        }
                        Console.WriteLine(sum);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid indexes!");
                    }

                }
            }
        }
    }
}
