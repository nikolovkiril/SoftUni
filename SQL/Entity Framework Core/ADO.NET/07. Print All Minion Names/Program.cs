using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Print_All_Minion_Names
{
    class Program
    {
        const string connectionString =
            "Server=.\\SQLEXPRESS ;Database=MinionsDB;Integrated Security=true";

        private static SqlConnection connection = new SqlConnection(connectionString);

        static void Main(string[] args)
        {
            connection.Open();
            using (connection)
            {
                string queryText = @"SELECT Name FROM Minions";
                SqlCommand sqlCommand = new SqlCommand(queryText, connection);
                List<string> names = new List<string>();
                using (sqlCommand)
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        names.Add((string)reader["Name"]);
                    }

                    while (names.Count != 0)
                    {
                        Console.WriteLine(names[0]); ;
                        names.RemoveAt(0);
                        if (names.Count == 0)
                            break;

                        Console.WriteLine(names.Last());
                        names.RemoveAt(names.Count - 1);

                    }
                }
            }
        }
    }
}