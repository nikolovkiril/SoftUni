using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace P03._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordsPath = "./words.txt";
            string textPath = "./text.txt";
            string actualResultPath = "./actualResult.txt";
            string expectedResultPath = "./expectedResult.txt";
            string[] words = File.ReadAllLines(wordsPath);
            var wordsList = new List<string>(words);
            string text = File.ReadAllText(textPath);
            var textList = new List<string>(text.ToLower().Split(' ','-','.',','));            
            var result = new Dictionary<string, int>();
            
            foreach (var word in textList)
            {
                if (word == wordsList[0])
                {
                    AddWordsToDictionary(result, word);
                }
                else if (word == wordsList[1])
                {
                    AddWordsToDictionary(result, word);
                }
                else if (word == wordsList[2])
                {
                    AddWordsToDictionary(result, word);
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach ((string word, int count) in result)
            {
                sb.AppendLine($"{word} - {count}");
            }
            File.WriteAllText(actualResultPath, sb.ToString());
            result = result.OrderByDescending(x => x.Value).ToDictionary(x => x.Key , y => y.Value);
            StringBuilder sb1 = new StringBuilder();
            foreach ((string word, int count) in result)
            {
                sb1.AppendLine($"{word} - {count}");
            }
            File.WriteAllText(expectedResultPath, sb1.ToString());


        }

        private static void AddWordsToDictionary(Dictionary<string, int> result, string word)
        {
            if (!result.ContainsKey(word))
            {
                result.Add(word, 1);
            }
            else
            {
                result[word]++;
            }
        }
    }
}
