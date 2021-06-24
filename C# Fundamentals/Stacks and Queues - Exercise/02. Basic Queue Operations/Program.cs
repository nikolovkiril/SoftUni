using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int toEnqueue = input[0];
            int toDequeue = input[1];
            int lookingFor = input[2];

            var command = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var playQueue = new Queue<int>();

            for (int i = 0; i < toEnqueue; i++)
            {
                playQueue.Enqueue(command[i]);
            }
            for (int i = 0; i < toDequeue; i++)
            {
                playQueue.Dequeue();
            }
            if (playQueue.Count == 0)
            {
                Console.WriteLine("0");
            }
            else if (playQueue.Contains(lookingFor))
            {
                Console.WriteLine("true");
            }
            else if (!playQueue.Contains(lookingFor))
            {
                Console.WriteLine(playQueue.Min());
            }
            
        }
    }
}
