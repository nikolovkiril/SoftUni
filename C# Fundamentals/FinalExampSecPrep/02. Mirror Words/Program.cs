using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Regex regex = new Regex(@"([@]|[#])(?<word>[A-Za-z]{3,})(?<mid>[@]{2}|[#]{2})(?<word2>[A-Za-z]{3,})\1");

            MatchCollection matches = regex.Matches(text);

            List<string> mirrorWords = new List<string>();

            if (matches.Count > 0)
            {
                foreach (Match word in matches)
                {
                    string word1 = word.Groups["word"].Value;
                    string word2 = word.Groups["word2"].Value;

                    char[] print = word2.ToCharArray();
                    Array.Reverse(print);

                    string wordRev = new string(print);

                    if (word1 == wordRev)
                    {
                        mirrorWords.Add(word1);
                        mirrorWords.Add(word2);
                    }
                }
                Console.WriteLine($"{matches.Count} word pairs found!");
            }
            else
            {
                Console.WriteLine("No word pairs found!");
            }

            if (mirrorWords.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {

                Console.WriteLine("The mirror words are:");

                List<string> print = new List<string>();

                for (int i = 0; i < mirrorWords.Count; i += 2)
                {
                    print.Add($"{mirrorWords[i]} <=> {mirrorWords[i + 1]}");

                }
                Console.WriteLine(string.Join(", ", print));

            }
        }
    }
}