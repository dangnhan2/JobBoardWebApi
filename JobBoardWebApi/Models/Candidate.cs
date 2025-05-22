namespace JobBoardWebApi.Models
{
    public class Candidate
    {
        public Guid Id { get; set; }
        public string Skills { get; set; }
        public string Gender { get; set; }
        public List<Application> Applications { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
