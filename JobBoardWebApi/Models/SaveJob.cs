namespace JobBoardWebApi.Models
{
    public class SavedJob
    {
        public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public Candidate Candidate { get; set; }

        public Guid JobId { get; set; }
        public Job Job { get; set; }

        public DateTime SavedAt { get; set; } = DateTime.UtcNow;
    }
}
