using Microsoft.AspNetCore.Http; // For session management
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using web_lab_06.Models;
namespace web_lab_06.Controllers
{
    public class CartController : Controller
    {
        [HttpGet]
        public IActionResult Cart()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"resturant management system\";Integrated Security=True;Connect Timeout=30;Encrypt=False;";

            List<Cart> cartItems = new List<Cart>();

            string fetchQuery = @"
        SELECT c.CartId, c.UserId, c.ItemId, c.Quantity, m.ItemName, m.Price
        FROM Cart c
        INNER JOIN Menu m ON c.ItemId = m.ItemId
        WHERE c.UserId = @UserId"; 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand fetchCommand = new SqlCommand(fetchQuery, connection);
               
                int UserId = 1;
                fetchCommand.Parameters.AddWithValue("@UserId", UserId);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = fetchCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cartItems.Add(new Cart
                            {
                                CartId = reader.GetInt32(0),
                                User = new User { UserId = reader.GetInt32(1) },
                                Item = new Menu
                                {
                                    ItemId = reader.GetInt32(2),
                                    ItemName = reader.GetString(4),
                                    Price = (double)reader.GetDecimal(5)
                                },
                                Quantity = reader.GetInt32(3)
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching cart data: {ex.Message}");
                    TempData["Error"] = "Error fetching cart data.";
                    return RedirectToAction("menu", "Menu");
                }
            }

            // Pass the cartItems list to the view
            return View(cartItems);
        }

        [HttpPost]
        [Route("/Cart/cart")]
        public IActionResult cart(int ItemId)
        {
            // Connection string for the database
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"resturant management system\";Integrated Security=True;Connect Timeout=30;Encrypt=False;";

            // Create a random object to generate random numbers
            Random random = new Random();

            // Step 1: Generate random UserId and Quantity
            int UserId = random.Next(1, 1001); // Random UserId between 1 and 1000
            int Quantity = random.Next(1, 11); // Random Quantity between 1 and 10

            // Step 2: Check if the item exists in the Menu table
            string fetchQuery = "SELECT ItemId FROM Menu WHERE ItemId = @ItemId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand fetchCommand = new SqlCommand(fetchQuery, connection);
                fetchCommand.Parameters.AddWithValue("@ItemId", ItemId);

                try
                {
                    connection.Open();
                    object result = fetchCommand.ExecuteScalar();

                    if (result == null)
                    {
                        Console.WriteLine("Item not found in the Menu table.");
                        TempData["Error"] = "Item does not exist.";
                        return RedirectToAction("menu", "Menu");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error checking item existence: {ex.Message}");
                    return RedirectToAction("menu", "Menu");
                }
            }

            // Step 3: Insert item details into the Cart table with random UserId and Quantity
            string insertQuery = @"
        INSERT INTO Cart (UserId, ItemId, Quantity) 
        VALUES (@UserId, @ItemId, @Quantity)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@UserId", UserId);
                insertCommand.Parameters.AddWithValue("@ItemId", ItemId);
                insertCommand.Parameters.AddWithValue("@Quantity", Quantity);

                try
                {
                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                    Console.WriteLine($"Item successfully added to the Cart table (UserId: {UserId}, ItemId: {ItemId}, Quantity: {Quantity}).");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting item into Cart table: {ex.Message}");
                    TempData["Error"] = "Error adding item to cart.";
                    return RedirectToAction("menu", "Menu");
                }
            }

            // Success message
            TempData["Success"] = "Item added to the cart successfully!";
            return RedirectToAction("menu", "Menu");
        }

    }
}

