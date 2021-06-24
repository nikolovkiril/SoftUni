using System;

namespace practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int[] sum = new int[num];

            for (int i = 0; i < num; i++)
            {
                sum[i] = 2;    
                Console.WriteLine(sum[i]);
            }
        }
    }
}
