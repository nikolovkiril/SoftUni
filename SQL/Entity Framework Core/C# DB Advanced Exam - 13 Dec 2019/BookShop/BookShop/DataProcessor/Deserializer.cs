namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ProductShop.XmlHelper;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            const string root = "Books";
            var importBooksModel = XmlConverter.Deserializer<BookModel>(xmlString, root);

            List<Book> books = new List<Book>();

            StringBuilder sb = new StringBuilder();

            foreach (var bookModel in importBooksModel)
            {
                if (!IsValid(bookModel))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var date = DateTime.ParseExact(bookModel.PublishedOn , "MM/dd/yyyy", CultureInfo.InvariantCulture);

                var book = new Book
                {
                    Name = bookModel.Name,
                    Genre = (Genre)bookModel.Genre,
                    Pages = bookModel.Pages,
                    Price = bookModel.Price,
                    PublishedOn = date
                };
                books.Add(book);
                sb.AppendLine(string.Format(SuccessfullyImportedBook, book.Name, book.Price));
            }

            context.Books.AddRange(books);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var importAuthorsModel = JsonConvert.DeserializeObject<AuthorModel[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            List<Author> authors = new List<Author>();

            foreach (var authorModel in importAuthorsModel)
            {
                if (!IsValid(authorModel))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                bool IsEmailExists = authors
                    .FirstOrDefault(x => x.Email == authorModel.Email) != null;

                if (IsEmailExists)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;   
                }

                var author = new Author
                {
                    FirstName = authorModel.FirstName,
                    LastName = authorModel.LastName,
                    Email = authorModel.Email,
                    Phone = authorModel.Phone
                };

                foreach (var bookModel in authorModel.Books)
                {
                    var book = context.Books.Find(bookModel.Id);

                    if (book == null)
                    {
                        continue;
                    }

                    author.AuthorsBooks.Add(new AuthorBook
                    {
                        Author = author,
                        Book = book
                    });

                }
                if (author.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                authors.Add(author);
                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, (author.FirstName + " " + author.LastName), author.AuthorsBooks.Count()));
            }

            context.Authors.AddRange(authors);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}