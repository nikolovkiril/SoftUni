using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var userNames = new HashSet<string>();
            int inputLenght = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputLenght; i++)
            {
                string command = Console.ReadLine();
                if (!userNames.Contains(command))
                {
                    userNames.Add(command);
                }
            }
            foreach (var user in userNames)
            {
                Console.WriteLine(user);
            }
        }
    }
}
