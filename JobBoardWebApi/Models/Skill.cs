namespace JobBoardWebApi.Models
{
    public class Skill
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Job> Jobs { get; set; } = new List<Job>();
        public List<CandidateSkillMapping> candidateSkillMappings { get; set; } = new List<CandidateSkillMapping>();
    }
}
