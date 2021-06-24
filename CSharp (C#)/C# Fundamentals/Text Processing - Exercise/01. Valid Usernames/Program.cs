using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] userNames = Console.ReadLine().Split(", ", StringSplitOptions.None).ToArray();

            foreach (var user in userNames)
            {
                if (ValidUsers(user))
                {
                    Console.WriteLine(user);

                }
            }
        }
        private static bool ValidUsers(string username)
        {
            if ((username.Length < 3 || username.Length > 16))
            {
                return false;
            }
            bool isValid = true;
            for (int i = 0; i < username.Length; i++)
            {
                char currChar = username[i];
                if (!(char.IsLetterOrDigit(currChar) || currChar == '-' || currChar == '_'))
                {
                    isValid = false;
                    break;
                }
            }
            return isValid;
        }
    }
}
