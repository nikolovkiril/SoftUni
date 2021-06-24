using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();
            var inputLength = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputLength; i++)
            {
                string[] differentClothes = Console.ReadLine().Split(" -> ");
                string color = differentClothes[0];
                string[] dress = differentClothes[1].Split(",");
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }
                foreach (var item in dress)
                {
                    Check_Add_Item_And_Quantity(wardrobe, color, item);
                }
            }
            string[] find = Console.ReadLine().Split();
            string findColor = find[0];
            string finddress = find[1];
            foreach (var (color , dress) in wardrobe)
            {
                Console.WriteLine($"{color} clothes:");
                foreach (var item in dress)
                {
                    if (color == findColor && item.Key == finddress)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
        
        private static void Check_Add_Item_And_Quantity(Dictionary<string, Dictionary<string, int>> wardrobe, string color, string item)
        {
            if (!wardrobe[color].ContainsKey(item))
            {
                wardrobe[color].Add(item, 0);

            }
            if (wardrobe[color].ContainsKey(item))
            {
                wardrobe[color][item]++;
            }
        }
    }
}