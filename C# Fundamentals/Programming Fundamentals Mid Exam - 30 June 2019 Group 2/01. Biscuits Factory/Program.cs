using System;

namespace _01._Biscuits_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int biscuitPerDay = int.Parse(Console.ReadLine());
            int employees = int.Parse(Console.ReadLine());
            int competingFactory = int.Parse(Console.ReadLine());

            double totalBiscuit = biscuitPerDay * employees * 20;
            double biscuitLes = Math.Floor(biscuitPerDay * employees * 10 * 0.75);
            totalBiscuit += biscuitLes;

            double difference = 0.0;
            double procentige = 0;

            Console.WriteLine($"You have produced {totalBiscuit} biscuits for the past month.");

            if (totalBiscuit >= competingFactory)
            {
                difference = totalBiscuit - competingFactory;
                procentige = difference / competingFactory * 100;
                Console.WriteLine($"You produce {procentige:f2} percent more biscuits.");
            }
            else
            {
                difference = competingFactory - totalBiscuit;
                procentige = difference / competingFactory * 100;
                Console.WriteLine($"You produce {procentige:f2} percent less biscuits.");

            }


        }
    }
}
