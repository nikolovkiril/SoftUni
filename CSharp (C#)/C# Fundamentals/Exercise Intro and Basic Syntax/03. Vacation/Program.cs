using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int guest = int.Parse(Console.ReadLine());
            string tipeGroup = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            decimal price = 0;

            if (tipeGroup == "Students")
            {
               if (dayOfWeek == "Friday")
                {
                    price = 8.45m;
                }
                else if (dayOfWeek == "Saturday")
                {
                    price = 9.80m;
                }
                else if (dayOfWeek == "Sunday")
                {
                    price = 10.46m;
                }
                    if (guest >= 30)
                    {
                    decimal totalPrice = guest * price;
                    decimal discount = totalPrice * 0.15m;
                    decimal finalPrice = totalPrice - discount;
                    Console.WriteLine($"Total price: {finalPrice:f2}");
                }
                    else
                    {
                    decimal priceNoDiscount = guest * price;
                    Console.WriteLine($"Total price: {priceNoDiscount:f2}");
                }
                    }
        else if (tipeGroup == "Business")
            {
               if (dayOfWeek == "Friday")
                {
                    price = 10.90m;
                }
                else if (dayOfWeek == "Saturday")
                {
                    price = 15.60m;
                }
                else if (dayOfWeek == "Sunday")
                {
                    price = 16m;
                }
                if (guest >= 100)
                {
                    decimal totalPrice = (guest-10) * price;
                   Console.WriteLine($"Total price: {totalPrice:f2}");
                }
                else if (guest > 0)
                {
                    decimal priceNoDiscount = guest * price;
                    Console.WriteLine($"Total price: {priceNoDiscount:f2}");
                }
            }
            else if (tipeGroup == "Regular")
            {
                if (dayOfWeek == "Friday")
                {
                    price = 15m;
                }
                else if (dayOfWeek == "Saturday")
                {
                    price = 20m;
                }
                else if (dayOfWeek == "Sunday")
                {
                    price = 22.50m;
                }
                if (guest >= 10 && guest <= 20)
                {
                    decimal totalPrice = guest * price;
                    decimal discount = totalPrice * 0.05m;
                    decimal finalPrice = totalPrice - discount;
                    Console.WriteLine($"Total price: {finalPrice:f2}");
                }
                else
                {
                    decimal priceNoDiscount = guest * price;
                    Console.WriteLine($"Total price: {priceNoDiscount:f2}");
                }
            }
        }
    }
}
