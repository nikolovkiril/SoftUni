using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            var carsWaiting = new Queue<string>();
            int duration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            int count = 0;
            bool carPass = false;
            
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command != "green")
                {
                    AddCar(carsWaiting, command);
                }
                else
                {
                    int currGreen = duration;
                    GetCarPass(carsWaiting, ref freeWindow, ref count, ref carPass, ref currGreen);
                }
                if (carPass)
                {
                    break;
                }
            }
            if (!carPass)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{count} total cars passed the crossroads.");
            }
        }

        private static void GetCarPass(Queue<string> carsWaiting, ref int freeWindow, ref int count, ref bool carPass, ref int currGreen)
        {
            while (currGreen > 0 && carsWaiting.Count != 0)
            {

                string carName = carsWaiting.Dequeue();
                int carLength = carName.Length;
                if (currGreen - carLength > 0
                    && currGreen - carLength <= currGreen)
                {
                    currGreen -= carLength;
                }
                else
                {
                    int left = currGreen - carLength;

                    if (left > 0)
                    {
                        currGreen -= carLength;
                    }
                    else
                    {
                        if (freeWindow - Math.Abs(left) >= 0)
                        {
                            freeWindow -= Math.Abs(left);
                            currGreen -= carLength;
                        }
                        else
                        {
                            carPass = true;
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{carName} was hit at {carName[currGreen + freeWindow]}.");
                            break;
                        }
                    }
                }
                count++;
            }
        }

        private static void AddCar(Queue<string> carsWaiting, string command)
        {
            carsWaiting.Enqueue(command);
        }
    }
}



