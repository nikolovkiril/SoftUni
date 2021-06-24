using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            var fur = new List<string>();
            double totalPrice = 0;

            while (!(input = Console.ReadLine()).Contains("Purchase"))
            {
                string regex = @">>(?<furniture>[A-Za-z\s]+)<<(?<price>\d+.?\d+?)!(?<quantity>\d+)";
                
                Match result = Regex.Match(input, regex, RegexOptions.IgnoreCase);
                
                if (result.Success)
                {
                    string furniture = result.Groups["furniture"].Value;
                    double price = double.Parse(result.Groups["price"].Value);
                    int quantity = int.Parse(result.Groups["quantity"].Value);
                    fur.Add(furniture);
                    totalPrice += price * quantity;
                }
            }
            Console.WriteLine("Bought furniture:");
            if (fur.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine,fur));
            }
            Console.WriteLine($"Total money spend: {totalPrice:F2}");
        }
    }
}
