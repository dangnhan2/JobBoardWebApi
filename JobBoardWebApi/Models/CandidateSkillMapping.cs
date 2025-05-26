namespace JobBoardWebApi.Models
{
    public class CandidateSkillMapping
    {
        public Guid CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
