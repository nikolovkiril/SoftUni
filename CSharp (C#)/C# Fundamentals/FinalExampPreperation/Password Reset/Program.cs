using System;
using System.Linq;
using System.Text;

namespace Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputComm = Console.ReadLine();
            string inputSplit = "";
            string result = "";

            while ((inputSplit = Console.ReadLine()) != "Done")
            {
                string[] commSplit = inputSplit.Split(" ");

                if (commSplit[0] == "TakeOdd")
                {
                    result = string.Concat(inputComm.Where((c, i) => i % 2 != 0));
                    Console.WriteLine(result);
                }
                else if (commSplit[0] == "Cut")
                {
                    int index = int.Parse(commSplit[1]);
                    int length = int.Parse(commSplit[2]);
                    result = result.Remove(index, length);
                    Console.WriteLine(result);
                }
                else if (commSplit[0] == "Substitute")
                {
                    string substring = commSplit[1];
                    string substitute = commSplit[2];

                    if (result.Contains(substring))
                    {
                        result = result.Replace(substring, substitute);
                        Console.WriteLine(result);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
            }
            Console.WriteLine($"Your password is: {result}");
        }
    }
}
