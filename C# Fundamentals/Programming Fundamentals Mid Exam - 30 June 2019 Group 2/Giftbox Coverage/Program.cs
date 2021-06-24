using System;

namespace Giftbox_Coverage
{
    class Program
    {
        static void Main(string[] args)
        {
            double sizeOfSide = double.Parse(Console.ReadLine());
            double numOfPaper = double.Parse(Console.ReadLine());
            double areaPaperCover = double.Parse(Console.ReadLine());

            int count = 0;
            double countLowPaper = 0;
            double boxArea = sizeOfSide * sizeOfSide * 6;

            for (int i = 0; i < numOfPaper; i++)
            {
                count++;
                if (count % 3 == 0)
                {
                    countLowPaper++;
                }
            }
            double result = numOfPaper - countLowPaper;
            result *= areaPaperCover;
            countLowPaper *= areaPaperCover * 0.25;
            double paperCover = result + countLowPaper;
            double totalCovered = paperCover / boxArea * 100;

            Console.WriteLine($"You can cover {totalCovered:f2}% of the box.");
        }
    }
}
