using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var input1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var first = new Queue<int>(input1);
            var input2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var sec = new Stack<int>(input2);
            var loot = new List<int>();

            while (true)
            {
                int firstNum = first.Peek();
                int secNum = sec.Peek();
                if (first.Count != 0 || sec.Count != 0)
                {
                    if ((firstNum + secNum) % 2 == 0)
                    {
                        int addSum = firstNum + secNum;
                        loot.Add(addSum);
                        first.Dequeue();
                        sec.Pop();
                    }
                    else
                    {
                        sec.Pop();
                        first.Enqueue(secNum);
                    }
                }
                if (first.Count == 0 || sec.Count == 0)
                {
                    if (first.Count == 0)
                    {
                        Console.WriteLine("First lootbox is empty");
                    }
                    else
                    {
                        Console.WriteLine("Second lootbox is empty");
                    }
                    break;
                }                
            }
            int lootSum = loot.Sum();
            if (lootSum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {lootSum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {lootSum}");
            }
        }
    }
}
