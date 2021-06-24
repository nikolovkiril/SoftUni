using System;
using System.Linq;

namespace _05._Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string result = "";
            for (int i = 0; i < arr.Length; i++)
            {
                int curr = arr[i];
                bool isTopInteger = true;
                for (int index = i+1; index < arr.Length; index++)
                {
                    if (curr <= arr[index])
                    {   
                        isTopInteger = false;
                        break;
                    }
                }
                if (isTopInteger)
                {
                    result += curr + " ";
                }
            }
            Console.WriteLine(result);
        }
    }
}
