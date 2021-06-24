using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            var input1 = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var input2 = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var resultBombs = new Dictionary<string, int>();
            int DaturaBombs = 40;
            int CherryBombs = 60;
            int SmokeDecoyBombs = 120;

            var effects = new Queue<int>(input1);
            var casings = new Stack<int>(input2);

            while (effects.Count != 0 && casings.Count != 0)
            {
                var effectBomb = effects.Peek();
                var casingBomb = casings.Peek();
                var sum = casingBomb + effectBomb;

                if (sum == DaturaBombs)
                {
                    effects.Dequeue();
                    casings.Pop();
                    if (!resultBombs.ContainsKey("Datura Bombs"))
                    {
                        resultBombs.Add("Datura Bombs", 1);
                    }
                    else
                    {
                        resultBombs["Datura Bombs"]++;
                    }
                }
                if (sum == CherryBombs)
                {
                    effects.Dequeue();
                    casings.Pop();
                    if (!resultBombs.ContainsKey("Cherry Bombs"))
                    {
                        resultBombs.Add("Cherry Bombs", 1);
                    }
                    else
                    {
                        resultBombs["Cherry Bombs"]++;
                    }

                }
                if (sum == SmokeDecoyBombs)
                {
                    effects.Dequeue();
                    casings.Pop();
                    if (!resultBombs.ContainsKey("Smoke Decoy Bombs"))
                    {
                        resultBombs.Add("Smoke Decoy Bombs", 1);
                    }
                    else
                    {
                        resultBombs["Smoke Decoy Bombs"]++;
                    }
                }
                if (sum != 40 && sum != 120 && sum != 60)
                {
                    var temp = casings.Pop();
                    casings.Push(temp - 5);
                }
                if (GetBombsCount(resultBombs))
                {
                    break;
                }


            }
            if (!GetBombsCount(resultBombs))
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            else
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }

            if (effects.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: { string.Join(", ", effects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            if (casings.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: { string.Join(", ", casings)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            if (resultBombs.Count != 3)
            {
                if (!resultBombs.ContainsKey("Datura Bombs"))
                {
                    resultBombs["Datura Bombs"] = 0;
                }
                if (!resultBombs.ContainsKey("Cherry Bombs"))
                {
                    resultBombs["Cherry Bombs"] = 0;
                }
                if (!resultBombs.ContainsKey("Smoke Decoy Bombs"))
                {
                    resultBombs["Smoke Decoy Bombs"] = 0;
                }
            }
            foreach (var item in resultBombs.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }            
        }

        private static bool GetBombsCount(Dictionary<string, int> resultBombs)
        {
            var res = new List<int>();
            foreach (var item in resultBombs)
            {
                if (item.Value >= 3)
                {
                    res.Add(item.Value);
                }
            }
            if (res.Count == 3)
            {
                return true;
            }
            return false;
        }
    }
}
