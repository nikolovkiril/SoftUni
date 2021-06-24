using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string regex = @"([\:\:]{2}|[\*\*]{2})(?<asd>[A-Z]{1}[a-z]{2,})\1";
            long coolThreshold = 1;
            var emoji = new List<string>();

            MatchCollection result = Regex.Matches(text, regex);

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    char asd = text[i];
                    int rere = int.Parse(asd.ToString());

                    coolThreshold *= rere;
                }
            }
            foreach (Match match in result)
            {
                int sum = 0;
                foreach (char currentCh in match.Groups["asd"].Value)
                {
                    sum += currentCh;
                }
                if (sum >= coolThreshold)
                {
                    emoji.Add(match.Value);
                }
            }
            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{result.Count} emojis found in the text. The cool ones are:");
            if (emoji.Count>0)
            {
                foreach (var emoj in emoji)
                {
                    Console.WriteLine(emoj);
                }
            }
        }
    }
}
