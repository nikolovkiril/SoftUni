using System;

namespace ClassBoxData
{
    public class Program
    {
        static void Main(string[] args)
        {
            double l = double.Parse(Console.ReadLine());
            double w = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            try
            {
                Box box = new Box(l, w, h);
                Console.WriteLine($"Surface Area - {box.GetLateralSurfaceArea():F2}");
                Console.WriteLine($"Lateral Surface Area - {box.GetSurfaceArea():F2}");
                Console.WriteLine($"Volume - {box.GetVolume():F2}");
            }
            catch (ArgumentException eh)
            {
                Console.WriteLine(eh.Message);
            }
        }
    }
}
