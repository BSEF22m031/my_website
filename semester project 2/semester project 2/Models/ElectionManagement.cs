namespace semester_project_2.Models
{
    public class ElectionManagement
    {
        public int ElectionId { get; set; }

        public int TempCandidateId { get; set; } = 0;

        public string CandidateName { get; set; }

        public string CandidateImage { get; set; }

        public string CandidateParty { get; set; }

        public int? CandidateVoteNumber { get; set; } = 0;

        public int? CandidateVoteCount { get; set; } = 0;
    }

}
