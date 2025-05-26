using System.Text.Json.Serialization;

namespace JobBoardWebApi.Models
{
    public class Application
    {
        public Guid Id { get; set; }      
        public string Status { get; set; }
        public string FileUrl { get; set; }
        public string CoverLetter { get; set; }
        public Guid CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        public List<ApplicationJobMapping> ApplicationJobMapping { get; set; } = new List<ApplicationJobMapping>();
    }
}
