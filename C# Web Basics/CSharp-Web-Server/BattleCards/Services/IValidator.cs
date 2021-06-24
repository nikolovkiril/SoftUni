namespace BattleCards.Services
{
    using System.Collections.Generic;
    using BattleCards.Models.Cards;
    using BattleCards.Models.Users;

    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterFormModel model);
        ICollection<string> ValidateCard(CreateCardModel model);
    }
}
