using System;

namespace _01._Experience_Gaining
{
    class Program
    {
        static void Main(string[] args)
        {
            double amountOfExperience = double.Parse(Console.ReadLine());
            int countOfBattles = int.Parse(Console.ReadLine());
            double collectedExperence = 0;

            for (int i = 1; i <= countOfBattles; i++)
            {
                int battleCount = i;
                double experienceEarned = double.Parse(Console.ReadLine());
                collectedExperence += experienceEarned;

                if (i % 3 == 0)
                {
                    collectedExperence += experienceEarned * 0.15;
                }
                if (i % 5 == 0)
                {
                    collectedExperence -= experienceEarned * 0.10;
                }
                if (collectedExperence >= amountOfExperience)
                {
                    Console.WriteLine($"Player successfully collected his needed experience for {battleCount} battles.");
                    break;
                }
            }
            if (collectedExperence < amountOfExperience)
            {
                Console.WriteLine($"Player was not able to collect the needed experience, {amountOfExperience - collectedExperence:f2} more needed.");
            }
        }
    }
}
