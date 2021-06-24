using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Last_Stop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> paintingNumbers = Console.ReadLine()
                                              .Split(' ')
                                              .ToList();

            string command;
            string[] commandSplit;
            while (!(command = Console.ReadLine()).Contains("END"))
            {
                commandSplit = command.Split(" ");
                ProgramRun(paintingNumbers, commandSplit);
            }
            Console.WriteLine(string.Join(" ", paintingNumbers));
        }

        private static void ProgramRun(List<string> paintingNumbers, string[] commandSplit)
        {
            if (commandSplit[0] == "Change")
            {
                Change(paintingNumbers, commandSplit);
            }
            else if (commandSplit[0] == "Hide")
            {
                Hide(paintingNumbers, commandSplit);
            }
            else if (commandSplit[0] == "Switch")
            {
                Switch(paintingNumbers, commandSplit);
            }
            else if (commandSplit[0] == "Insert")
            {
                Insert(paintingNumbers, commandSplit);
            }
            else if (commandSplit[0] == "Reverse")
            {
                paintingNumbers.Reverse();
            }
        }

        private static void Insert(List<string> paintingNumbers, string[] commandSplit)
        {
            int num = int.Parse(commandSplit[1]);
            if (paintingNumbers.Count > num)
            {
                paintingNumbers.Insert(num + 1, commandSplit[2]);
            }
        }

        private static void Switch(List<string> paintingNumbers, string[] commandSplit)
        {
            string painting = commandSplit[1];
            string painting2 = commandSplit[2];
            int indexFirstPaintingNumber = paintingNumbers.IndexOf(commandSplit[1]);
            int indexSecondPaintingNumber = paintingNumbers.IndexOf(commandSplit[2]);
            if (paintingNumbers.Contains(painting) && paintingNumbers.Contains(painting2))
            {
                if (indexFirstPaintingNumber > indexSecondPaintingNumber)
                {
                    int temp = indexFirstPaintingNumber;
                    indexFirstPaintingNumber = indexSecondPaintingNumber;
                    indexSecondPaintingNumber = temp;
                    paintingNumbers.RemoveAt(indexFirstPaintingNumber);
                    paintingNumbers.RemoveAt(indexSecondPaintingNumber - 1);
                    paintingNumbers.Insert(indexSecondPaintingNumber - 1, painting2);
                    paintingNumbers.Insert(indexFirstPaintingNumber, painting);
                }
                else
                {
                    int temp = indexFirstPaintingNumber;
                    indexFirstPaintingNumber = indexSecondPaintingNumber;
                    indexSecondPaintingNumber = temp;
                    paintingNumbers.RemoveAt(indexFirstPaintingNumber);
                    paintingNumbers.RemoveAt(indexSecondPaintingNumber);
                    paintingNumbers.Insert(indexSecondPaintingNumber, painting2);
                    paintingNumbers.Insert(indexFirstPaintingNumber, painting);
                }

            }
        }

        private static void Change(List<string> paintingNumbers, string[] commandSplit)
        {
            string painting = commandSplit[1];
            string painting2 = commandSplit[2];
            int indexFirstPaintingNumber = paintingNumbers.IndexOf(commandSplit[1]);
            if (paintingNumbers.Contains(painting))
            {
                paintingNumbers.RemoveAt(indexFirstPaintingNumber);
                paintingNumbers.Insert(indexFirstPaintingNumber, painting2);

            }
        }

        private static void Hide(List<string> paintingNumbers, string[] commandSplit)
        {
            if (paintingNumbers.Contains(commandSplit[1]))
            {
                paintingNumbers.Remove(commandSplit[1]);
            }
        }
    }
}
