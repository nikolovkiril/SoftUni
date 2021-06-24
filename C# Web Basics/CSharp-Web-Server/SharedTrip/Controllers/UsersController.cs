﻿namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SharedTrip.Data;
    using SharedTrip.Data.Models;
    using SharedTrip.Models.Users;
    using SharedTrip.Services;
    using System.Linq;

    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly IPasswordHasher passwordHasher;
        private readonly SharedTripDbContext db;

        public UsersController(
            IValidator validator,
            IPasswordHasher passwordHasher,
            SharedTripDbContext db)
        {
            this.validator = validator;
            this.passwordHasher = passwordHasher;
            this.db = db;
        }



        public HttpResponse Login() => this.View();

        //[HttpPost]
        //public HttpResponse Login(LoginInputModel input)
        //{

        //}

        public HttpResponse Register() => View();

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel model)
        {
            var modelErrors = this.validator.ValidateUser(model);

            if (this.db.Users.Any(u => u.Username == model.Username))
            {
                modelErrors.Add($"User with '{model.Username}' username already exists.");
            }

            if (this.db.Users.Any(u => u.Email == model.Email))
            {
                modelErrors.Add($"User with '{model.Email}' e-mail already exists.");
            }

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var user = new User
            {
                Username = model.Username,
                Password = this.passwordHasher.HashPassword(model.Password),
                Email = model.Email
            };

            db.Users.Add(user);

            db.SaveChanges();

            return Redirect("/Users/Login");
        }
    }
}
