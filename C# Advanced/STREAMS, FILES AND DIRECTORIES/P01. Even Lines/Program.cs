using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Problem_1._Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "./text.txt";
            using StreamReader streamReader = new StreamReader(path);
            int count = 0;
            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                if (line == null)
                {
                    break;
                }
                if (count % 2 == 0)
                {
                    line = line.Replace('-', '@');
                    line = line.Replace('!', '@');
                    line = line.Replace('?', '@');
                    line = line.Replace(',', '@');
                    line = line.Replace('.', '@');
                    line = (string.Join(" ", line.Split(" ").Reverse()));
                    Console.WriteLine(line);
                }
                count++;
            }
        }
    }
}
