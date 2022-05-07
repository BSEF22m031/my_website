using Microsoft.AspNetCore.Mvc;
using web_lab_06.Models;
using Microsoft.Data.SqlClient;

namespace web_lab_06.Controllers
{
    public class ReservationController : Controller
    {
        [HttpGet]
        public IActionResult Reserve()
        {
            return View();
        }

        // POST: Reservation/Reserve
        [HttpPost]
        public IActionResult Reserve(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                // Connection string for the database
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"resturant management system\";Integrated Security=True;Connect Timeout=30;Encrypt=False;";

                // SQL query to insert reservation details into the Reservations table
                string insertQuery = @"
                INSERT INTO Reservations (UserId, GuestCount) 
                VALUES (@UserId, @GuestCount)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@UserId", reservation.User);
                    insertCommand.Parameters.AddWithValue("@GuestCount", reservation.GuestCount);

                    try
                    {
                        connection.Open();
                        insertCommand.ExecuteNonQuery();
                        TempData["Success"] = "Reservation made successfully!";
                        return RedirectToAction("Success"); // Redirect to success page or another action
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error inserting reservation: {ex.Message}");
                        TempData["Error"] = "Error making reservation. Please try again.";
                        return View(); // Stay on the same view if there's an error
                    }
                }
            }
            return View(); // If the model is invalid, return to the same view
        }

        // Success Action (optional, redirect after successful reservation)
        public IActionResult Success()
        {
            return View();
        }
    }
}
