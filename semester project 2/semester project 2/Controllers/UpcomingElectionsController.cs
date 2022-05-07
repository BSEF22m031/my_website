using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using semester_project_2.Models;

namespace semester_project_2.Controllers
{
    public class UpcomingElectionsController : Controller
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ElectionSystem;Integrated Security=True;";

        public IActionResult upcomingElection()
        {
            List<Election> elections = new List<Election>();

            string query = "SELECT ElectionID, ElectionName, Description, Date FROM Election WHERE Status = 'inactive'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        elections.Add(new Election
                        {
                            ElectionID = (int)reader["ElectionID"],
                            ElectionName = reader["ElectionName"].ToString(),
                            Description = reader["Description"].ToString(),
                            Date = (DateTime)reader["Date"]
                        });
                    }
                }
            }

            return View(elections);
        }
    }
}
