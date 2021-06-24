using Microsoft.Data.SqlClient;
using System;

namespace _02._Villain_Names
{
    class StartUp
    {
        const string connectionString = 
            "Server=.\\SQLEXPRESS ;Database=MinionsDB;Integrated Security=true";
        static void Main(string[] args)
        {

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using (sqlConnection)
            {
                string queryText = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                     FROM Villains AS v 
                                     JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                     GROUP BY v.Id, v.Name 
                                     HAVING COUNT(mv.VillainId) > 3 
                                     ORDER BY COUNT(mv.VillainId)";

                SqlCommand cmd = new SqlCommand(queryText, sqlConnection);
                using (cmd)
                {
                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        using (reader)
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader["Name"]} - {reader["MinionsCount"]}");
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }
}