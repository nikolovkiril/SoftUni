using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfInput = int.Parse(Console.ReadLine());
            string regex = @"([@][#]+)(?<word>[A-Z][A-Za-z0-9]{5,})\1";

            for (int i = 0; i < numOfInput; i++)
            {
                string number = "";
                string command = Console.ReadLine();
                Match result = Regex.Match(command, regex);
                string word = result.Groups["word"].Value;
                bool containsInt = word.Any(c => char.IsDigit(c));
                var matches = Regex.Matches(word, @"(\d+)");

                if (result.Success)
                {
                    if (containsInt == true)
                    {
                        foreach (Match match in matches)
                        {
                            number += match.Groups[0].Value;
                        }
                        Console.WriteLine($"Product group: {number}");
                    }                    
                    else
                    {
                        Console.WriteLine($"Product group: 00");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
