using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Tanks_Collector
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tanks = Console.ReadLine()
                                     .Split(", ")
                                     .ToList();
            int cmd = int.Parse(Console.ReadLine());

            string[] newCmd;

            for (int i = 0; i < cmd; i++)
            {
                string newCmd2 = Console.ReadLine();
                newCmd = newCmd2.Split(", ");

                if (newCmd[0] == "Add")
                {
                    if (tanks.Contains(newCmd[1]))
                    {
                        Console.WriteLine("Tank is already bought");
                    }
                    else
                    {
                        Console.WriteLine("Tank successfully bought");
                        tanks.Add(newCmd[1]);
                    }
                }
                else if(newCmd[0] == "Remove")
                {
                    if (tanks.Contains(newCmd[1]))
                    {
                        Console.WriteLine("Tank successfully sold");
                        tanks.Remove(newCmd[1]);
                    }
                    else
                    {
                        Console.WriteLine("Tank not found");
                    }
                }
                else if (newCmd[0] == "Remove At")
                {
                    int num = int.Parse(newCmd[1]);
                    if (num >= 0 && num < tanks.Count)
                    {
                        tanks.RemoveAt(num);
                        Console.WriteLine("Tank successfully sold");
                    }
                    else
                    {
                        Console.WriteLine("Index out of range");
                    }
                }
                else if (newCmd[0] == "Insert")
                {
                    int num = int.Parse(newCmd[1]);
                    if (num >= 0 && num < tanks.Count)
                    {
                        if (tanks.Contains(newCmd[2]))
                        {
                            Console.WriteLine("Tank is already bought");
                        }
                        else
                        {
                            tanks.Insert(num, newCmd[2]);
                            Console.WriteLine("Tank successfully bought");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Index out of range");
                    }
                }
            }
            Console.WriteLine(string.Join(", " , tanks));
        }
    }
}
