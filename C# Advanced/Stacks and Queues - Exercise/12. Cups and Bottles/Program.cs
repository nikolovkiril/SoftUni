using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            var remainingCups = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Reverse());
            var remainingBottles = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            
            var wastedLittersOfWater = 0;

            while (true)
            {

                if (remainingCups.Count() != 0 && remainingBottles.Count() != 0)
                {
                    int waterLeft = remainingBottles.Pop();
                    int waterNeed = remainingCups.Pop();

                    if (waterNeed > waterLeft)
                    {
                        var fillUp = waterNeed - waterLeft;
                        remainingCups.Push(fillUp);

                    }
                    else
                    {
                        wastedLittersOfWater += waterLeft - waterNeed;
                    }
                }
                else if (remainingCups.Count == 0)
                {
                    Console.WriteLine($"Bottles: {string.Join(" ", remainingBottles)}");
                    GetWastedWater(wastedLittersOfWater);
                    break;
                }
                else if (remainingBottles.Count == 0)
                {
                    Console.WriteLine($"Cups: {string.Join(" ", remainingCups)}");
                    GetWastedWater(wastedLittersOfWater);
                    break;
                }
                else if (remainingBottles.Count == 0 && remainingCups.Count == 0)
                {
                    return;
                }
            }
        }

        private static void GetWastedWater(int wastedLittersOfWater)
        {
            Console.WriteLine($"Wasted litters of water: {wastedLittersOfWater}");
        }
    }
}
