using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._School_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shelsWithBooks = Console.ReadLine()
                                     .Split('&')
                                     .ToList();
            string command;
            string[] commandSplit;

            while (!(command = Console.ReadLine()).Contains("Done"))
            {
                commandSplit = command.Split(" | ");
                if (commandSplit[0] == "Add Book")
                {
                    if (shelsWithBooks.Contains(commandSplit[1]))
                    {
                        break;
                    }
                    shelsWithBooks.Insert(0, commandSplit[1]);
                }
                else if (commandSplit[0] == "Take Book")
                {
                    if (shelsWithBooks.Contains(commandSplit[1]))
                    {
                        shelsWithBooks.Remove(commandSplit[1]);
                    }
                    else
                    {
                        break;
                    }
                }
                else if (commandSplit[0] == "Swap Books")
                {
                    string book1 = commandSplit[1];
                    string book2 = commandSplit[2];
                    int indexFirstBook = shelsWithBooks.IndexOf(commandSplit[1]);
                    int indexSecondBook = shelsWithBooks.IndexOf(commandSplit[2]);
                    if (shelsWithBooks.Contains(book1) && shelsWithBooks.Contains(book2))
                    {
                        int temp = indexFirstBook;
                        indexFirstBook = indexSecondBook;
                        indexSecondBook = temp;
                        shelsWithBooks.RemoveAt(indexFirstBook);
                        shelsWithBooks.RemoveAt(indexSecondBook);
                        shelsWithBooks.Insert(indexSecondBook, book2);
                        shelsWithBooks.Insert(indexFirstBook, book1);
                    }
                    else
                    {
                        break;
                    }
                }
                else if (commandSplit[0] == "Insert Book")
                {
                    shelsWithBooks.Add(commandSplit[1]);
                }
                else if (commandSplit[0] == "Check Book")
                {
                    int temp = int.Parse(commandSplit[1]);
                    int checkIndex = shelsWithBooks.IndexOf(commandSplit[1]);

                    if (shelsWithBooks.Count < temp)
                    {
                        break;
                    }

                    Console.WriteLine(shelsWithBooks[temp]);
                    
                }
            }
            Console.WriteLine(string.Join(", ", shelsWithBooks));
        }
    }
}
