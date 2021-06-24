using System;
using System.Collections.Generic;
using System.IO;

namespace _2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "./text.txt";
            string[] lines = File.ReadAllLines(path);

            int count = 1;
            var result = new List<string>();

            foreach (var line in lines)
            {
                int chCount = 0;
                int other = 0;


                foreach (char currChar in line)
                {
                    if (char.IsLetter(currChar))
                    {
                        chCount++;
                    }
                    else if(char.IsPunctuation(currChar))
                    {
                        other++;
                    }
                }
                result.Add($"Line {count++}: {line} ({chCount})({other})");
            }
            File.WriteAllLines("./output.txt", result);
        }
    }
}
