using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
namespace semester_project_2.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public IActionResult contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult contact(string Name, string Email, string Subject, string Message)
        {
            try
            {
                string query = "INSERT INTO Contact (Name, Email, Subject, Message) VALUES (@Name, @Email, @Subject, @Message)";

                using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ElectionSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"))
                {
                    conn.Open(); 

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", Name);
                        cmd.Parameters.AddWithValue("@Email", Email);
                        cmd.Parameters.AddWithValue("@Subject", Subject);
                        cmd.Parameters.AddWithValue("@Message", Message);

                        cmd.ExecuteNonQuery();
                    }
                }

                
                TempData["ContactSuccessMessage"] = "Message sent successfully!";

                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                TempData["ContactErrorMessage"] = "Error: " + ex.Message;

                return View();
            }


            return View();
        }

    }
}


