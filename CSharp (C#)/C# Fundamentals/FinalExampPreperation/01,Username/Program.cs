using System;

namespace _01_Username
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string input;

            while (!(input = Console.ReadLine()).Contains("Sign up"))
            {
                string[] commSplit = input.Split(" ");
                //string user = username.Replace(username, username.ToLower()); 

                if (commSplit[0] == "Case")
                {
                    string command = commSplit[1];
                    if (command == "lower")
                    {
                        username = username.Replace(username,username.ToLower());

                        Console.WriteLine(username);
                    }
                    else if (command == "upper")
                    {
                        username = username.Replace(username, username.ToUpper());
                        Console.WriteLine(username);
                    }
                }
                else if (commSplit[0] == "Reverse")
                {
                    int startIndex = int.Parse(commSplit[1]);
                    int endIndex = int.Parse(commSplit[2]);
                    if (startIndex >= 0 &&
                    endIndex > startIndex &&
                    endIndex < username.Length)
                    {
                        string reversed = username.Substring(startIndex, endIndex);
                        Console.WriteLine(ReverseString(reversed));
                    }
                    else
                    {
                        break;
                    }
                }
                else if (commSplit[0] == "Cut")
                {

                    string subString = commSplit[1];
                    if (username.Contains(subString))
                    {
                        username = username.Remove(username.IndexOf(subString), subString.Length);
                        Console.WriteLine(username);
                    }
                    else
                    {
                        Console.WriteLine($"The word {username} doesn't contain {subString}.");
                    }
                }
                else if (commSplit[0] == "Replace")
                {
                    char oldCh =char.Parse(commSplit[1]);
                    username = username.Replace(oldCh, '*');
                    Console.WriteLine(username);
                }
                else if (commSplit[0] == "Check")
                {
                    Check(username, commSplit);
                }
            }

        }

     

        private static void Check(string username, string[] commSplit)
        {
            char temp = char.Parse(commSplit[1]);
            if (username.Contains(temp))
            {
                Console.WriteLine("Valid");
            }
            else
            {
                Console.WriteLine($"Your username must contain {temp}.");
            }
        }

        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

    }
}
