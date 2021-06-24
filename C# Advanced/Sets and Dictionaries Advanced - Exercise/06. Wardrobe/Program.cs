using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputLenght = int.Parse(Console.ReadLine());
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int count = 1;

            //input format
            // "{color} -> {item1},{item2},{item3}…"
            for (int i = 0; i < inputLenght; i++)
            {
                var input = Console.ReadLine().Split(" -> ");
                string color = input[0];
                string[] clothes = input[1].Split(",");
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }
                foreach (var item in clothes)
                {
                    if (wardrobe[color].ContainsKey(item))
                    {                        
                        wardrobe[color][item]++;
                    }
                    else
                    {
                        wardrobe[color].Add(item, count);
                    }
                }
            }
            var pieceOfClothing = Console.ReadLine().Split();
            string colorToFind = pieceOfClothing[0];
            string clothingToFind = pieceOfClothing[1];
            foreach (var (color,dress) in wardrobe)
            {
                Console.WriteLine($"{color} clothes:");
                foreach (var item in dress)
                {
                    if (color == colorToFind && item.Key == clothingToFind)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }

            //In the end, you will receive a color and a 
            //piece of clothing, which you will look for in the wardrobe, 
            //separated by a space in the following format:
            //"{color} {clothing}"

            //Your task is to print all the items and their count for each color in the following format: 
            //"{color} clothes:
            //* {item1} - {count}

            //If you find the item you are looking for, 
            //you need to print "(found!)" next to it:
            //"* {itemN} - {count} (found!)"

        }
    }
}
