using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using semester_project_2.Models;

namespace semester_project_2.Controllers
{
    public class AddElectionController : Controller
    {

        [HttpGet]
        public IActionResult addElection(int candidateCount = 0)
        {
            ViewBag.count = candidateCount;
            return View();
        }

        [HttpPost]
        public IActionResult addElection(string ElectionName, string Description, DateTime ElectionDate, int CandidateCount)
        {
            if (CandidateCount <= 0)
            {
                TempData["ElectionErrorMessage"] = "Please provide a valid number of candidates.";
                return View();
            }
            try
            {
                string query = "INSERT INTO Election (ElectionName, Description, Date) VALUES (@ElectionName, @Description, @Date)";

                using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ElectionSystem;Integrated Security=True;"))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ElectionName", ElectionName);
                        cmd.Parameters.AddWithValue("@Description", Description);
                        cmd.Parameters.AddWithValue("@Date", ElectionDate);

                        cmd.ExecuteNonQuery();
                    }
                }

                TempData["ElectionSuccessMessage"] = "Election added successfully!";
                Response.Cookies.Append("Electionname", ElectionName, new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddHours(1),
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict
                });
                TempData["Key"] = CandidateCount;
                return RedirectToAction("AddCandidates");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                TempData["ElectionErrorMessage"] = "Error: " + ex.Message;
                return View();
            }
        }
        [HttpGet]
        public IActionResult AddCandidates()
        {
            int candidateCount = TempData["Key"] != null ? Convert.ToInt32(TempData["Key"]) : 0;
            ViewBag.Count = candidateCount;

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ElectionSystem;Integrated Security=True;";
            string query = "SELECT CandidateId, Name, Party, PicUrl FROM Candidate";

            List<CandidateModel> candidates = new List<CandidateModel>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        candidates.Add(new CandidateModel
                        {
                            CandidateId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Party = reader.GetString(2),
                            ImageUrl = reader.GetString(3)
                        });
                    }
                }
            }

            ViewBag.Candidates = candidates; 
            return View();
        }
        [HttpPost]
        public IActionResult AddCandidates( List<int> selectedCandidateIds)
        {
            /*//int candidateCount = TempData["Key"] != null ? Convert.ToInt32(TempData["Key"]) : 0;
            if (selectedCandidateIds.Count != candidateCount)
            {
                ModelState.AddModelError(string.Empty, $"You must select exactly {candidateCount} candidates.");
                Console.WriteLine("error2");

                return RedirectToAction("AddCandidates");
            }*/


            string electionName = Request.Cookies["Electionname"];
            Election election1 = GetElectionDetailsByName(electionName); 
            int electionId = election1.ElectionID; 

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ElectionSystem;Integrated Security=True;";
            List<CandidateModel> selectedCandidates = new List<CandidateModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                foreach (var id in selectedCandidateIds)
                {
                    string query = $"SELECT CandidateId, Name, Party, PicUrl FROM Candidate WHERE CandidateId = {id}";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            // Create candidate model
                            CandidateModel candidate = new CandidateModel
                            {
                                CandidateId = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Party = reader.GetString(2),
                                ImageUrl = reader.GetString(3)
                            };
                            selectedCandidates.Add(candidate);

                        }
                        reader.Close();
                    }
                }
                int tempCount = 0;
                foreach (var candidate in selectedCandidates)
                {
                    tempCount++;
                    string insertQuery = @"INSERT INTO ElectionManagement 
                                   (ElectionId,TempCandidateId, CandidateName, CandidateImage, CandidateParty, CandidateVoteNumber,CandidateVoteCount) 
                                   VALUES (@ElectionId,@TempCandidateId, @CandidateName, @CandidateImage, @CandidateParty, @CandidateVoteNumber,@CandidateVoteCount)";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@ElectionId", electionId);
                        insertCmd.Parameters.AddWithValue("@TempCandidateId", tempCount);
                        insertCmd.Parameters.AddWithValue("@CandidateName", candidate.Name);
                        insertCmd.Parameters.AddWithValue("@CandidateImage", candidate.ImageUrl);
                        insertCmd.Parameters.AddWithValue("@CandidateParty", candidate.Party);
                        insertCmd.Parameters.AddWithValue("@CandidateVoteNumber", 0);
                        insertCmd.Parameters.AddWithValue("@CandidateVoteCount", 0);

                        


                        insertCmd.ExecuteNonQuery();

                    }
                }
            }
            return View();
            //return RedirectToAction("NextAction");
        }





        private Election GetElectionDetailsByName(string electionName)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ElectionSystem;Integrated Security=True;";
            string query = "SELECT ElectionID, ElectionName, Description, Date FROM Election WHERE ElectionName = @ElectionName1";

            Election election = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ElectionName1", electionName);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            election = new Election
                            {
                                ElectionID = reader.GetInt32(reader.GetOrdinal("ElectionID")),
                                ElectionName = reader.GetString(reader.GetOrdinal("ElectionName")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                Date = reader.GetDateTime(reader.GetOrdinal("Date"))
                            };
                        }
                    }
                }
            }

            return election;
        }


        public IActionResult ElectionSuccess()
        {
            return View();
        }
        /*public IActionResult addElection(Election election)
        {
            try
            {
                // Print election details (for debugging)
                Console.WriteLine($"Election Name: {election.ElectionName}");
                Console.WriteLine($"Description: {election.Description}");
                Console.WriteLine($"Date: {election.ElectionDate}");

                // Print candidate details (for debugging)
                foreach (var candidate in election.Candidates)
                {
                    Console.WriteLine($"Candidate Name: {candidate.Name}");
                    Console.WriteLine($"Image URL: {candidate.ImageUrl}");
                    Console.WriteLine($"Party: {candidate.Party}");
                }

                // Dynamic SQL Table Creation
                string query = $@"
                CREATE TABLE {election.ElectionName.Replace(" ", "_")}_Candidates (
                    Id INT PRIMARY KEY IDENTITY,
                    Name NVARCHAR(100),
                    ImageURL NVARCHAR(255),
                    Party NVARCHAR(100)
                )";

                using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ElectionSystem;Integrated Security=True"))
                {
                    conn.Open();

                    // Create the table
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Insert Candidates
                    foreach (var candidate in election.Candidates)
                    {
                        string insertQuery = $@"
                        INSERT INTO {election.ElectionName.Replace(" ", "_")}_Candidates (Name, ImageURL, Party)
                        VALUES (@Name, @ImageURL, @Party)";

                        using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@Name", candidate.Name);
                            cmd.Parameters.AddWithValue("@ImageURL", candidate.ImageUrl);
                            cmd.Parameters.AddWithValue("@Party", candidate.Party);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                TempData["SuccessMessage"] = "Election and candidates added successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Failed to add election. Error: " + ex.Message;
                return View();
            }
        }
       }*/
    }

}
