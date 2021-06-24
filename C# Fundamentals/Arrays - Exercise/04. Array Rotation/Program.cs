using System;

namespace _04._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();
            int input = int.Parse(Console.ReadLine());

           for (int j = 0; j < input; j++)
            {
                string tepm = arr[0];
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                arr[arr.Length - 1] = tepm;
            }
            Console.WriteLine(string.Join(" ",arr));
        }
    }
}
