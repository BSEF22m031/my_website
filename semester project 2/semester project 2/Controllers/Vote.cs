using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using semester_project_2.Hubs;
using semester_project_2.Models;
using System.Data.SqlClient;

namespace semester_project_2.Controllers
{
    public class Vote : Controller
    {
        private readonly IHubContext<VoteHub> _hubContext;
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ElectionSystem;Integrated Security=True;";

        public Vote(IHubContext<VoteHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet]
        public IActionResult vote(int id)  // 'id' represents electionId
        {
            List<ElectionManagement> candidates = new List<ElectionManagement>();

            using (var connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ElectionSystem;Integrated Security=True;"))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM ElectionManagement WHERE ElectionId = @ElectionId", connection);
                command.Parameters.AddWithValue("@ElectionId", id);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    candidates.Add(new ElectionManagement
                    {
                        TempCandidateId = (int)reader["TempCandidateId"],
                        ElectionId = (int)reader["ElectionId"],
                        CandidateName = reader["CandidateName"].ToString(),
                        CandidateParty = reader["CandidateParty"].ToString(),
                        CandidateImage = reader["CandidateImage"].ToString(),
                        CandidateVoteCount = (int)reader["CandidateVoteCount"]
                    });
                }
            }

            return View("vote", candidates);
        }

        [HttpPost]  // This ensures it only accepts POST requests
        public IActionResult vote(int candidateId, int electionId)
        {
            if (Request.Cookies["HasVoted"] != null)
            {
                TempData["Error"] = "You have already voted!";
                return RedirectToAction("vote", new { id = electionId });
            }

            int newVoteCount = 0;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Update the vote count
                var updateCommand = new SqlCommand("UPDATE ElectionManagement SET CandidateVoteCount = CandidateVoteCount + 1 WHERE TempCandidateId = @CandidateId AND ElectionId = @ElectionId", connection);
                updateCommand.Parameters.AddWithValue("@CandidateId", candidateId);
                updateCommand.Parameters.AddWithValue("@ElectionId", electionId);
                updateCommand.ExecuteNonQuery();

                // Get the updated vote count
                var getVoteCommand = new SqlCommand("SELECT CandidateVoteCount FROM ElectionManagement WHERE TempCandidateId = @CandidateId AND ElectionId = @ElectionId", connection);
                getVoteCommand.Parameters.AddWithValue("@CandidateId", candidateId);
                getVoteCommand.Parameters.AddWithValue("@ElectionId", electionId);
                newVoteCount = (int)getVoteCommand.ExecuteScalar();
            }

            // Broadcast real-time update
            _hubContext.Clients.All.SendAsync("ReceiveVoteUpdate", candidateId, newVoteCount);

            // Set the cookie to prevent double voting
            Response.Cookies.Append("HasVoted", "true", new CookieOptions
            {
                Expires = DateTime.Now.AddDays(1),
                HttpOnly = true
            });

            TempData["Success"] = "Your vote has been recorded!";
            return RedirectToAction("vote", new { id = electionId });
        }
    }
}
