using Microsoft.AspNetCore.Mvc;
using web_lab_06.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace web_lab_06.Controllers
{
    public class MenuController : Controller
    {

        [HttpGet]
        public IActionResult menu()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"resturant management system\";Integrated Security=True;Connect Timeout=30;Encrypt=False;"; 
            List<Menu> menuList = new List<Menu>();
            string query = "SELECT ItemId, ItemName, Description, Price, Availability FROM Menu";

            //string query = "SELECT * FROM Menu";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    Console.WriteLine("Attempting to connect to database...");
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        

                        while (reader.Read())
                        {
                            Console.WriteLine("Reading row...");


                            Menu menuItem = new Menu
                            {
                                ItemId = reader.GetInt32(0),
                                ItemName = reader.GetString(1),
                                Description = reader.GetString(2),
                                Price = (double)reader.GetDecimal(3),
                                Availability = reader.GetBoolean(4)
                            };

                            menuList.Add(menuItem);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            return View(menuList);
        }
        [HttpPost]
        public IActionResult menu(string searchTerm)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"resturant management system\";Integrated Security=True;Connect Timeout=30;Encrypt=False;";
            List<Menu> menuList = new List<Menu>();

            // Query to search for items by name
            string query = "SELECT ItemId, ItemName, Description, Price, Availability FROM Menu WHERE ItemName LIKE @SearchTerm";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                // Use parameterized queries to prevent SQL injection
                command.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");

                try
                {
                    Console.WriteLine("Attempting to connect to database...");
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("Reading row...");

                            Menu menuItem = new Menu
                            {
                                ItemId = reader.GetInt32(0),
                                ItemName = reader.GetString(1),
                                Description = reader.GetString(2),
                                Price = (double)reader.GetDecimal(3),
                                Availability = reader.GetBoolean(4)
                            };

                            menuList.Add(menuItem);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            // Return the filtered list to the view
            return View(menuList);
        }

       

    }



}

