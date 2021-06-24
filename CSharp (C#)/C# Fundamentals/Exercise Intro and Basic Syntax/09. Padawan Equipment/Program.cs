using System;

namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            float student = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltsPrice = double.Parse(Console.ReadLine());

            double lightsaberExtra = Math.Ceiling (student+(student * 0.1));
            double beltsExtra = Math.Ceiling (student-(student / 6));
            double totalSum = 0;

            lightsaberPrice = lightsaberPrice * lightsaberExtra;
            robesPrice = student * robesPrice;
            beltsPrice =  beltsExtra * beltsPrice;
            totalSum = lightsaberPrice + beltsPrice + robesPrice;

            if (money >= totalSum)
            {
                Console.WriteLine($"The money is enough - it would cost {totalSum:f2}lv.");
            }
            else
            {
                totalSum -= money;
                Console.WriteLine($"Ivan Cho will need {totalSum:f2}lv more.");
            }
        }
    }
}
