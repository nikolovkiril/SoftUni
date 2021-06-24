namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		public const string ErrorMessage = "Invalid Data";

		public const string SuccessfullyImportedGame = "Added {0} ({1}) with {2} tags";

		public const string SuccessfullyImportedUser = "Imported {0} with {1} cards";

		public const string SuccessfullyImportedPurchase = "Imported {0} for {1}";

		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			StringBuilder sb = new StringBuilder();

			var gamesDtos = JsonConvert.DeserializeObject<ImportGamesModel[]>(jsonString);

			List<Game> games = new List<Game>();
			List<Developer> developers = new List<Developer>();
			List<Genre> genres = new List<Genre>();
			List<Tag> tags = new List<Tag>();

            foreach (var gameDto in gamesDtos)
            {
                if (!IsValid(gameDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                DateTime releaseDate;

                bool isReleaseDateValid = DateTime.TryParseExact(gameDto.ReleaseDate, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate);

                if (!isReleaseDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (gameDto.Tags.Length == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var game = new Game()
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = releaseDate
                };

                Developer gameDev = developers
                    .FirstOrDefault(gd => gd.Name == gameDto.Developer);

                if (gameDev == null)
                {
                    var newGameDev = new Developer()
                    {
                        Name = gameDto.Developer
                    };
                    developers.Add(newGameDev);

                    game.Developer = newGameDev;
                }
                else
                {
                    game.Developer = gameDev;
                }

                var gameGenre = genres
                    .FirstOrDefault(g => g.Name == gameDto.Genre);

                if (gameGenre == null)
                {
                    var newGenre = new Genre()
                    {
                        Name = gameDto.Genre
                    };

                    genres.Add(newGenre);
                    game.Genre = newGenre;
                }
                else
                {
                    game.Genre = gameGenre;
                }

                foreach (var tag in gameDto.Tags)
                {
                    if (String.IsNullOrEmpty(tag))
                    {
                        continue;
                    }
                    var gameTag = tags
                        .FirstOrDefault(t => t.Name == tag);
                    if (gameTag == null)
                    {
                        var newGameTag = new Tag()
                        {
                            Name = tag
                        };
                        tags.Add(newGameTag);

                        game.GameTags.Add(new GameTag()
                        {
                            Game = game,
                            Tag = newGameTag
                        });
                    }
                    else
                    {
                        game.GameTags.Add(new GameTag()
                        {
                            Game = game,
                            Tag = gameTag
                        });
                    }
                }
                if (game.GameTags.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                games.Add(game);
                sb.AppendLine(String.Format(SuccessfullyImportedGame, game.Name, game.Genre.Name, game.GameTags.Count));
            }
            context.Games.AddRange(games);

            context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
            StringBuilder sb = new StringBuilder();

            var userDtos = JsonConvert.DeserializeObject<ImportUsersModel[]>(jsonString);

            var users = new List<User>();

            foreach (var userDto in userDtos)
            {
                if (!IsValid(userDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var cards = new List<Card>();
                bool isCardValid = true;

                foreach (var cardModel in userDto.Cards)
                {
                    if (!IsValid(cardModel))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    Object cardType;
                    bool isCardTypeValid = Enum.TryParse(typeof(CardType), cardModel.Type, out cardType);

                    if (!isCardTypeValid)
                    {
                        isCardValid = false;
                        break;
                    }

                    var type = (CardType)cardType;

                    cards.Add(new Card()
                    {
                        Number = cardModel.Number,
                        Cvc = cardModel.Cvc,
                        Type = type
                    });
                }
                if (!isCardValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (cards.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var user = new User()
                {
                    Username = userDto.Username,
                    FullName = userDto.FullName,
                    Email = userDto.Email,
                    Age = userDto.Age,
                    Cards = cards
                };

                users.Add(user);
                sb.AppendLine(String.Format(SuccessfullyImportedUser, user.Username, user.Cards.Count));
            }
            context.Users.AddRange(users);

            context.SaveChanges();

            return sb.ToString().TrimEnd(); 
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPurchaseModel[]), new XmlRootAttribute("Purchases"));

            using StringReader stringReader = new StringReader(xmlString);

            var purchaseDtos = (ImportPurchaseModel[])xmlSerializer.Deserialize(stringReader);

            List<Purchase> purchases = new List<Purchase>();

            foreach (ImportPurchaseModel purchaseDto in purchaseDtos)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                object purchaseTypeObj;
                bool isPurchaseTypeValid =
                    Enum.TryParse(typeof(PurchaseType), purchaseDto.PurchaseType, out purchaseTypeObj);

                if (!isPurchaseTypeValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                PurchaseType purchaseType = (PurchaseType)purchaseTypeObj;

                DateTime date;
                bool isDateValid = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

                if (!isDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Card card = context
                    .Cards
                    .FirstOrDefault(c => c.Number == purchaseDto.CardNumber);

                if (card == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Game game = context
                    .Games
                    .FirstOrDefault(g => g.Name == purchaseDto.GameTitle);

                if (game == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Purchase p = new Purchase()
                {
                    Type = purchaseType,
                    Date = date,
                    ProductKey = purchaseDto.Key,
                    Game = game,
                    Card = card
                };

                purchases.Add(p);
                sb.AppendLine(String.Format(SuccessfullyImportedPurchase, p.Game.Name, p.Card.User.Username));
            }

            context.Purchases.AddRange(purchases);
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