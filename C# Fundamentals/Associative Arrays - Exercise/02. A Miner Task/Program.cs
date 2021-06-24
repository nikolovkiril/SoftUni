using System;
using System.Collections.Generic;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, int> miner = new Dictionary<string, int>();

            string resource;

            while ((resource = Console.ReadLine()) != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());
                if (!miner.ContainsKey(resource))
                {
                    miner[resource] = 0;
                }
                miner[resource]+= quantity;

            }
            foreach (var item in miner)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
