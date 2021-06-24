using System;
using System.Linq;

namespace _01._Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string instructions;
            
            while ((instructions = Console.ReadLine()) != "Reveal")
            {
                string[] split = instructions.Split(":|:").ToArray();
                string firstComm = split[0];

                if (firstComm == "InsertSpace")
                {
                    int index = int.Parse(split[1]);
                    string toInsert = " ";
                    if (message.Length > index)
                    {
                        message = message.Insert(index, toInsert);
                        Console.WriteLine(message);
                    }
                    
                }
                else if (firstComm == "Reverse")
                {
                    string substring = split[1];
                    char[] charArray = substring.ToCharArray();
                    Array.Reverse(charArray);
                    string substring1 = string.Empty;
                    for (int i = 0; i < charArray.Length; i++)
                    {
                        substring1 += charArray[i];
                    }

                    if (message.Contains(substring))
                    {
                        int index = message.IndexOf(substring);

                        message = message.Remove(index,substring.Length);
                        message = message.Insert(index, substring1);
                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (firstComm == "ChangeAll")
                {
                    string substring = split[1];
                    string replacement = split[2];
                    message = message.Replace(substring, replacement);
                    Console.WriteLine(message);
                }

            }
            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}