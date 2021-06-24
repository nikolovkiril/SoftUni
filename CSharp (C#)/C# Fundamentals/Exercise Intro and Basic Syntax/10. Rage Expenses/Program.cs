using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double trashedHeadset = Math.Floor(lostGamesCount / 2.0);
            double trashedMouse = Math.Floor(lostGamesCount / 3.0);
            double trashedkeyboard = Math.Floor(lostGamesCount / 6.0);
            double trashedDisplay = Math.Floor(lostGamesCount / 12.0);

            double totalExpenses = (headsetPrice * trashedHeadset) + (mousePrice * trashedMouse) + (keyboardPrice * trashedkeyboard) + (displayPrice * trashedDisplay);


            Console.WriteLine($"Rage expenses: {totalExpenses:F2} lv.");
        }
    }
}