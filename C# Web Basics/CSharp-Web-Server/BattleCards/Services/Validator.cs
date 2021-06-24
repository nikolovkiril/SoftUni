namespace BattleCards.Services
{
    using BattleCards.Models.Cards;
    using BattleCards.Models.Users;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    using static Data.DataConstants;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(RegisterFormModel user)
        {
            var errors = new List<string>();

            if (user.Username == null || user.Username.Length < UsernameMinLenght || user.Username.Length > UsernameMaxLenght)
            {
                errors.Add($"Username '{user.Username}' is not valid. It must be between {UsernameMinLenght} and {UsernameMaxLenght} characters long.");
            }

            if (!Regex.IsMatch(user.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email {user.Email} is not a valid e-mail address.");
            }

            if (user.Password == null || user.Password.Length < PasswordMinLenght || user.Password.Length > PasswordMaxLenght)
            {
                errors.Add($"The provided password is not valid. It must be between {PasswordMinLenght} and {PasswordMaxLenght} characters long.");
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

        public ICollection<string> ValidateCard(CreateCardModel card)
        {
            var errors = new List<string>();

            if (card.Name == null || card.Name.Length < CardMinLenght || card.Name.Length > CardMaxLenght)
            {
                errors.Add($"Card name '{card.Name}' is not valid. It must be between {CardMinLenght} and {CardMaxLenght} characters long.");
            }

            if (card.Image == null || !Uri.IsWellFormedUriString(card.Image, UriKind.Absolute))
            {
                errors.Add($"Image '{card.Image}' is not valid. It must be a valid URL.");
            }

            //if (card.Keyword != CardTypeChallenger || card.Keyword != CardTypeElusive || 
            //    card.Keyword != CardTypeEphemeral || card.Keyword != CardTypeFearsome || 
            //    card.Keyword != CardTypeLifesteal || card.Keyword != CardTypeOverwhelm || 
            //    card.Keyword != CardTypeTough )
            //{
            //    errors.Add("Invalid Card Type.");
            //}

            if (card.Attack < 0 || card.Health < 0)
            {
                errors.Add("Attack and Health cannot be negative");
            }

            if (card.Description.Length > DescriptionMaxLenght)
            {
                errors.Add($"Description has max lenght {DescriptionMaxLenght} characters");
            }

            return errors;
        }
    }
}
