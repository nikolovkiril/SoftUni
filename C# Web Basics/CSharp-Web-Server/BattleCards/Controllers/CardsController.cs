namespace BattleCards.Controllers
{
    using BattleCards.Data;
    using BattleCards.Data.Models;
    using BattleCards.Models.Cards;
    using BattleCards.Services;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;

    public class CardsController : Controller
    {
        private readonly IValidator validator;
        private readonly BattleCardsDbContext db;

        public CardsController(
            IValidator validator,
            BattleCardsDbContext db)
        {
            this.validator = validator;
            this.db = db;
        }
        [Authorize]
        public HttpResponse All()
        {
            var cardQuery = this.db
                .Cards
                .AsQueryable();

            var card = cardQuery
                .Select(c => new CardViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Attack = c.Attack,
                    Health = c.Health,
                    Image = c.ImageUrl,
                    Keyword = c.Keyword
                })
                .ToList();

            return View(card);
        }

        [Authorize]
        public HttpResponse Add() => View();

        [Authorize]
        [HttpPost]
        public HttpResponse Add(CreateCardModel model)
        {
            var modelErrors = this.validator.ValidateCard(model);

            if (modelErrors.Any())
            {
                return Redirect("/Cards/Add");
            }

            var card = new Card
            {
                Attack = model.Attack,
                Description = model.Description,
                Health = model.Health,
                ImageUrl = model.Image,
                Keyword = model.Keyword,
                Name = model.Name,
            };

            this.db.Cards.Add(card);

            this.db.SaveChanges();

            var cardId = card.Id;

            var userCard = new UserCard
            {
                CardId = cardId,
                UserId = this.User.Id
            };
            this.db.UserCards.Add(userCard);

            this.db.SaveChanges();

            return Redirect("/Cards/All");
        }

        [Authorize]
        public HttpResponse Collection()
        {
            var cardQuery = this.db
                 .UserCards
                 .AsQueryable();

            var card = cardQuery
                .Where(x => x.UserId == this.User.Id)
                .Select(uc => uc.Card)
                .Select(c => new CardViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Attack = c.Attack,
                    Health = c.Health,
                    Image = c.ImageUrl,
                    Keyword = c.Keyword
                })
                .ToList();

            return View(card);
        }

        [Authorize] 
        public HttpResponse AddToCollection(int cardId)
        {
            var isCardIdExist = db.Cards.Any(x => x.Id == cardId);

            if (!isCardIdExist)
            {
                return BadRequest();
            }

            var userCard = new UserCard
            {
                CardId = cardId,
                UserId = this.User.Id
            };

            var isMyCard = db.UserCards.Any(x => x.CardId == cardId);
            if (isCardIdExist)
            {
                return Redirect("/Cards/All");
            }           
            this.db.UserCards.Add(userCard);

            this.db.SaveChanges();

            return Redirect("/Cards/All"); ;
        }

        [Authorize] 
        public HttpResponse RemoveFromCollection(int cardId)
        {
            var card = db.Cards.FirstOrDefault(x => x.Id == cardId);

            if (card == null)
            {
                return BadRequest();
            }
            var userCard = this.db.UserCards.Where(x => x.CardId == card.Id && x.UserId == this.User.Id).FirstOrDefault();

            this.db.UserCards.Remove(userCard);

            this.db.SaveChanges();

            return Redirect("/Cards/Collection"); ;
        }

    }
}
