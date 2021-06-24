using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace _1._Dating_App
{
    class Program
    {
        static void Main(string[] args)
        {
            var males = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            var females = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            int matches = 0;
            while (females.Count > 0 && males.Count > 0)
            {
                var male = males.Peek();
                var female = females.Peek();
                if (female <= 0 || male <= 0)
                {
                    if (female <= 0)
                    {
                        females.Dequeue();
                    }
                    if (male <= 0)
                    {
                        males.Pop();
                    }
                    continue;
                }


                if (male % 25 == 0)
                {
                    males.Pop();
                    if (males.Count == 0)
                    {
                        break;
                    }
                    males.Pop();
                    if (males.Count == 0)
                    {
                        break;
                    }
                    continue;
                }
                if (female % 25 == 0)
                {
                    females.Dequeue();
                    if (females.Count == 0)
                    {
                        break;
                    }
                    females.Dequeue();
                    if (females.Count == 0)
                    {
                        break;
                    }
                    continue;
                }
                if (males.Count == 0 && females.Count == 0)
                {
                    break;
                }
                if (male == female)
                {
                    males.Pop();
                    females.Dequeue();
                    matches++;
                    if (males.Count == 0 && females.Count == 0)
                    {
                        break;
                    }
                    //continue;
                }
                else
                {
                    females.Dequeue();
                    male -= 2;
                    males.Pop();
                    males.Push(male);
                    if (males.Count == 0 && females.Count == 0)
                    {
                        break;
                    }
                }

            }
            Console.WriteLine($"Matches: {matches}");
            if (males.Count == 0)
            {
                Console.WriteLine("Males left: none");
            }
            else
            {
                Console.Write("Males left: ");
                Console.WriteLine(string.Join (", " , males));
            }
            if (females.Count == 0)
            {
                Console.WriteLine("Females left: none");
            }
            else
            {
                Console.Write($"Females left: ");
                Console.WriteLine(string.Join(", ", females));
            }
        }

    }
}
