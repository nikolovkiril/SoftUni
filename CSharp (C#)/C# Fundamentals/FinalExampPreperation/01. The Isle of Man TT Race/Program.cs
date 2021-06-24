using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _01._The_Isle_of_Man_TT_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"([#$%\*&\.])(?<racer>[A-Za-z]+)\1=(?<Length>[0-9]+)!!(?<geohash>.*?)$";
            StringBuilder final = new StringBuilder();
            while (true)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, regex);

                if (match.Success)
                {
                    string racer = match.Groups["racer"].Value;
                    int length = int.Parse(match.Groups["Length"].Value);
                    string geohash = match.Groups["geohash"].Value;
                    if (length == geohash.Length)
                    {
                        for (int i = 0; i < geohash.Length; i++)
                        {
                            int geohashNum = geohash[i];
                            geohashNum += length;
                            char finalr =(char)geohashNum;
                            final.Append(finalr);
                        }
                        Console.WriteLine($"Coordinates found! {racer} -> {final}");
                        return;

                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                    }
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }
            }
        }
    }
}
