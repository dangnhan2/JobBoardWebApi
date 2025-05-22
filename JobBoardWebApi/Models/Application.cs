using System.Text.Json.Serialization;

namespace JobBoardWebApi.Models
{
    public class Application
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public bool IsStudent { get; set; }
        public string Status { get; set; }
        public string FileUrl { get; set; }
        public Guid CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        public List<ApplicationJobMapping> ApplicationJobs { get; set; } = new List<ApplicationJobMapping>();
    }
}
