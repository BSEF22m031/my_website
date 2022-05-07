using Microsoft.AspNetCore.Mvc;
using semester_project_2.Models;
using Microsoft.Data.SqlClient;

namespace semester_project_2.Controllers
{
    
    public class CastVoteController : Controller
    {

        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ElectionSystem;Integrated Security=True;";
        public IActionResult castVote()
        {
            List<Election> elections = new List<Election>();

            string query = "SELECT ElectionID, ElectionName, Description, Date FROM Election WHERE Status = 'active'";

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
