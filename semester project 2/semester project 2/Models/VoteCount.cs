using System.ComponentModel.DataAnnotations;

namespace semester_project_2.Models
{
    public class VoteCount
    {
        public int VoteID { get; set; }

        public string Candidate1Name { get; set; }

        public int Candidate1Count { get; set; }

        public string Candidate2Name { get; set; }

        public int Candidate2Count { get; set; }
    }
}
