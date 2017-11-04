using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _01._WorkPlace
{
    class StartUp
    {
        static void Main()
        {
            var connectionString = @"Server=DESKTOP-ODF3207\SQLEXPRESS;Database=MinionsDB;Integrated Security=True";
            var connection = new SqlConnection(connectionString);
            var villans = new Dictionary<string, int>();

            connection.Open();
            using (connection)
            {
                string query = "SELECT v.Name, COUNT(mv.MinionId) AS [MinionCount] " +
                               "FROM Villains AS v " +
                               "JOIN MinionsVillains AS mv " +   
                               "ON v.Id = mv.VillainId " +
                               "GROUP BY v.Id, v.Name " +
                               "HAVING COUNT(mv.MinionId) > 3 " +
                               "ORDER BY COUNT(mv.MinionId) DESC ";

                var command = new SqlCommand(query, connection);
                var reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        var villanName = (string)reader["Name"];
                        var minionCount = (int) reader["MinionCount"];

                        villans[villanName] = minionCount;

                    }
                }
               
            }

            foreach (var villan in villans)
            {
                Console.WriteLine($"{villan.Key} - {villan.Value}");
            }

        }
    }
}
