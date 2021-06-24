using System;
using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfInput = int.Parse(Console.ReadLine());
            string regex = @"@#+(?<name>[A-Z][A-Za-z\d]{4,}[A-Z])@#+";

            for (int i = 0; i < numOfInput; i++)
            {
                string command = Console.ReadLine();
                Match result = Regex.Match(command, regex);
                string regRes = result.Groups["name"].Value;
                string productGroup = "00";
                bool check = false;


                if (result.Success)
                {
                    for (int j = 0; j < regRes.Length; j++)
                    {
                        char currentChar = regRes[j];
                        if (char.IsDigit(currentChar))
                        {
                            if (!check)
                            {
                                productGroup = "";
                            }
                            check = true;
                            productGroup += currentChar;
                        }
                        
                    }
                    Console.WriteLine($"Product group: {productGroup}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
