namespace JobBoardWebApi.Models
{
    public class Recruiter
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
