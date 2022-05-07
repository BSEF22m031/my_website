/*using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebQuiz01
{
    internal class FileName
    {
        using System.Data;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
namespace ClassWork
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                ////Manually usage of Data

                DataTable dt = new DataTable();

                //DataColumn Id = new DataColumn("Id", typeof(int));
                //DataColumn Name = new DataColumn("Name", typeof(string));

                //Id.AutoIncrement = true;
                //Id.AutoIncrementSeed = 1; //Auto Increment Process
                //Id.AutoIncrementStep = 1;

                //dt.Columns.Add(Id);     //Adding columns
                //dt.Columns.Add(Name);

                //dt.PrimaryKey = new DataColumn[] { Id };           //Making it a Primary Key
                //                                                   //Primary can be composite that`s why "DataColumn[]" Array is used


                //DataRow dr = new DataRow();  //Must not do thisss

                //DataRow dataRow = dt.NewRow();  //Creating a row

                //dataRow["Name"] = "Usman";      // Adding record into that row using column name
                //dataRow[1] = "Usman";             // Adding record into that row using index
                //dt.Rows.Add(dataRow);             //Adding row

                //DataRow dataRow2 = dt.NewRow();

                //dataRow["Name"] = "Usman";
                //dataRow2[1] = "Sarmad";
                //dt.Rows.Add(dataRow2);

                //foreach (DataRow row in dt.Rows)
                //{
                //    Console.WriteLine(row["Id"]);
                //    Console.WriteLine(row[1]);
                //}

                ////Get data based On PK basis
                //DataRow dataRow1 = dt.Rows.Find(1);

                //////Get data based On basis of index
                //DataRow dataRow3 = dt.Rows[1];

                //////Get data based On basis of a condition
                //DataRow[] rows = dt.Select("name = 'Usman'");          

                //dataRow1["Name"] = "Usman Ali";//Updating data the same date
                //foreach (DataRow row in rows)
                //{
                //    Console.WriteLine(row["Id"]);
                //    Console.WriteLine(row["Name"]);
                //}


                //dt.Rows.Remove(dataRow1);   //Pass row to delete
                //dt.Rows.RemoveAt(0);         //Pass index to remove

                //dt.Rows.Clear();            //Remove all data

                //DataRow datarow4 = dt.Rows[1]; //get data with index

                //DataRow[] datarows = dt.Select("Name like 'A%'");       //get data with Condition


                //Dealing with Database

                SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Management;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

                //Selecting from global DB
                string Query = "Select * from Product";
                SqlCommand cmd = new SqlCommand(Query, conn);

                sqlDataAdapter.SelectCommand = cmd;

                sqlDataAdapter.Fill(dt);                //inserting into local DB from Global DB

                //foreach (DataRow row in dt.Rows)
                //{
                //    Console.WriteLine($"{row[0]}, {row[1]}, {row[2]}, {row[3]}, {row[4]}");
                //}

                //Inser new data in local DB

                //DataRow dtrow = dt.NewRow();
                //dtrow[1] = "Apple";
                //dtrow["description"] = "A fruit";
                //dt.Rows.Add(dtrow);

                //DataRow dtrow2 = dt.NewRow();
                //dtrow2[1] = "Mango";
                //dtrow2[2] = "A fruit";
                //dt.Rows.Add(dtrow2);


                //insert from local DB to Global DB
                DataRow dr = dt.NewRow();
                dr["Name"] = "Milk";
                //dr[0] = 3;
                dr["Description"] = "Some Milk";
                dr["Price"] = 100;

                DataRow dr2 = dt.NewRow();
                dr2["Name"] = "AAlo";
                //dr2[0] = 4;
                dr2["Description"] = "Some AAlo";
                dr2["Price"] = 50;

                dt.Rows.Add(dr);
                dt.Rows.Add(dr2);


                string insertQuery = "INSERT INTO PRODUCT (name, description, price) VALUES (@n,@d,@p)";
                SqlParameter sqlParameter = new SqlParameter("n", SqlDbType.VarChar, 50, "Name");
                SqlParameter sqlParameter1 = new SqlParameter("d", SqlDbType.VarChar, 50, "Description");
                SqlParameter sqlParameter2 = new SqlParameter("p", SqlDbType.Int, 32, "Price");

                SqlCommand insertCommand = new SqlCommand(insertQuery, conn);
                insertCommand.Parameters.Add(sqlParameter);
                insertCommand.Parameters.Add(sqlParameter1);
                insertCommand.Parameters.Add(sqlParameter2);

                sqlDataAdapter.InsertCommand = insertCommand;
                sqlDataAdapter.Update(dt);
            }
        }
    }
}
}
*/