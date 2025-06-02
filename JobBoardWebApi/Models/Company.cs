namespace JobBoardWebApi.Models
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public Recruiter Recruiter { get; set; } 
        public string LogoUrl { get; set; } 
        public List<Job> Jobs { get; set; } = new List<Job>();
    }
}
