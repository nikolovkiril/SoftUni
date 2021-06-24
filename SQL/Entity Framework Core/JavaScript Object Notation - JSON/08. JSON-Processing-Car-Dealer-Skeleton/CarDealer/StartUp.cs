using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        private const string DATASETS_DIRECTORY_PATH = "../../../Datasets";

        public static void Main(string[] args)
        {
            var db = new CarDealerContext();

            //ResetDatabase(db);

            using (db)
            {
                InitializeAutomapper();
                var suppliersInput = File.ReadAllText($"{DATASETS_DIRECTORY_PATH}/suppliers.json");
                var partsInput = File.ReadAllText($"{DATASETS_DIRECTORY_PATH}/parts.json");
                var carsInput = File.ReadAllText($"{DATASETS_DIRECTORY_PATH}/cars.json");
                var customersInput = File.ReadAllText($"{DATASETS_DIRECTORY_PATH}/customers.json");
                var salesInput = File.ReadAllText($"{DATASETS_DIRECTORY_PATH}/sales.json");


                //Console.WriteLine(ImportSuppliers(db, suppliersInput));
                //Console.WriteLine(ImportParts(db, partsInput));
                //Console.WriteLine(ImportCars(db, carsInput));
                //Console.WriteLine(ImportCustomers(db, customersInput));
                //Console.WriteLine(ImportSales(db, salesInput));
                //Console.WriteLine(GetOrderedCustomers(db));
                //Console.WriteLine(GetCarsFromMakeToyota(db));
                //Console.WriteLine(GetLocalSuppliers(db));
                //Console.WriteLine(GetCarsWithTheirListOfParts(db));
                //Console.WriteLine(GetTotalSalesByCustomer(db));
                Console.WriteLine(GetSalesWithAppliedDiscount(db));
            }

        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var getSalesWithAppliedDiscount = context.Sales
                .Select(x => new 
                {
                    car = new 
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },
                    customerName = x.Customer.Name,
                    Discount = x.Discount.ToString("f2"),
                    price = x.Car.PartCars.Sum(pc => pc.Part.Price).ToString("f2"),
                    priceWithDiscount = (x.Car.PartCars.Sum(pc => pc.Part.Price) - 
                    x.Car.PartCars.Sum(pc => pc.Part.Price) * x.Discount / 100).ToString("f2")
                })
                .Take(10)
                .ToList();

            var json = JsonConvert.SerializeObject(getSalesWithAppliedDiscount, Formatting.Indented);
            return json;
        }
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var getTotalSalesByCustomer = context.Customers
                .ProjectTo<CustomerTotalSalesDTO>()
                .Where(c => c.BoughtCars >= 1)
                .OrderByDescending(c => c.SpentMoney)
                    .ThenByDescending(c => c.BoughtCars)
                    .ToList();

            var json = JsonConvert.SerializeObject(getTotalSalesByCustomer, Formatting.Indented);
            return json;
        }
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithTheirListOfParts = context.Cars
                .Select(x => new
                {
                    car = new
                    {
                        Make = x.Make,
                        Model = x.Model,
                        TravelledDistance = x.TravelledDistance,
                    },

                    parts = x.PartCars.Select(p => new
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price.ToString("f2")
                    })
                    .ToList()
                })
                .ToList();

            var json = JsonConvert.SerializeObject(carsWithTheirListOfParts, Formatting.Indented);
            return json;
        }
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    PartsCount = x.Parts.Count()
                })
                .ToList();

            var json = JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);
            return json;
        }
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var carsFromMakeToyota = context.Cars
                .Where(x => x.Make == "Toyota")
                .Select(x => new
                {
                    Id = x.Id,
                    Make = x.Make,
                    x.Model,
                    x.TravelledDistance,
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToList();

            var json = JsonConvert.SerializeObject(carsFromMakeToyota, Formatting.Indented);
            return json;
        }
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var orderedCustomers = context.Customers
                .OrderBy(x => x.BirthDate)
                .Select(x => new
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = x.IsYoungDriver
                })
                .ToList();

            var json = JsonConvert.SerializeObject(orderedCustomers, Formatting.Indented);
            return json;
        }


        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<IEnumerable<Sale>>(inputJson);

            context.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var dtoCars = JsonConvert.DeserializeObject<IEnumerable<CarsInputDTO>>(inputJson);

            var cars = new List<Car>();

            foreach (var car in dtoCars)
            {
                var currentCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                foreach (var part in car.PartsId.Distinct())
                {
                    currentCar.PartCars.Add(new PartCar
                    {
                        PartId = part
                    });
                }
                cars.Add(currentCar);
            }
            context.AddRange(cars);

            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)
                     .Where(p => Enumerable.Range(context.Suppliers
                                                         .Min(s => s.Id),
                                                  context.Suppliers
                                                         .Max(s => s.Id))
                                           .Contains(p.SupplierId))
                     .ToList();


            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {

            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.AddRange(suppliers);

            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }


        private static void ResetDatabase(CarDealerContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Db was successfully deleted!");

            db.Database.EnsureCreated();
            Console.WriteLine("Db was successfully created!");
        }

        private static void InitializeAutomapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });
        }

    }
}