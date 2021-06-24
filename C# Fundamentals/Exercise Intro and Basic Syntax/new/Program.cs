using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacantion
{
    class Program
    {
        static void Main(string[] args)
        {
            int duest = int.Parse(Console.ReadLine());
            string typeGroup = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double totalPrice = 0;
            double discount = 0;
            if (typeGroup == "Students")
            {
                if (dayOfWeek == "Friday")
                {
                    totalPrice = 8.45 * duest;

                }
                else if (dayOfWeek == "Saturday")
                {
                    totalPrice = 9.80 * duest;

                }
                else if (dayOfWeek == "Sunday")
                {
                    totalPrice = 10.46 * duest;

                }
                if (duest >= 30)
                {
                    discount = totalPrice * 0.15;
                    totalPrice = totalPrice - discount;
                }

            }
            else if (typeGroup == "Business")
            {
                if (dayOfWeek == "Friday")
                {
                    totalPrice = 10.90 * duest;
                    if (duest >= 100)
                    {
                        totalPrice = 10.90 * (duest - 10);
                    }

                }
                else if (dayOfWeek == "Saturday")
                {
                    totalPrice = 15.60 * duest;
                    if (duest >= 100)
                    {
                        totalPrice = 15.60 * (duest - 10);
                    }

                }
                else if (dayOfWeek == "Sunday")
                {
                    totalPrice = 16 * duest;
                    if (duest >= 100)
                    {
                        totalPrice = 16 * (duest - 10);
                    }

                }


            }
            else if (typeGroup == "Regular")
            {
                if (dayOfWeek == "Friday")
                {
                    totalPrice = 15 * duest;

                }
                else if (dayOfWeek == "Saturday")
                {
                    totalPrice = 20 * duest;

                }
                else if (dayOfWeek == "Sunday")
                {
                    totalPrice = 22.50 * duest;

                }
                if (duest >= 10 && duest <= 20)
                {
                    discount = totalPrice * 0.05;
                    totalPrice = totalPrice - discount;

                }

            }
            Console.WriteLine($"Total price: {totalPrice:f2}");

        }
    }
}