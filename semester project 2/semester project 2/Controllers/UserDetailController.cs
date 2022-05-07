using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using semester_project_2.Models;

namespace semester_project_2.Controllers
{
    public class UserDetailController : Controller
    {
        private readonly string connectionString = "Your_Connection_String_Here";

        [HttpGet]
        public IActionResult userDetail()
        {
            return View(null);
        }

        [HttpPost]
        public IActionResult GetUserDetail(string cnic)
        {
            User user = null;

            using (var connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ElectionSystem;Integrated Security=True;"))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [dbo].[User] WHERE IDNumber = @CNIC", connection);
                command.Parameters.AddWithValue("@CNIC", cnic);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new User
                        {
                            UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                            FullName = reader.GetString(reader.GetOrdinal("FullName")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            Username = reader.GetString(reader.GetOrdinal("Username")),
                            IDNumber = reader.GetString(reader.GetOrdinal("IDNumber")),
                            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                        };
                    }
                }
            }

            if (user == null)
            {
                TempData["Error"] = "No user found with the provided CNIC.";
                return RedirectToAction("UserDetail");
            }

            return View("UserDetail", user);
        }
    }
}

