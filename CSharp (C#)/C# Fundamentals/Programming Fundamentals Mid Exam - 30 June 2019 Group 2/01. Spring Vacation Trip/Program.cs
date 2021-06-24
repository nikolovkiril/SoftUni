using System;

namespace _01._Spring_Vacation_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int tripDays = int.Parse(Console.ReadLine());
            decimal budget = decimal.Parse(Console.ReadLine());
            int numOfPpl = int.Parse(Console.ReadLine());
            decimal fuelPrice = decimal.Parse(Console.ReadLine());
            decimal foodPrice = decimal.Parse(Console.ReadLine());
            decimal roomPrice = decimal.Parse(Console.ReadLine());

            decimal distancePerDay = 0;
            decimal totalExpenses = 0;
            decimal extraExpenses = 0;

            decimal foodExpenses = tripDays * numOfPpl * foodPrice;
            decimal hotelExpenses = tripDays * numOfPpl * roomPrice;
            if (numOfPpl > 10)
            {
                hotelExpenses -= hotelExpenses * 0.25m;
            }
            decimal currentExpenses = foodExpenses + hotelExpenses;

            for (int i = 1; i <= tripDays; i++)
            {
                distancePerDay = decimal.Parse(Console.ReadLine());
                distancePerDay *= fuelPrice;
                //totalExpenses += distancePerDay;

                currentExpenses += distancePerDay;
                if (i % 3 == 0 || i % 5 == 0)
                {
                    extraExpenses = currentExpenses * 0.4m;
                    currentExpenses += extraExpenses;
                }
                if (i % 7 == 0)
                {
                    currentExpenses -= currentExpenses / numOfPpl;
                }
            }
            if (currentExpenses <= budget)
            {
                Console.WriteLine($"You have reached the destination. You have {budget - currentExpenses:f2}$ budget left.");
            }
            else if (currentExpenses > budget)
            {
                Console.WriteLine($"Not enough money to continue the trip. You need {currentExpenses - budget:f2}$ more.");
            }
        }
    }
}
