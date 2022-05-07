using System.IO;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
class Program
{
    static void Main()
    {
        /*using (StreamWriter file = new StreamWriter("example.txt"))
        {
            file.WriteLine("Hello, C#!");
        }*/
        //ProductService productService1 = new ProductService();
        //productService1.fileOperation();
        //Console.WriteLine("Current Directory: " + Directory.GetCurrentDirectory());

        /*string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Management;Integrated Security=True;";
        SqlConnection conn = new SqlConnection(connStr);
        Console.WriteLine("Enter Category Name: ");
        string Name = Console.ReadLine();
        string query = $"select * from Category";
        SqlCommand sqlCommand = new SqlCommand(query, conn);
        conn.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine(reader.GetInt32(0));
            Console.WriteLine(reader.GetString(1));
        }
        conn.Close();*/


        /* string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Management;Integrated Security=True;";
         SqlConnection conn = new SqlConnection(connStr);
         Console.WriteLine("Enter Category Name: ");
         string Name = Console.ReadLine();
         string query = $"Update Into Category where CategoryName = {Name}";
         SqlCommand sqlCommand = new SqlCommand(query, conn);
         conn.Open();
         int count = sqlCommand.ExecuteNonQuery();
         Console.WriteLine(count);
         conn.Close();*/


        /*string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Management;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";   
        SqlConnection conn = new SqlConnection(connStr);
        Console.WriteLine("Enter Category Name: ");
        string Name = Console.ReadLine();
        string query = $"Insert Into Category (CategoryName) values( '{Name}')";
        SqlCommand sqlCommand = new SqlCommand(query, conn);
        conn.Open();
        int count = sqlCommand.ExecuteNonQuery();
        conn.Close();

        Console.WriteLine(count);
        Console.WriteLine("ajdn");*/

        /*SqlDataReader reader = sqlCommand.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine(reader.GetInt32(0));
            Console.WriteLine(reader.GetString(1));
        }*/
        string data = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Management;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        
        Console.WriteLine(data);
        SqlConnection conn = new SqlConnection(data);
        conn.Open();
        string query = "select * from Student where name like 'M%'";
        SqlCommand sqlCommand = new SqlCommand(query, conn);
        SqlDataReader reader = sqlCommand.ExecuteReader();
        //Console.WriteLine(reader.ToString());
        while (reader.Read())
        {
            Console.WriteLine(reader.GetInt32(0));
            Console.WriteLine(reader.GetString(1));
            Console.WriteLine(reader.GetDecimal(2));
        }

        conn.Close();
    }

}

