using System;

namespace _07._Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double coinsSum = 0;
            double nuts = 2.0;
            double water = 0.7;
            double crisps = 1.5;
            double soda = 0.8;
            double coke = 1.0;

            while (input != "Start")
            {
                double coins = double.Parse(input);
                if (coins == 0.1 || coins == 0.2 || coins == 0.5 || coins == 1 || coins == 2)
                {
                    coinsSum += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }
                input = Console.ReadLine();
            }
            string products = Console.ReadLine();
            while (products != "End")
            {
                if (products == "Nuts")
                {
                    if (coinsSum >= nuts)
                    {
                        coinsSum -= 2;
                        Console.WriteLine($"Purchased nuts");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
               else if (products == "Water")
                {
                    if (coinsSum >= water)
                    {
                        coinsSum -= 0.7;
                        Console.WriteLine($"Purchased water");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (products == "Crisps")
                {
                    if (coinsSum >= crisps)
                    {
                        coinsSum -= 1.5;
                        Console.WriteLine($"Purchased crisps");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (products == "Soda")

                    if (coinsSum >= soda)
                    {
                        coinsSum -= 0.8;
                        Console.WriteLine($"Purchased soda");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                else if (products == "Coke")
                {
                    if (coinsSum >= coke)
                    {
                        coinsSum -= 1;
                        Console.WriteLine($"Purchased coke");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }
                products = Console.ReadLine();
                if (products == "End")
                {
                    break;
                }
            }
            Console.WriteLine($"Change: {coinsSum:F2}");
        }
    }
}
