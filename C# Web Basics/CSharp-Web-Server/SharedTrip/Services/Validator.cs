namespace SharedTrip.Services
{
    using System;
    using System.Linq;
    using SharedTrip.Models.Users;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    using static Data.DataConstants;
    using SharedTrip.Models.Trips;
    using System.Globalization;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(RegisterUserFormModel user)
        {
            var errors = new List<string>();

            if (user.Username == null || user.Username.Length < UsernameMinLength || user.Username.Length > UsernameMaxLength)
            {
                errors.Add($"Username '{user.Username}' is not valid. It must be between {UsernameMinLength} and {UsernameMaxLength} characters long.");
            }

            if (!Regex.IsMatch(user.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email {user.Email} is not a valid e-mail address.");
            }

            if (user.Password == null || user.Password.Length < PasswordMinLength || user.Password.Length > PasswordMaxLength)
            {
                errors.Add($"The provided password is not valid. It must be between {PasswordMinLength} and {PasswordMaxLength} characters long.");
            }

            if (user.Password.Any(x => x == ' '))
            {
                errors.Add($"The provided password cannot contain whitespaces.");
            }

            if (user.Password != user.ConfirmPassword)
            {
                errors.Add($"Password and its confirmation are different.");
            }

            return errors;
        }

        public ICollection<string> ValidateTrip(AddTripFormModel trip)
        {
            var errors = new List<string>();

            if (trip.Description.Length > TripDescriptionLength)
            {
                errors.Add($"Description can not be more then {TripDescriptionLength} characters.");
            }

            if (trip.Seats < MinAvailableSeats || trip.Seats > MaxAvailableSeats)
            {
                errors.Add($"Seats can not be less then {MinAvailableSeats} and more then {MaxAvailableSeats}.");
            }

            DateTime date;

            if (!DateTime.TryParseExact(
                trip.DepartureTime, 
                "dd'.'MM'.'yyyy HH:mm", 
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out date))
            {
                errors.Add($"DepartureTime must be in format 'dd/MM/yyyy HH:mm'.");
            }
            return errors;
        }
    }
}
