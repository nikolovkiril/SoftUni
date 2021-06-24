namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            Console.WriteLine(RemoveBooks(db)); 
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Copies < 4200)
                .ToList();

            context.Books.RemoveRange(books);
            context.SaveChanges();
            return books.Count;
        }
        public static void IncreasePrices(BookShopContext context)
        {
            var increasePrices = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in increasePrices)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var mostRecentBooks = context.Categories
                .Select(x => new
                {
                    x.Name,
                    Books = x.CategoryBooks.Select(b => new
                    {
                        b.Book.Title,
                        b.Book.ReleaseDate.Value
                    })
                    .OrderByDescending(b => b.Value)
                    .Take(3)
                    .ToList()
                })
                .OrderBy(x => x.Name)
                .ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var cat in mostRecentBooks)
            {
                sb.AppendLine($"--{cat.Name}");
                foreach (var book in cat.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.Value.Year})");
                }
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var totalProfitByCategory = context.Categories
                .Select(x => new
                {
                    x.Name,
                    Profit = x.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies)
                })
                .OrderByDescending(x => x.Profit)
                .ToList();

            var result = string.Join(Environment.NewLine, totalProfitByCategory.Select(x => $"{x.Name} ${x.Profit}"));
            return result;

        }
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var copiesByAuthor = context.Authors
                .Select(x => new
                {
                    AuthorName = x.FirstName + " " + x.LastName,
                    Copies = x.Books.Sum(x => x.Copies)
                })
                .OrderByDescending(x => x.Copies)
                .ToList();
           
            var result = string.Join(Environment.NewLine, copiesByAuthor.Select(x => $"{x.AuthorName} - {x.Copies}"));
            return result;
        }
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var countBooks = context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .ToList();

            var result = countBooks.Count();
            return result;
        }
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {

            var booksByAuthor = context.Books
                .Where(x => EF.Functions.Like(x.Author.LastName , $"{input}%"))
                .Select(x => new
                {
                    x.Title,
                    AuthorFullName = x.Author.FirstName + " " + x.Author.LastName,
                    x.BookId
                })
                .OrderBy(x => x.BookId)
                .ToList();

            var result = string.Join(Environment.NewLine, booksByAuthor.Select(x => $"{x.Title} ({x.AuthorFullName})"));
            return result;
        }
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var tryInput = input.ToLower();
            var bookTitlesContaining = context.Books
                .Where(x => x.Title.ToLower().Contains(tryInput))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            var result = string.Join(Environment.NewLine, bookTitlesContaining);
            return result;
        }
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorNamesEndingIn = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => new 
                {
                    x.FirstName,
                    x.LastName
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            var result = string.Join(Environment.NewLine, authorNamesEndingIn.Select(x => ($"{x.FirstName} {x.LastName}")));

            return result;
        }
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var dateToCheck = DateTime.ParseExact(date, "dd-MM-yyyy" , CultureInfo.InvariantCulture);

            var booksReleasedBefore = context.Books
                .Where(x => x.ReleaseDate.Value < dateToCheck)
                .Select(x => new
                {
                    x.Title,
                    x.EditionType,
                    x.Price,
                    x.ReleaseDate.Value
                })
                .OrderByDescending(x => x.Value)
                .ToList();

            var result = string.Join(Environment.NewLine, booksReleasedBefore
                .Select(x => ($"{x.Title} - {x.EditionType} - ${x.Price:f2}")));
            return result;
        }
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categoryes = input
                .Split(' ' , StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower());

            var booksByCategory = context.Books
                .Include(x => x.BookCategories)
                .ThenInclude(x => x.Category)
                .ToList()
                .Where(x => x.BookCategories.Any(c => categoryes.Contains(c.Category.Name.ToLower())))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();


            var result = string.Join(Environment.NewLine, booksByCategory);
            return result;
        }
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var booksNotReleasedIn = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .Select(x => new
                {
                    x.Title,
                    x.BookId
                })
                .OrderBy(x => x.BookId)
                .ToList();
            var result = string.Join(Environment.NewLine, booksNotReleasedIn.Select(x => x.Title));

            return result;
        }
        public static string GetBooksByPrice(BookShopContext context)
        {
            var booksByPrice = context.Books
                .Where(x => x.Price > 40)
                .Select(x => new
                {
                    x.Title,
                    x.Price
                })
                .OrderByDescending(x => x.Price)
                .ToList();

            var result = string.Join(Environment.NewLine, booksByPrice.Select(x => $"{x.Title} - ${x.Price:f2}"));

            return result;
        }
        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenEditionBooks = context.Books
                .Where(x => x.EditionType == EditionType.Gold && x.Copies < 5000)
                .Select(x => new
                {
                    x.BookId,
                    x.Title
                })
                .OrderBy(x => x.BookId)
                .ToList();

            var result = string.Join(Environment.NewLine, goldenEditionBooks.Select(x => x.Title));

            return result;
        }
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var age = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                .Where(x => x.AgeRestriction == age)
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }

    }
}
