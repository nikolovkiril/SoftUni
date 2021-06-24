using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Wizard_Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cards = Console.ReadLine()
                                     .Split(':')
                                     .ToList();
            List<string> newDeck = new List<string>();
            string cmd;
            string[] commandSplit;
            while (!(cmd = Console.ReadLine()).Contains("Ready"))
            {
                commandSplit = cmd.Split(" ");
                if (commandSplit[0] == "Add")
                {
                    if (cards.Contains(commandSplit[1]))
                    {
                        newDeck.Add(commandSplit[1]);
                    }
                    else
                    {
                        Console.WriteLine("Card not found.");
                    }
                }
                else if (commandSplit[0] == "Insert")
                {
                    int addToIndex = int.Parse(commandSplit[2]);
                    string cardName = commandSplit[1];
                    if (addToIndex < 0 || addToIndex > newDeck.Count || !cards.Contains(cardName))
                    {
                        Console.WriteLine("Error!");
                    }
                    else
                    {
                        newDeck.Insert(addToIndex, commandSplit[1]);
                    }
                }
                else if (commandSplit[0] == "Remove")
                {
                    if (newDeck.Contains(commandSplit[1]))
                    {
                        newDeck.Remove(commandSplit[1]);
                    }
                    else
                    {
                        Console.WriteLine("Card not found.");
                    }
                }
                else if (commandSplit[0] == "Swap")
                {
                    int indexFirstCardNumber = newDeck.IndexOf(commandSplit[1]);
                    int indexSecondCardNumber = newDeck.IndexOf(commandSplit[2]);
                    if ((indexFirstCardNumber >= 0 && indexFirstCardNumber < newDeck.Count) &&
                        (indexSecondCardNumber >= 0 && indexSecondCardNumber < newDeck.Count))
                    {
                        string temp = newDeck[indexFirstCardNumber];
                        newDeck[indexFirstCardNumber] = newDeck[indexSecondCardNumber];
                        newDeck[indexSecondCardNumber] = temp;
                    }
                }
                else if (commandSplit[0] == "Shuffle")
                {
                    newDeck.Reverse();
                }
            }
            Console.WriteLine(string.Join(" ", newDeck));
        }
    }
}
