using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebQuiz01
{
    public  class Player
    {
        public int PlayerId { get; set; }   
        public string UserName { get; set; }
        public int Ranking { get; set; }
        public int TotalQuizTaken { get; set; }
        public int TotalCorrectAnswers { get; set; }
        public int TotalInCorrectAnswers { get; set; }

        public int score { get; set; }

    }
}
