using System;
using System.Text.RegularExpressions;

namespace _02._Registration
{
    class Program
    {
        static void Main(string[] args)
        {
            int commNum = int.Parse(Console.ReadLine());
            int count = 0;

            for (int i = 0; i < commNum; i++)
            {
                string comm = Console.ReadLine();
                string regex = @"[U][$](?<username>[A-Z][a-z]{2,})[U][$][P][@][$](?<pass>[A-Za-z]{5,}[0-9]+)[P][@][$]";
                Match result = Regex.Match(comm, regex);
                string userName = result.Groups["username"].Value;
                string passw = result.Groups["pass"].Value;

                if (result.Success)
                {
                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: {userName}, Password: {passw}");
                    count++;
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
                    
            }
            Console.WriteLine($"Successful registrations: {count}");
        }
    }
}
