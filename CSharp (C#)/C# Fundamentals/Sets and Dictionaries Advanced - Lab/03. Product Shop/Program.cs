using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var storeRecords = new Dictionary<string, Dictionary<string, double>>();
            //lidl, juice, 2.30
            string input;
            while ((input = Console.ReadLine()) != "Revision")
            {
                var splitInput = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string brand = splitInput[0];
                string product = splitInput[1];
                double price = double.Parse(splitInput[2]);

                if (!storeRecords.ContainsKey(brand))
                {
                    storeRecords.Add(brand, new Dictionary<string, double>());
                    storeRecords[brand].Add(product, price);
                }
                if (!storeRecords[brand].ContainsKey(product))
                {
                    storeRecords[brand].Add(product, 0);
                }
                storeRecords[brand][product] = price;

            }
            foreach (var (store,product) in storeRecords.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{store}->");
                foreach (var products in product)
                {
                    Console.WriteLine($"Product: {products.Key}, Price: {products.Value}");
                }
            }


            //fantastico->
            //Product: apple, Price: 1.2

        }
    }
}
