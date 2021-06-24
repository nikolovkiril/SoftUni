using System;
using System.Collections.Generic;
using System.Linq;


namespace _04._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            var planet = new Dictionary<string, Dictionary<string, List<string>>>();
            int inputLenght = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputLenght; i++)
            {
                string[] secInput = Console.ReadLine().Split();
                string continent = secInput[0];
                string country = secInput[1];
                string city = secInput[2];
                if (!planet.ContainsKey(continent))
                {
                    planet.Add(continent, new Dictionary<string, List<string>>());
                    planet[continent].Add(country, new List<string>());
                }
                if (!planet[continent].ContainsKey(country))
                {
                    planet[continent].Add(country,new List<string>());
                }
                planet[continent][country].Add(city);
            }

            //Europe:
            // Bulgaria->Sofia, Plovdiv
            // Poland->Warsaw, Poznan
            //Germany->Berlin
            foreach (var coninentKey in planet)
            {
                var continentName = coninentKey.Key;
                var countryPrint = coninentKey.Value;
                Console.WriteLine($"{continentName}:");
                foreach (var countryName in countryPrint)
                {
                    var cities = countryName.Value;
                    Console.WriteLine($"  {countryName.Key} -> {string.Join(", ", cities)}");
                }
            }
        }
    }
}
