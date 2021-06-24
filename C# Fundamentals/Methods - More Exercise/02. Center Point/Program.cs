using System;

namespace _02._Center_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            double X1 = double.Parse(Console.ReadLine());
            double Y1 = double.Parse(Console.ReadLine());
            double X2 = double.Parse(Console.ReadLine());
            double Y2 = double.Parse(Console.ReadLine());

            ClosestToCenter(X1, Y1, X2, Y2);
        }
        static void ClosestToCenter(double X1, double Y1, double X2, double Y2)
        {
            double first = Math.Sqrt(Math.Pow(Y1, 2) + Math.Pow(X1, 2));
            double secound = Math.Sqrt(Math.Pow(Y2, 2) + Math.Pow(X2, 2));

            if (first < secound)
            {
                Console.WriteLine($"({X1}, {Y1})");
            }
            else
            {
                Console.WriteLine($"({X2}, {Y2})");
            }
        }
    }
}
