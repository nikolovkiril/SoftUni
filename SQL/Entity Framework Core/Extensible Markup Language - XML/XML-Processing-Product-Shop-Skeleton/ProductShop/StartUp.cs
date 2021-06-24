using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Export.GetUsersWithProducts;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using ProductShop.XmlHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            //ResetDatabase(db);


            var usersInput = File.ReadAllText("../../../Datasets/users.xml");
            var productsInput = File.ReadAllText("../../../Datasets/products.xml");
            var categoriesInput = File.ReadAllText("../../../Datasets/categories.xml");
            var categoryProductInput = File.ReadAllText("../../../Datasets/categories-products.xml");





            //Console.WriteLine(ImportUsers(db, usersInput));
            //Console.WriteLine(ImportProducts(db, productsInput));
            //Console.WriteLine(ImportCategories(db, categoriesInput));
            //Console.WriteLine(ImportCategoryProducts(db, categoryProductInput));
            //Console.WriteLine(GetProductsInRange(db));
            //Console.WriteLine(GetSoldProducts(db));
            //Console.WriteLine(GetCategoriesByProductsCount(db));
            //Console.WriteLine(GetUsersWithProducts(db));

        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            //StringBuilder sb = new StringBuilder();
            //var namespaces = new XmlSerializerNamespaces();
            //namespaces.Add("", "");

            var users = new UserRootDto
            {
                Count = context.Users.Count(u => u.ProductsSold.Any(p => p.Buyer != null)),
                Users = context.Users
                    .AsEnumerable() // or else inmemory error from judge
                    .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                    .OrderByDescending(u => u.ProductsSold.Count)
                    .Take(10)
                    .Select(u => new UserExportDto
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Age = u.Age,
                        SoldProducts = new ProductSoldRootDto
                        {
                            Count = u.ProductsSold.Count(ps => ps.Buyer != null),
                            Products = u.ProductsSold
                                .Where(ps => ps.Buyer != null)
                                .Select(ps => new SoldProductsModel
                                {
                                    Name = ps.Name,
                                    Price = ps.Price
                                })
                                .OrderByDescending(p => p.Price)
                                .ToList()
                        }
                    })
                    .ToList()
            };
            var res = XmlConverter.Serialize(users, "Users");

            //XmlSerializer serializer = new XmlSerializer(typeof(UserRootDto), new XmlRootAttribute("Users"));
            //serializer.Serialize(new StringWriter(sb), users, namespaces);
            //return sb.ToString().TrimEnd();

            return res;
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesByProductsCount = context.Categories
                .Select(x => new CategoryExportModel
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count,
                    AveragePrice = x.CategoryProducts.Select(p => p.Product.Price).Average(),
                    TotalRevenue = x.CategoryProducts.Select(p => p.Product.Price).Sum(),
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToList();

            var result = XmlConverter.Serialize(categoriesByProductsCount, "Categories");
            return result;
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            const string root = "Users";

            var soldProducts = context.Users
                      .Where(u => u.ProductsSold.Any() && u.ProductsSold.Any(p => p.Buyer != null))
                      .OrderBy(x => x.LastName)
                      .ThenBy(x => x.FirstName)
                      .Select(u => new UsersExportModel
                      {
                          FirstName = u.FirstName,
                          LastName = u.LastName,
                          SoldProducts = u.ProductsSold.Where(p => p.Buyer != null).Select(p => new SoldProductsModel
                          {
                              Name = p.Name,
                              Price = p.Price
                          })
                                 .ToList()
                      })
                 .Take(5)
                 .ToList();

            //var result = XmlConverter.Serialize<List<UsersExportModel>>(soldProducts , root);
            var result = XmlConverter.Serialize(soldProducts, root);
            return result;
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            const string root = "Products";

            var productsInRange = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Select(x => new ProductsExprotModel
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName
                })
                .Take(10)
                .ToList();

            var result = XmlConverter.Serialize<List<ProductsExprotModel>>(productsInRange, root);
            return result;
        }



        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            const string root = "CategoryProducts";
            var catProdModel = XmlConverter.Deserializer<CategoryProductInputModel>(inputXml, root);
            var categoryProducts = catProdModel.Select(x => new CategoryProduct
            {
                CategoryId = x.CategoryId,
                ProductId = x.ProductId
            })
                .ToList();

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            const string root = "Categories";
            var categoriesModel = XmlConverter.Deserializer<CategoriesInputModel>(inputXml, root);

            var categories = categoriesModel.Select(x => new Category
            {
                Name = x.Name,
            })
                .ToList();

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            const string root = "Products";
            var productsModel = XmlConverter.Deserializer<ProductInputModel>(inputXml, root);

            var products = productsModel.Select(x => new Product
            {
                Name = x.Name,
                Price = x.Price,
                BuyerId = x.BuyerId,
                SellerId = x.SellerId,
            })
                .ToList();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            const string root = "Users";

            var usersModel = XmlConverter.Deserializer<UserInputModel>(inputXml, root);

            var users = usersModel.Select(x => new User
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Age = x.Age,
            })
                .ToList();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
        private static void ResetDatabase(ProductShopContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Db was successfully deleted!");

            db.Database.EnsureCreated();
            Console.WriteLine("Db was successfully created!");
        }
    }
}