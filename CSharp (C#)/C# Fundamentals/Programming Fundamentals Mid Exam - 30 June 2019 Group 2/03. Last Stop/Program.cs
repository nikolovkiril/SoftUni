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
                if (commandSplit[0] == "Change")
                {
                    if (paintingNumbers.Contains(commandSplit[1]))
                    {
                        int index = paintingNumbers.IndexOf(commandSplit[1]);
                        string newValue = commandSplit[2];
                        //paintingNumbers.Remove(commandSplit[1]);
                        //paintingNumbers.Add(commandSplit[2]);

                        paintingNumbers[index] = newValue;
                    }
                }
                else if (commandSplit[0] == "Hide")
                {
                    if (paintingNumbers.Contains(commandSplit[1]))
                    {
                        paintingNumbers.Remove(commandSplit[1]);
                    }
                }
                else if (commandSplit[0] == "Switch")
                {
                    //string painting = commandSplit[1];
                    //string painting2 = commandSplit[2];
                    int indexFirstPaintingNumber = paintingNumbers.IndexOf(commandSplit[1]);
                    int indexSecondPaintingNumber    = paintingNumbers.IndexOf(commandSplit[2]);
                    //if (paintingNumbers.Contains(painting) && paintingNumbers.Contains(painting2))
                    //TUK PROVERKA ZA INDEX, A NE ZA STOINOST
                    if ((indexFirstPaintingNumber >= 0 && indexFirstPaintingNumber < paintingNumbers.Count) && 
                        (indexSecondPaintingNumber >= 0 && indexSecondPaintingNumber < paintingNumbers.Count))
                    {
                        string temp = paintingNumbers[indexFirstPaintingNumber];
                        paintingNumbers[indexFirstPaintingNumber] = paintingNumbers[indexSecondPaintingNumber];
                        paintingNumbers[indexSecondPaintingNumber] = temp;

                        //indexFirstpaintingNumber = indexSecondpaintingNumber;
                        //indexSecondpaintingNumber = temp;
                        //paintingNumbers.RemoveAt(indexFirstpaintingNumber);
                        //paintingNumbers.RemoveAt(indexSecondpaintingNumber);
                        //paintingNumbers.Insert(indexSecondpaintingNumber, painting);
                        //paintingNumbers.Insert(indexFirstpaintingNumber, painting2);
                    }
                }
                else if (commandSplit[0] == "Insert")
                {
                    int index = int.Parse(commandSplit[1]) + 1;
                    string newNumber = commandSplit[2];
                    if (index >= 0 && index < paintingNumbers.Count)
                    {
                        paintingNumbers.Insert(index, newNumber);
                    }

                    //int num = int.Parse(commandSplit[1]);
                    //if (paintingNumbers.Count > num)
                    //{
                    //    paintingNumbers.Insert(num + 1, commandSplit[2]);
                    //}
                }
                else if (commandSplit[0] == "Reverse")
                {
                    paintingNumbers.Reverse();
                }
            }
            Console.WriteLine(string.Join(" ", paintingNumbers));
        }
    }
}
