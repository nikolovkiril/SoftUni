namespace VaporStore.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var gamesByGenres = context.Genres
                .ToList()
                .Where(x => genreNames.Contains(x.Name))
                .Select(x => new
                {
                    Id = x.Id,
                    Genre = x.Name,
                    Games = x.Games
                    .Where(g => g.Purchases.Count >= 1)
                    .Select(g => new
                    {
                        Id = g.Id,
                        Title = g.Name,
                        Developer = g.Developer.Name,
                        Tags = string.Join(", ", g.GameTags.Select(gt => gt.Tag.Name)),
                        Players = g.Purchases.Count
                    })
                    .OrderByDescending(g => g.Players)
                    .ThenBy(g => g.Id)
                    .ToList(),
                    TotalPlayers = x.Games.Sum(g => g.Purchases.Count)
                })
                .OrderByDescending(g => g.TotalPlayers)
                .ThenBy(g => g.Id)
                .Take(2)
                .ToList();

            var json = JsonConvert.SerializeObject(gamesByGenres, Formatting.Indented);

            return json;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            PurchaseType purchaseTypeEnum = Enum.Parse<PurchaseType>(storeType);

            ExportUserModel[] usersDtos = context.Users
                .ToArray()
                .Where(x => x.Cards.Any(c => c.Purchases.Any()))
                .Select(u => new ExportUserModel
                {
                    UserName = u.Username,
                    Purchase = context.Purchases
                    .ToList()
                    .Where(p => p.Card.User.Username == u.Username && p.Type == purchaseTypeEnum)
                    .OrderBy(p => p.Date)
                    .Select(p => new ExportPurchasesByTypeModel
                    {
                        CardNumber = p.Card.Number,
                        Cvc = p.Card.Cvc,
                        Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                        Game = new ExportGameModel
                        {
                            Name = p.Game.Name,
                            GenreName = p.Game.Genre.Name,
                            Price = p.Game.Price
                        }
                    })
                    .ToArray(),
                    TotalSpent = context
                    .Purchases
                    .ToList()
                    .Where(p => p.Card.User.Username == u.Username && p.Type == purchaseTypeEnum)
                    .Sum(p => p.Game.Price)
                })
                .Where(u => u.Purchase.Length > 0)
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.UserName)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportUserModel[]), new XmlRootAttribute("Users"));

            using (StringWriter writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, usersDtos, namespaces);
            }

            return sb.ToString().Trim();
        }
    }
}