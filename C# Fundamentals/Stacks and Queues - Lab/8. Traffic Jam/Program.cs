using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int passDuringGreen = int.Parse(Console.ReadLine());
            var carWaiting = new Queue<string>();
            int count = 0;
            string commands;
            while ((commands = Console.ReadLine()) != "end")
            {
                if (commands != "green")
                {
                    carWaiting.Enqueue(commands);
                }
                else if (commands == "green")
                {
                    for (int i = 0; i < passDuringGreen; i++)
                    {
                        if (carWaiting.Count != 0)
                        {
                            Console.WriteLine($"{carWaiting.Dequeue()} passed!");
                            count++;
                        }
                    }

                }
            }
            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
