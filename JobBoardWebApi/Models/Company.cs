namespace JobBoardWebApi.Models
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public string LogoUrl { get; set; } 
        public DateTime Created_At { get; set; } = DateTime.Now;
        public DateTime Updated_at { get; set; }
        public List<Recruiter> Recruiters { get; set; } 
        public List<Job> Jobs { get; set; } = new List<Job>();
        public List<CompanySkill> CompanySkills { get; set; } 
    }
}
