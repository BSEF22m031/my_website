using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using web_lab_06.Models;
using Microsoft.Data.SqlClient;

namespace web_lab_06.Controllers
{
    public class UserDetailsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                // Get connection string from appsettings.json
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"resturant management system\";Integrated Security=True;Connect Timeout=30;Encrypt=False;";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO [User] (Username, Password, BillingAddress, PhoneNumber) VALUES (@Username, @Password, @BillingAddress, @PhoneNumber)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@BillingAddress", user.BillingAddress);
                    cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                // After data is inserted, redirect to a success page or back to the form
                //return RedirectToAction("Success");
            }

            // If model validation fails, stay on the form page
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
            // Connection string to the database (replace with your actual connection string)
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"resturant management system\";Integrated Security=True;Connect Timeout=30;Encrypt=False;";
            // SQL query to check if a user with the provided username and password exists
            string query = "SELECT COUNT(*) FROM [User] WHERE Username = @Username AND Password = @Password";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@Password", Password);

                conn.Open();
                int userExists = (int)cmd.ExecuteScalar(); // Returns the count of matching rows

                if (userExists > 0)
                {
                    // Redirect to Welcome/Index if the user is authenticated
                    return RedirectToAction("Index", "Wellcome", new { username = Username });
                }
                else
                {
                    // Stay on login page with an error message if authentication fails
                    ViewBag.ErrorMessage = "Invalid username or password!";
                    return View();
                }
            }
        }
        
    }
}

