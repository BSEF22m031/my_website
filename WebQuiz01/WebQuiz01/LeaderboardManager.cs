using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebQuiz01
{
    public  class LeaderboardManager
    {
        public LeaderboardManager() 
        {

        }
        public void FetchPlayer()
        {
            DataTable playerdt = new DataTable();

            DataColumn PlayerId = new DataColumn("PlayerId", typeof(int));
            DataColumn UserName = new DataColumn("UserName", typeof(string));
            DataColumn Ranking = new DataColumn("Ranking", typeof(int));
            DataColumn TotalQuizTaken = new DataColumn("TotalQuizTaken", typeof(int));
            DataColumn TotalCorrectAnswers = new DataColumn("TotalCorrectAnswers", typeof(int));
            DataColumn TotalInCorrectAnswers = new DataColumn("TotalInCorrectAnswers", typeof(int));
            DataColumn score = new DataColumn("score", typeof(int));
            playerdt.Columns.Add(PlayerId);
            playerdt.Columns.Add(UserName);
            playerdt.Columns.Add(Ranking);
            playerdt.Columns.Add(TotalQuizTaken);
            playerdt.Columns.Add(TotalCorrectAnswers);
            playerdt.Columns.Add(TotalInCorrectAnswers);
            playerdt.Columns.Add(score);
            playerdt.PrimaryKey = new DataColumn[] { PlayerId };   
            SqlConnection conn = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = player; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

            string Query = "Select * from Player";
            SqlCommand cmd = new SqlCommand(Query, conn);

            sqlDataAdapter.SelectCommand = cmd;

            sqlDataAdapter.Fill(playerdt);
        }
        public void DisplayLeaderBoard() 
        {
            DataTable playerdt = new DataTable();
            SqlConnection conn = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = player; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

            string Query = "Select * from Player";
            SqlCommand cmd = new SqlCommand(Query, conn);

            sqlDataAdapter.SelectCommand = cmd;

            sqlDataAdapter.Fill(playerdt);
            foreach (DataRow row in playerdt.Rows)
            {
                Console.WriteLine($"{row[0]}, {row[1]}, {row[2]}, {row[3]}, {row[4]}");
            }
        }
        public void SaveQuizResult(int PlayerId1, int TotalQuestion1, int correctAnswers1) 
        {
            DataTable playerdt2 = new DataTable();

           
            DataColumn QuizDate = new DataColumn("QuizDate", typeof(DateTime));
            DataColumn PlayerId = new DataColumn("PlayerId", typeof(int));
            DataColumn TotalQuestion = new DataColumn("TotalQuestion", typeof(int));
            DataColumn CorrectAnswers = new DataColumn("CorrectAnswers", typeof(int));
            DataColumn ScoreEarned = new DataColumn("ScoreEarned", typeof(int));
            playerdt2.Columns.Add(QuizDate);
            playerdt2.Columns.Add(PlayerId);
            playerdt2.Columns.Add(TotalQuestion);
            playerdt2.Columns.Add(CorrectAnswers);
            playerdt2.Columns.Add(ScoreEarned);
            playerdt2.PrimaryKey = new DataColumn[] { PlayerId };

            int IncorrectAnswer = TotalQuestion1 - correctAnswers1;
            int scoredEarn = correctAnswers1 *5;


            SqlConnection conn = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = player; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

            string Query = "Select * from Quiz";
            SqlCommand cmd = new SqlCommand(Query, conn);

            sqlDataAdapter.SelectCommand = cmd;

            sqlDataAdapter.Fill(playerdt2);

            DataRow dataRow = playerdt2.NewRow();  
            dataRow["QuizDate"] = DateTime.Now ;
            dataRow["PlayerId"] = PlayerId1;
            dataRow["TotalQuestion"] = TotalQuestion1;
            dataRow["CorrectAnswers"] = correctAnswers1;
            dataRow["ScoreEarned"] = scoredEarn;
            playerdt2.Rows.Add(dataRow);
            string insertQuery = "INSERT INTO Quiz (QuizDate, PlayerId, TotalQuestion,CorrectAnswers,ScoreEarned) VALUES (@q,@p,@t,@c,@s)";
            SqlParameter sqlParameter = new SqlParameter("q", SqlDbType.DateTime, 50, "QuizDate");
            SqlParameter sqlParameter1 = new SqlParameter("p", SqlDbType.Int, 32, "PlayerId");
            SqlParameter sqlParameter2 = new SqlParameter("t", SqlDbType.Int, 32, "TotalQuestion");
            SqlParameter sqlParameter3 = new SqlParameter("c", SqlDbType.Int, 32, "CorrectAnswers");
            SqlParameter sqlParameter4 = new SqlParameter("s", SqlDbType.Int, 32, "ScoreEarned");
            SqlCommand insertCommand = new SqlCommand(insertQuery, conn);
            insertCommand.Parameters.Add(sqlParameter);
            insertCommand.Parameters.Add(sqlParameter1);
            insertCommand.Parameters.Add(sqlParameter2);
            insertCommand.Parameters.Add(sqlParameter3);
            insertCommand.Parameters.Add(sqlParameter4);
            sqlDataAdapter.InsertCommand = insertCommand;
            sqlDataAdapter.Update(playerdt2);
        }
        private void UpdatePlayerStatics(int plAYERID2, int correctasnwer2, int incorrectnswer2, int scoredanswer2)
        {
            DataTable playerdt = new DataTable();

            DataColumn PlayerId = new DataColumn("PlayerId", typeof(int));
            DataColumn UserName = new DataColumn("UserName", typeof(string));
            DataColumn Ranking = new DataColumn("Ranking", typeof(int));
            DataColumn TotalQuizTaken = new DataColumn("TotalQuizTaken", typeof(int));
            DataColumn TotalCorrectAnswers = new DataColumn("TotalCorrectAnswers", typeof(int));
            DataColumn TotalInCorrectAnswers = new DataColumn("TotalInCorrectAnswers", typeof(int));
            DataColumn score = new DataColumn("score", typeof(int));
            playerdt.Columns.Add(PlayerId);
            playerdt.Columns.Add(UserName);
            playerdt.Columns.Add(Ranking);
            playerdt.Columns.Add(TotalQuizTaken);
            playerdt.Columns.Add(TotalCorrectAnswers);
            playerdt.Columns.Add(TotalInCorrectAnswers);
            playerdt.Columns.Add(score);
            playerdt.PrimaryKey = new DataColumn[] { PlayerId };
            SqlConnection conn = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = player; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

            string Query = "Select * from Player";
            SqlCommand cmd = new SqlCommand(Query, conn);

            sqlDataAdapter.SelectCommand = cmd;

            sqlDataAdapter.Fill(playerdt);

            DataRow dataRow = playerdt.NewRow();  
            dataRow["PlayerId"] = plAYERID2;
            dataRow["UserName"] = "Usman";
            dataRow["Ranking"] = 1;
            dataRow["TotalQuizTaken"] = 1;
            dataRow["TotalCorrectAnswers"] = correctasnwer2;
            dataRow["TotalInCorrectAnswers"] = incorrectnswer2;
            dataRow["score"] = scoredanswer2;
            playerdt.Rows.Add(dataRow);

            string insertQuery = "INSERT INTO Player (PlayerId, UserName, Ranking,TotalQuizTaken,TotalCorrectAnswers,TotalInCorrectAnswers,score) VALUES (@p,@q,@t,@c,@s,@w,@r) where PlayerId=@P";
            
            SqlParameter sqlParameter1 = new SqlParameter("p", SqlDbType.Int, 32, "PlayerId");
            SqlParameter sqlParameter = new SqlParameter("q", SqlDbType.VarChar, 50, "UserName");
            SqlParameter sqlParameter2 = new SqlParameter("t", SqlDbType.Int, 32, "Ranking");
            SqlParameter sqlParameter3 = new SqlParameter("c", SqlDbType.Int, 32, "TotalQuizTaken");
            SqlParameter sqlParameter4 = new SqlParameter("s", SqlDbType.Int, 32, "TotalCorrectAnswers");
            SqlParameter sqlParameter5 = new SqlParameter("w", SqlDbType.Int, 32, "TotalInCorrectAnswers");
            SqlParameter sqlParameter6 = new SqlParameter("r", SqlDbType.Int, 32, "score");
            SqlCommand insertCommand = new SqlCommand(insertQuery, conn);
            insertCommand.Parameters.Add(sqlParameter);
            insertCommand.Parameters.Add(sqlParameter1);
            insertCommand.Parameters.Add(sqlParameter2);
            insertCommand.Parameters.Add(sqlParameter3);
            insertCommand.Parameters.Add(sqlParameter4);
            insertCommand.Parameters.Add(sqlParameter5);
            insertCommand.Parameters.Add(sqlParameter6);
            sqlDataAdapter.InsertCommand = insertCommand;
            sqlDataAdapter.Update(playerdt);
        }
    }
}
