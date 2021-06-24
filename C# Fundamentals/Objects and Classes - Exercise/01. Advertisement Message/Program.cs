using System;

namespace _01._Advertisement_Message
{
    class Program
    {
        private const string V = "Best product of its category.";

        static void Main(string[] args)
        {
            string[] phrases = { "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Exceptional product.",
                "I can’t live without this product."};

            string[] events = { "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!" };

            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };
            Random random = new Random();
            int command = int.Parse(Console.ReadLine());

            for (int i = 0; i < command; i++)
            {
                int phrasesIndex = random.Next(0, phrases.Length);
                int eventsIndex = random.Next(0, events.Length);
                int authorsIndex = random.Next(0, authors.Length);
                int citiesIndex = random.Next(0, cities.Length);

                Console.WriteLine($"{phrases[phrasesIndex]} {events[eventsIndex]} {authors[authorsIndex]} – {cities[citiesIndex]}.");
            }

        }
    }

}

