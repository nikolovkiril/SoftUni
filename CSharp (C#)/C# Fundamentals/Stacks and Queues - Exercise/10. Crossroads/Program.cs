using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int duration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            var carsWaiting = new Queue<int>();
            int count = 0;
            int carPas = 0;

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                if (input != "green")
                {
                    for (int i = 1; i <= input.Length; i++)
                    {
                        count = i;
                    }
                    carsWaiting.Enqueue(count);
                }
                else if (input == "green")
                {
                    if (carsWaiting.Count > 1)
                    {
                        foreach (var car in carsWaiting)
                        {
                            if (duration + freeWindow >= car)
                            {
                                carsWaiting.Dequeue();
                                carPas++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {

                    }
                }
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carPas} total cars passed the crossroads.");
        }
    }
}
