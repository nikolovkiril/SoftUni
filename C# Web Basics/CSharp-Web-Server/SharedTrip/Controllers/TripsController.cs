namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SharedTrip.Data;
    using SharedTrip.Data.Models;
    using SharedTrip.Models.Trips;
    using SharedTrip.Services;
    using System;
    using System.Globalization;
    using System.Linq;

    public class TripsController : Controller
    {
        private readonly IValidator validator;
        private readonly SharedTripDbContext db;

        public TripsController(
            IValidator validator,
            SharedTripDbContext db)
        {
            this.validator = validator;
            this.db = db;
        }

        [Authorize]
        public HttpResponse All()
        {
            var tripQuery = this.db
                .Trips
                .AsQueryable();

            var trip = tripQuery
                .Select(t => new ViewTripsFormModel
                {
                    Id = t.Id,
                    Description = t.Description,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Seats = t.Seats,
                    ImagePath = t.ImagePath
                })
                .ToList();

            return View(trip);
        }

        [Authorize]
        public HttpResponse Add() => View();

        [HttpPost]
        [Authorize]
        public HttpResponse Add(AddTripFormModel model)
        {
            var modelErrors = this.validator.ValidateTrip(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            DateTime date;
            DateTime.TryParseExact(
                model.DepartureTime,
                "dd'.'MM'.'yyyy HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out date);

            var trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = date,
                ImagePath = model.ImagePath,
                Seats = model.Seats,
                Description = model.Description,
            };

            this.db.Trips.Add(trip);

            this.db.SaveChanges();

            var userTrip = new UserTrip
            {
                TripId = trip.Id,
                UserId = this.User.Id
            };

            this.db.UserTrips.Add(userTrip);

            this.db.SaveChanges();

            return Redirect("/Trips/All");
        }
        [Authorize]
        public HttpResponse Details(string tripId)
        {
            if (!this.db.Trips.Any(t => t.Id == tripId))
            {
                return Error("Trip no longer exist.");
            }

            var trip = this.db
                 .Trips
                 .Where(t => t.Id == tripId)
                 .Select(t => new ViewTripsFormModel
                 {
                     Id = tripId,
                     DepartureTime = t.DepartureTime.ToString("dd'.'MM'.'yyyy HH:mm"),
                     StartPoint = t.StartPoint,
                     EndPoint = t.EndPoint,
                     Description = t.Description,
                     ImagePath = t.ImagePath,
                     Seats = t.Seats,
                 })
                 .FirstOrDefault();

            return View(trip);
        }

        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {
            var trip = this.db.Trips.FirstOrDefault(t => t.Id == tripId);
                       
            var userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = this.User.Id
            };

            if (!this.db.UserTrips.Any(u => u.UserId == this.User.Id && u.TripId == tripId) && trip.Seats > 0)
            {
                trip.Seats -= 1;
                this.db.UserTrips.Add(userTrip);
                this.db.SaveChanges();
            }
            return Redirect("/Trips/All");
        }
    }
}
