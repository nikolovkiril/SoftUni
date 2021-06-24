using System;
using Microsoft.Data.SqlClient;

namespace _04.Add_Minion 
{
    class Program
    {
        const string connectionString = 
            "Server=.\\SQLEXPRESS ;Database=MinionsDB;Integrated Security=true";
        static void Main(string[] args)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            Console.WriteLine("Please add a Minion info:  ");
            var minion = Console.ReadLine().Split();
            var minionName = minion[0];
            var minionAge = int.Parse(minion[1]);
            var minionTown = minion[2];

            //Bob 14 Berlin

            Console.WriteLine("Please add a Villain name : ");
            var villain = Console.ReadLine();
            var villainName = villain;

            //Gru

            int townId = 0;

            
            using (sqlConnection)
            {
                SqlCommand checkIfTownExists = new SqlCommand("SELECT * FROM TOWNS WHERE Name = @TownName", sqlConnection);
                checkIfTownExists.Parameters.AddWithValue("@TownName", minionTown);
                var reader = checkIfTownExists.ExecuteReader();

                using (reader)
                {
                    if (!reader.Read())
                    {
                        SqlCommand inputTown = new SqlCommand("INSERT INTO Towns(Name) VALUES (@townName)", sqlConnection);
                        inputTown.Parameters.AddWithValue("@TownName", minionTown);
                        reader.Close();
                        inputTown.ExecuteNonQuery();
                        Console.WriteLine($"Town <{minionTown}> was added to the database.");
                    }
                }
                reader = checkIfTownExists.ExecuteReader();
                using (reader)
                {
                    reader.Read();
                    townId = (int)reader["Id"];
                }

                SqlCommand checkIfVillainExists = new SqlCommand("SELECT * FROM Villains WHERE Name = @Villain", sqlConnection);
                checkIfVillainExists.Parameters.AddWithValue("@Villain", villainName);
                reader = checkIfVillainExists.ExecuteReader();

                using (reader)
                {
                    if (!reader.Read())
                    {
                        SqlCommand inputVillain = new SqlCommand("INSERT INTO Villains(Name,EvilnessFactorId) VALUES (@villainName, 4)", sqlConnection);
                        inputVillain.Parameters.AddWithValue("@villainName", villainName);
                        reader.Close();
                        inputVillain.ExecuteNonQuery();
                        Console.WriteLine($"Villain <{villainName}> was added to the database.");

                    }
                }

                SqlCommand inputMinionInDB = new SqlCommand("INSERT INTO Minions(Name,Age,TownId) VALUES (@name, @age, @townId) ", sqlConnection);
                inputMinionInDB.Parameters.AddWithValue("@name", minionName);
                inputMinionInDB.Parameters.AddWithValue("@age", minionAge);
                inputMinionInDB.Parameters.AddWithValue("@townId", townId);
                inputMinionInDB.ExecuteNonQuery();

                SqlCommand getMinionId = new SqlCommand("SELECT Id FROM Minions WHERE Name = @name AND Age = @age", sqlConnection);
                getMinionId.Parameters.AddWithValue("@name", minionName);
                getMinionId.Parameters.AddWithValue("@age", minionAge);

                SqlCommand getVillainId = new SqlCommand("SELECT Id FROM Villains WHERE Name = @name", sqlConnection);
                getVillainId.Parameters.AddWithValue("@name", villainName);
                int villainId = (int)getVillainId.ExecuteScalar();
                int minionId = (int)getMinionId.ExecuteScalar();


                SqlCommand inputIntoMinionsVillain = new SqlCommand("INSERT INTO MinionsVillains(MinionId,VillainId) VALUES (@minionId, @villainId)", sqlConnection);
                inputIntoMinionsVillain.Parameters.AddWithValue("@minionId", minionId);
                inputIntoMinionsVillain.Parameters.AddWithValue("@villainId", villainId);
                inputIntoMinionsVillain.ExecuteNonQuery();

                Console.WriteLine($"Successfully added <{minionName}> to be minion of <{villainName}>.");
            }
        }
    }
}
