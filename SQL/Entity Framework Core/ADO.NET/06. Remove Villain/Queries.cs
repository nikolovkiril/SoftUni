namespace _06._Remove_Villain
{
    public class Queries
    {
        public const string FindVillainName = "SELECT Name FROM Villains WHERE Id = @villainId";

        public const string DeleteVillainFromMV = "DELETE FROM MinionsVillains WHERE VillainId = @villainId";

        public const string DeleteVillainFromVillains = "DELETE FROM Villains WHERE Id = @villainId";
    }
}
