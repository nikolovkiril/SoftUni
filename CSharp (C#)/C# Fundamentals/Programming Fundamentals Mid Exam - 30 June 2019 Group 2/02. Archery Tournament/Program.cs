using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Archery_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            string[] items = command.Split("|");
            int[] arr = items.Select(int.Parse).ToArray();

            int iskrenPoints = 0;
            int index = 0;
            int length = 0;

            string[] temp;
            string[] indexes;

            while ((command = Console.ReadLine()) != "Game over")
            {
                if (command == "Reverse")
                {
                    Array.Reverse(arr);
                    //command = Console.ReadLine();
                    continue;
                }
                temp = command.Split();
                indexes = temp[1].Split('@');
                if (indexes[0] == "Left")
                {
                    index = int.Parse(indexes[1]);
                    length = int.Parse(indexes[2]);
                    if (index >= 0 && index <= arr.Length)
                    {
                        while (length != 0)
                        {
                            if (index > 0)
                            {
                                index--;
                                length--;
                            }
                            else if (index == 0)
                            {
                                index = arr.Length - 1;
                                length--;
                            }
                        }
                        if (arr[index] >= 5)
                        {
                            arr[index] -= 5;
                            iskrenPoints += 5;
                        }
                        else
                        {
                            iskrenPoints += arr[index];
                            arr[index] = 0;
                        }
                    }
                }
                if (indexes[0] == "Right")
                {
                    index = int.Parse(indexes[1]);
                    length = int.Parse(indexes[2]);

                    if (index >= 0 && index <= arr.Length - 1)
                    {
                        while (length != 0)
                        {
                            if (index < arr.Length - 1)
                            {
                                index++;
                                length--;
                            }
                            else if (index == arr.Length - 1)
                            {
                                index = 0;
                                length--;
                            }
                        }

                        if (arr[index] >= 5)
                        {
                            arr[index] -= 5;
                            iskrenPoints += 5;
                        }
                        else
                        {
                            iskrenPoints += arr[index];
                            arr[index] = 0;
                        }
                    }
                }
            }
            for (int i = 0; i < arr.Length - 1; i++)
            {
                Console.Write(arr[i] + " - ");
            }

            Console.WriteLine(arr[arr.Length - 1]);
            Console.WriteLine($"Iskren finished the archery tournament with {iskrenPoints} points!");
        }
    }
}
