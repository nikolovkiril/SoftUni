using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> itemPrice = new Dictionary<string, decimal>();
            Dictionary<string, int> quantityItem = new Dictionary<string, int>();

            string input;

            while ((input = Console.ReadLine()) != "buy")
            {
                string[] inputArg = input.Split(' ').ToArray();
                string productName = inputArg[0];
                decimal productPrice = decimal.Parse(inputArg[1]);
                int productQuantity = int.Parse(inputArg[2]);

                if (!quantityItem.ContainsKey(productName))
                {
                    quantityItem[productName] = 0;
                    itemPrice[productName] = 0;
                }
                quantityItem[productName] += productQuantity;
                itemPrice[productName] = productPrice;
            }

            foreach (var item in itemPrice)
            {
                string name = item.Key;
                decimal price = item.Value;
                int quantity = quantityItem[name];
                decimal totalPrice = quantity * price;
                Console.WriteLine($"{name} -> {totalPrice:f2}");
            }
        }
    }
}
