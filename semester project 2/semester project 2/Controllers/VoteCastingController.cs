using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;


namespace semester_project_2.Controllers
{
    public class VoteCastingController : Controller
    {
        [HttpGet]
        public IActionResult voteCasting(int id)
        {
            ViewBag.Message = null;
            ViewBag.ElectionId = id;

            return View();
        }
        [HttpPost]
        public IActionResult voteCasting(string CNIC, int ElectionId)
        {
            try
            {
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
                    return RedirectToAction("vote", "Vote", new { id = ElectionId });
                }
                else
                {
                    ViewBag.x = "no";
                    ViewBag.Message = "Submitted";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: " + ex.Message;
                return View();
            }
        }


    }
}

