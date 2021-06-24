namespace _01.Initial_Setup
{
    using System;
    using System.Linq;
    using Microsoft.Data.SqlClient;
    class Program
    {
        const string sqlConnectionString =
            "Server = .\\SQLEXPRESS;Integrated Security = true; Database = {0}";
        static void Main(string[] args)
        {
            SqlConnection sqlConnection = new SqlConnection(string.Format(sqlConnectionString, "master"));
            sqlConnection.Open();

            using (sqlConnection)
            {
                try
                {
                    CreateDatabase(sqlConnection);
                    Console.WriteLine("Database created successfully!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("There was error creating database!");
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            sqlConnection = new SqlConnection(string.Format(sqlConnectionString, "MinionsDB"));
            sqlConnection.Open();
            using (sqlConnection)
            {
                var createTable = CreateTable();
                int tables = 0;
                try
                {

                    foreach (var query in createTable)
                    {
                        ExecuteNonQueryMethod(sqlConnection, query);
                        tables++;
                    }
                    Console.WriteLine($"{tables} Tables created successfully!");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"There was an error creating table => {tables}!");
                    Console.WriteLine(e.Message);
                }

                var fillTable = FillTable();
                int countQuerys = 0;
                try
                {
                    foreach (var query in fillTable)
                    {
                        ExecuteNonQueryMethod(sqlConnection, query);
                        countQuerys++;
                    }
                    Console.WriteLine("Data inserted successfully!");
                    Console.WriteLine($"{countQuerys} Tables affected");

                }
                catch (Exception e)
                {
                    Console.WriteLine($"There was an error inserting data into table => {countQuerys}!");
                    Console.WriteLine(e.Message);
                }

            }
        }

        private static void ExecuteNonQueryMethod(SqlConnection sqlConnection, string query)
        {
            using (var sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlCommand.ExecuteNonQuery();
            }
        }

        private static void CreateDatabase(SqlConnection sqlConnection)
        {
            string query = "CREATE DATABASE MinionsDB";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }

        private static string[] CreateTable()
        {
            var result = new string[]
            {
                "CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY , Name VARCHAR(MAX))" ,
                "CREATE TABLE Towns (Id INT PRIMARY KEY IDENTITY , Name VARCHAR(MAX) , CountryCode INT REFERENCES Countries(Id))",
                "CREATE TABLE Minions (Id INT PRIMARY KEY IDENTITY , Name VARCHAR(MAX),Age INT , TownId INT REFERENCES Towns(Id))",
                "CREATE TABLE EvilnessFactors (Id INT PRIMARY KEY IDENTITY , Name VARCHAR(MAX))",
                "CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY , Name VARCHAR(MAX),EvilnessFactorId INT REFERENCES EvilnessFactors(Id))",
                "CREATE TABLE MinionsVillains (MinionId INT REFERENCES Minions(Id) ,VillainId INT REFERENCES Villains(Id) , PRIMARY KEY (MinionId,VillainId))"
            };
            return result;
        }

        private static string[] FillTable()
        {
            var result = new string[]
            {
                "INSERT INTO Countries (Name) VALUES ('Bulgaria'),('Scotland'),('Romania'),('Italy'),('France')" ,
                "INSERT INTO Towns (Name,CountryCode) VALUES ('Sofia', 1),('Perth',2),('Bucureste',3),('Rome',4),('Paris',5)",
                "INSERT INTO Minions (Name,Age,TownId) VALUES ('Alabala',12,1),('Hope',14,2),('Nasty',21,4),('Popol',33,3),('Kapa',1,5)",
                "INSERT INTO EvilnessFactors (Name) VALUES ('super good'),('good'),('bad'),('evil'),('super evil')",
                "INSERT INTO Villains (Name,EvilnessFactorId ) VALUES ('Loshite',1),('Naglite',2),('7-te djudjeta',3),('B.B.',5),('Gerb',4)",
                "INSERT INTO MinionsVillains (MinionId,VillainId) VALUES (3,1),(2,2),(1,3),(4,5),(5,4)"
            };
            return result;
        }
    }
}