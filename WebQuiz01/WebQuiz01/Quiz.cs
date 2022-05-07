using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebQuiz01
{
    public class Quiz
    {
        public int QuizId {  get; set; }
        public DateTime QuizDate { get; set; }
        public int PlayerId { get; set;}
        public int TotalQuestion { get; set; }
        public int CorrectAnswers { get; set; }
        public int ScoreEarned { get; set; }

    }
}
