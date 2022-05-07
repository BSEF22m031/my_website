using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace WebQuiz01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LeaderboardManager leaderboardManager = new LeaderboardManager();
            //leaderboardManager.FetchPlayer();
            leaderboardManager.SaveQuizResult(3, 10, 8);
        }
    }
}
