namespace BattleCards.Data
{
    public class DataConstants
    {
        public const int UsernameMaxLenght = 20;
        public const int UsernameMinLenght = 5;
        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";


        public const int PasswordMaxLenght = 20;
        public const int PasswordMinLenght = 6;

        public const int CardMaxLenght = 15;
        public const int CardMinLenght = 5;
        public const int DescriptionMaxLenght = 200;

        public const string CardTypeTough = "Tough";
        public const string CardTypeChallenger = "Challenger";
        public const string CardTypeElusive = "Elusive";
        public const string CardTypeOverwhelm = "Overwhelm";
        public const string CardTypeLifesteal = "Lifesteal";
        public const string CardTypeEphemeral = "Ephemeral";
        public const string CardTypeFearsome = "Fearsome";

    }
}
