using System;
using System.Collections.Generic;
using System.Linq;

namespace Froggy_Squad
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> frogs = Console.ReadLine()
                                     .Split(' ')
                                     .ToList();

            var result = new List<string>();

            string name;
            string input;

            while (!(input = Console.ReadLine()).Contains("Print"))
            {
                string[] format = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string taskToDo = format[0];
                if (taskToDo == "Join")
                {
                    name = format[1];
                    if (!frogs.Contains(name))
                    {
                        frogs.Add(name);
                    }
                }
                else if (taskToDo == "Jump")
                {
                    name = format[1];
                    int index = int.Parse(format[2]);
                    if (index >= 0 && index < frogs.Count)
                    {
                        frogs.Insert(index, name);
                    }
                }
                else if (taskToDo == "Dive")
                {
                    int index = int.Parse(format[1]);
                    if (index >= 0 && index < frogs.Count)
                    {
                        frogs.RemoveAt(index);

                    }
                }
                else if (taskToDo == "First")
                {
                    int count = int.Parse(format[1]);
                    if (frogs.Count <= count)
                    {
                        count = frogs.Count;
                    }
                    result = frogs.Take(count).Select(x => x).ToList();
                    Console.WriteLine(string.Join(" ", frogs));


                }
                else if (taskToDo == "Last")
                {
                    int count = int.Parse(format[1]);
                    if (frogs.Count <= count)
                    {
                        count = frogs.Count;
                    }
                    frogs.Reverse();
                    result = frogs.Take(count).Select(x => x).ToList();
                    frogs.Reverse();
                    result.Reverse();
                    Console.WriteLine(string.Join(" ", result));
                }
            }
            if (input.Split()[1] == "Reversed")
            {
                frogs.Reverse();
            }

            Console.WriteLine($"Frogs: {string.Join(" ", frogs)}");
        }
    }
}

