using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using semester_project_2.Models;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace semester_project_2.Controllers
{
    public class SignUp : Controller
    {
        [HttpGet]
        public IActionResult signup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult signup(string fullname, string email, string username, string idNumber, string password)
        {
            try
            {
                string checkUsernameQuery = "SELECT COUNT(*) FROM [User] WHERE IDNumber = @IDNumber";
                int usernameExists = 0;

                using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ElectionSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(checkUsernameQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDNumber", idNumber);
                        usernameExists = (int)cmd.ExecuteScalar();
                    }
                }

                if (usernameExists > 0)
                {
                    ViewBag.ErrorMessage = "Username already exists. Please choose another one.";
                    return View();
                }
                if (username.ToLower() == "admin")
                {
                    ViewBag.Message = "Please change your username. 'admin' is not allowed.";
                }
                

                string query = "INSERT INTO [User] (FullName, Email, Username, IDNumber, PasswordHash) VALUES (@FullName, @Email, @Username, @IDNumber, @PasswordHash)";

                using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ElectionSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", fullname);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@IDNumber", idNumber);
                        cmd.Parameters.AddWithValue("@PasswordHash", password);

                        cmd.ExecuteNonQuery();
                    }
                }

                TempData["SignupSuccessMessage"] = "User registered successfully!";
             
               return RedirectToAction("Login", "LoginPage");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                TempData["SignupErrorMessage"] = "Error: " + ex.Message;
                return View();
            }
        }

    }
}
