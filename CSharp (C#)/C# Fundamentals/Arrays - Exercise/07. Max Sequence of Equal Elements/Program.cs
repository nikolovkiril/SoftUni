using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int bestCount = 0;
            int bestIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int currElement = arr[i];
                int currCount = 1;

                for (int currI = i+1; currI < arr.Length; currI++)
                {
                    if (currElement == arr[currI])
                    {
                        currCount++;
                    }
                    else
                    {
                        break;
                    }
                }
                
                if (currCount > bestCount)
                {
                    bestCount = currCount;
                    bestIndex = i;

                }
            }
            string result = "";
            for (int i = 0; i < bestCount; i++)
            {
                result += arr[bestIndex]+ " ";
            }
            Console.WriteLine(result);
        }
    }
}
