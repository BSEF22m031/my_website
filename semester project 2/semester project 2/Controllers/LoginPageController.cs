using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace semester_project_2.Controllers
{
    public class LoginPageController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            string query = "SELECT COUNT(*) FROM [User] WHERE Username = @Username AND PasswordHash = @PasswordHash";
            int userExists = 0;
            
            using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ElectionSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@PasswordHash", password);

                    userExists = (int)cmd.ExecuteScalar();
                }
                

                if (userExists ==1)
                {
                    Response.Cookies.Append("Username", username, new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddHours(1),  
                        HttpOnly = true,  
                        Secure = true,   
                        SameSite = SameSiteMode.Strict
                    });
                    
                    

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["NotExistMessage"] = "User not registered";
                    return RedirectToAction("signup", "SignUp");
                }
            }
        }
    }
}
