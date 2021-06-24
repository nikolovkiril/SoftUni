using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductShop.Data;
using ProductShop.DataTransferObjects;
using ProductShop.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            // db.Database.EnsureDeleted();
            // db.Database.EnsureCreated();

            string inputUsersJson = File.ReadAllText("../../../Datasets/users.json");
            string inputProductsJson = File.ReadAllText("../../../Datasets/products.json");
            string inputCategoriesJson = File.ReadAllText("../../../Datasets/categories.json");
            string inputCategoryProductsJson = File.ReadAllText("../../../Datasets/categories-products.json");

            //Console.WriteLine(ImportUsers(db, inputUsersJson));
            //Console.WriteLine(ImportProducts(db, inputProductsJson));
            //Console.WriteLine(ImportCategories(db, inputCategoriesJson));
            //Console.WriteLine(ImportCategoryProducts(db, inputCategoryProductsJson));

            //Console.WriteLine(GetProductsInRange(db));
            //Console.WriteLine(GetSoldProducts(db));
            //Console.WriteLine(GetCategoriesByProductsCount(db));
            Console.WriteLine(GetUsersWithProducts(db));
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithProducts = context.Users
                .Include(x => x.ProductsSold)
                .ToList()
                .Where(x => x.ProductsSold.Any(b => b.BuyerId != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    age = x.Age,
                    soldProducts = new
                    {
                        count = x.ProductsSold.Where(ps => ps.BuyerId != null).Count(),
                        products = x.ProductsSold.Where(ps => ps.BuyerId != null)
                        .Select(ps => new
                        {
                            name = ps.Name,
                            price = ps.Price
                        })
                    },
                })
                .OrderByDescending(x => x.soldProducts.products.Count())
                .ToList();

            var result = new
            {
                usersCount = usersWithProducts.Count(),
                users = usersWithProducts
            };

            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };
            var json = JsonConvert.SerializeObject(result, settings);
            return json;
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesByProductsCount = context.Categories
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count(),
                    averagePrice = x.CategoryProducts.Average(p => p.Product.Price).ToString("f2"),
                    totalRevenue = x.CategoryProducts.Sum(p => p.Product.Price).ToString("f2")
                })
                .OrderByDescending(x => x.productsCount)
                .ToList();

            var json = JsonConvert.SerializeObject(categoriesByProductsCount, Formatting.Indented);
            return json;
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersWithMinOneSoldItem = context.Users
                .Where(x => x.ProductsSold.Any(p => p.Buyer != null))
                .Where(p => p.ProductsSold.Count >= 1)
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold.Select(b => new
                    {
                        name = b.Name,
                        price = b.Price,
                        buyerFirstName = b.Buyer.FirstName,
                        buyerLastName = b.Buyer.LastName
                    })

                    .ToList()
                })
                .OrderBy(x => x.lastName)
                .ThenBy(x => x.firstName)
                .ToList();

            var json = JsonConvert.SerializeObject(usersWithMinOneSoldItem, Formatting.Indented);
            return json;
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            var range = context.Products
                 .Where(x => x.Price >= 500 && x.Price <= 1000)
                 .Select(x => new
                 {
                     name = x.Name,
                     price = x.Price,
                     seller = (x.Seller.FirstName != null ? x.Seller.FirstName : "") + " " + (x.Seller.LastName != null ? x.Seller.LastName : "")
                 })
                 .OrderBy(x => x.price)
                 .ToList();

            var result = JsonConvert.SerializeObject(range, Formatting.Indented);


            return result;
        }


        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitializeAutomapper();

            var dtoCategoryProduct = JsonConvert.DeserializeObject<IEnumerable<CategoryProductInputModel>>(inputJson);
            var ids = mapper.Map<IEnumerable<CategoryProduct>>(dtoCategoryProduct);

            context.CategoryProducts.AddRange(ids);
            context.SaveChanges();

            return $"Successfully imported {ids.Count()}";
        }
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InitializeAutomapper();

            var dtoCategorie = JsonConvert.DeserializeObject<IEnumerable<CategoryInputModel>>(inputJson)
                .Where(x => x.Name != null)
                .ToList();
            var category = mapper.Map<IEnumerable<Category>>(dtoCategorie);

            context.AddRange(category);
            context.SaveChanges();

            return $"Successfully imported {category.Count()}";
        }
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            InitializeAutomapper();

            var dtoProducts = JsonConvert.DeserializeObject<IEnumerable<ProductInputModel>>(inputJson);
            var products = mapper.Map<IEnumerable<Product>>(dtoProducts);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            InitializeAutomapper();

            var dtoUsers = JsonConvert.DeserializeObject<IEnumerable<UserInputModel>>(inputJson);
            var users = mapper.Map<IEnumerable<User>>(dtoUsers);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        private static void InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}