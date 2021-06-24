using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parkingValidation = new Dictionary<string, string>();

            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                string[] commandInput = Console.ReadLine().Split(' ').ToArray();

                if (commandInput[0] == "register")
                {
                    string name = commandInput[1];
                    string regPlate = commandInput[2];
                    if (!parkingValidation.ContainsKey(name))
                    {
                        parkingValidation.Add(name, regPlate);
                        Console.WriteLine($"{name} registered {regPlate} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {regPlate}");
                    }
                }
                else if (commandInput[0] == "unregister")
                {
                    string name = commandInput[1];

                    if (!parkingValidation.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                    else
                    {
                        parkingValidation.Remove(name);
                        Console.WriteLine($"{name} unregistered successfully");
                    }
                }
            }
            foreach (var item in parkingValidation)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
