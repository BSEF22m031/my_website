using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
namespace semester_project_2.Controllers
{
    public class UpcomingRegisterController : Controller
    {
        [HttpGet]
        public IActionResult upcomingRegister(string electionName)
        {
            ViewBag.ElectionName = electionName;
            ViewBag.Message = null;
            return View();
        }

        [HttpPost]
        public IActionResult upcomingRegister(string CNIC, string electionName)
        {
            try
            {
                string username = Request.Cookies[electionName];
                if(username != null)
                {
                    ViewBag.x = "yes";
                    ViewBag.Message = "Submitted";
                    string query = "SELECT COUNT(*) FROM ProvisionalElectionInPunjab WHERE CNIC = @CNIC";
                 int userExists = 0;

                 using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ElectionSystem;Integrated Security=True"))
                 {
                     conn.Open();
                     using (SqlCommand cmd = new SqlCommand(query, conn))
                     {
                         cmd.Parameters.AddWithValue("@CNIC", CNIC);
                         userExists = (int)cmd.ExecuteScalar();
                     }
                 }

                    if (userExists > 0)
                     {
                         ViewBag.x = "yes";
                         ViewBag.Message = "Submitted";
                     }
                }
                else
                {
                    Response.Cookies.Append(electionName, CNIC, new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddDays(10),
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict
                    });
                    
                    
                        string insertQuery = "INSERT INTO ProvisionalElectionInPunjab (CNIC) VALUES (@CNIC)";
                        using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ElectionSystem;Integrated Security=True"))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@CNIC", CNIC);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        ViewBag.x = "no";
                        ViewBag.Message = "Submitted";
                    
                    
                }

                     

                    return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: " + ex.Message;
                return View();
            }
        }
     }
}
