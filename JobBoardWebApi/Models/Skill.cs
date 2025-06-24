namespace JobBoardWebApi.Models
{
    public class Skill
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Created_At { get; set; } = DateTime.Now;
        public DateTime Updated_at { get; set; }
        public List<Job> Jobs { get; set; } = new List<Job>();
        public List<CandidateSkill> CandidateSkills { get; set; } = new List<CandidateSkill>();
        public List<CompanySkill> CompanySkills { get; set; }
    }
}
