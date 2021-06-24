using System;

namespace _01._Disneyland_Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal jurneyCost = decimal.Parse(Console.ReadLine());
            int numOfMonths = int.Parse(Console.ReadLine());

            decimal count = 0;
            decimal result = 0;
            decimal expenceses = 0;
            decimal extraMoney = 0;

            for (int i = 1; i <= numOfMonths; i++)
            {
                count = jurneyCost * 0.25m;
                if (i > 2 && i % 2 != 0)
                {
                    expenceses = result * 0.16m;
                    result = result - expenceses;
                }
                if (i % 4 == 0)
                {
                    extraMoney = result * 0.25m;
                    result = result + extraMoney;
                }
                result += count;
            }
            if (jurneyCost > result)
            {
                Console.WriteLine($"Sorry. You need {jurneyCost - result:f2}lv. more."
);
            }
            else
            {
                Console.WriteLine($"Bravo! You can go to Disneyland and you will have {result - jurneyCost:f2}lv. for souvenirs.");
            }
        }
    }
}
