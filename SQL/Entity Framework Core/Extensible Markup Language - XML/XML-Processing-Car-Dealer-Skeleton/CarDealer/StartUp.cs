using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using ProductShop.XmlHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();
            //ResetDatabase(db);

            var suppliersInput = File.ReadAllText("../../../Datasets/suppliers.xml");
            var partsInput = File.ReadAllText("../../../Datasets/parts.xml");
            var carsInput = File.ReadAllText("../../../Datasets/cars.xml");
            var customersInput = File.ReadAllText("../../../Datasets/customers.xml");
            var salesInput = File.ReadAllText("../../../Datasets/sales.xml");


            //Console.WriteLine(ImportSuppliers(db , suppliersInput));
            //Console.WriteLine(ImportParts(db , partsInput));
            //Console.WriteLine(ImportCars(db , carsInput));
            //Console.WriteLine(ImportCustomers(db , customersInput));
            //Console.WriteLine(ImportSales(db , salesInput));



            //Console.WriteLine(GetCarsWithDistance(db));
            //Console.WriteLine(GetCarsFromMakeBmw(db));
            //Console.WriteLine(GetLocalSuppliers(db));
            //Console.WriteLine(GetCarsWithTheirListOfParts(db));
            //Console.WriteLine(GetTotalSalesByCustomer(db));
            Console.WriteLine(GetSalesWithAppliedDiscount(db));
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            const string root = "sales";

            var salesWithAppliedDiscount = context.Sales
                .Select(x => new SalesWithAppliedDiscount
                {
                    Car = new CarsWithDistanceModel
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },
                    Discount = x.Discount,
                    Name = x.Customer.Name,
                    Price = x.Car.PartCars.Sum(x => x.Part.Price),
                    PriceWithDiscount = x.Car.PartCars.Sum(x => x.Part.Price) 
                    - x.Car.PartCars.Sum(x => x.Part.Price) * x.Discount / 100m,
                })
                .ToList();


            var res = XmlConverter.Serialize(salesWithAppliedDiscount, root);

            return res.ToString().TrimEnd();
        }
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            const string root = "customers";
            var totalSalesByCustomer = context
                .Customers
                .Where(x => x.Sales.Any())
                .Select(x => new TotalSalesByCustomerModel
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count,
                    SpentMoney = x.Sales.Select(x => x.Car).SelectMany(x => x.PartCars).Sum(x => x.Part.Price)
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToList();

            var res = XmlConverter.Serialize(totalSalesByCustomer, root);

            return res.ToString().TrimEnd();
        }
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            const string root = "cars";

            var carsWithTheirListOfParts = context.Cars
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Select(x => new CarsWithTheirListOfPartsModel
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    PartsModel = x.PartCars.Select(p => new PartsExportModel
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToList()
                })
                .Take(5)
                .ToList();

            var res = XmlConverter.Serialize(carsWithTheirListOfParts, root);

            return res.ToString().TrimEnd();
        }
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            const string root = "suppliers";

            var localSuppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new LocalSuppliersModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToList();

            var res = XmlConverter.Serialize(localSuppliers, root);

            return res.ToString().TrimEnd();
        }
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            const string root = "cars";

            var carsFromMakeBmw = context
                .Cars
                .Where(x => x.Make == "BMW")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new CarsFromMakeBmwModel
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .ToList();

            var res = XmlConverter.Serialize(carsFromMakeBmw, root);

            return res.ToString().TrimEnd();
        }
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            const string root = "cars";
            var carsWithDistance = context.Cars
                .Where(x => x.TravelledDistance > 2_000_000)
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Select(x => new CarsWithDistanceModel
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .Take(10)
                .ToList();

            var res = XmlConverter.Serialize(carsWithDistance, root);

            return res.ToString().TrimEnd();
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            const string root = "Sales";

            var salesXml = XmlConverter.Deserializer<SalesModel>(inputXml, root);

            var carId = context.Cars.Select(x => x.Id).ToList();

            var sales = salesXml.
                Where(x => carId.Contains(x.CarId))
                .Select(x => new Sale
                {
                    CarId = x.CarId,
                    CustomerId = x.CustomerId,
                    Discount = x.Discount
                })
                .ToList();

            context.Sales.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            const string root = "Customers";

            var customersXml = XmlConverter.Deserializer<CustomersModel>(inputXml, root);

            var customers = customersXml
                .Select(x => new Customer
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate,
                    IsYoungDriver = x.IsYoungDriver
                })
                .ToList();

            context.Customers.AddRange(customers);

            context.SaveChanges();
            return $"Successfully imported {customers.Count}";
        }
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            const string root = "Cars";
            var carsXml = XmlConverter.Deserializer<CarModel>(inputXml, root);

            var cars = new List<Car>();
            var partCars = new List<PartCar>();


            foreach (var carDto in carsXml)
            {
                var car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TraveledDistance,
                };

                var parts = carDto.PartCarsModel
                    .Where(p => context.Parts.Any(x => x.Id == p.Id))
                    .Select(p => p.Id)
                    .Distinct();

                foreach (var part in parts)
                {
                    var carPart = new PartCar
                    {
                        PartId = part,
                        Car = car
                    };
                    partCars.Add(carPart);
                }
                cars.Add(car);
            }
            context.Cars.AddRange(cars);
            context.PartCars.AddRange(partCars);

            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            const string root = "Parts";

            var partsXml = XmlConverter.Deserializer<PartsModel>(inputXml, root);

            var supplierIds = context.Suppliers
                .Select(x => x.Id)
                .ToList();

            var parts = partsXml
                .Where(s => supplierIds.Contains(s.SupplierId))
                .Select(x => new Part
                {
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    SupplierId = x.SupplierId
                })
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}"; ;
        }
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            const string root = "Suppliers";

            var supliersXml = XmlConverter.Deserializer<SuppliersModel>(inputXml, root);

            var suppliers = supliersXml.Select(x => new Supplier
            {
                Name = x.Name,
                IsImporter = x.IsImporter
            })
                .ToList();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }
        private static void ResetDatabase(CarDealerContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Db was successfully deleted!");

            db.Database.EnsureCreated();
            Console.WriteLine("Db was successfully created!");
        }
    }
}