namespace JobBoardWebApi.Models
{
    public class Candidate
    {
        public Guid Id { get; set; }
        public string Gender { get; set; }
        public List<Application> Applications { get; set; } = new List<Application>();
        public List<CandidateSkillMapping> candidateSkillMappings { get; set; } = new List<CandidateSkillMapping>();
        public List<SavedJob> SavedJobs { get; set; } = new List<SavedJob>();
        public string UserId { get; set; }
        public User User { get; set; }

    }
}
