using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ");
            var songList = new Queue<string>(input);

            while (songList.Any())
            {
                var command = Console.ReadLine();

                if (command.Contains("Play"))
                {
                    if (songList.Any())
                    {
                        songList.Dequeue();
                    }
                }
                else if (command.Contains("Add"))
                {
                    command = command.Remove(0, 4);
                    if (!songList.Contains(command))
                    {
                        songList.Enqueue(command);
                    }
                    else
                    {
                        Console.WriteLine($"{command} is already contained!");
                    }
                }
                else if (command.Contains("Show"))
                {
                    Console.WriteLine(string.Join(", ", songList));
                }
            }
            Console.WriteLine("No more songs!");

        }
    }
}
