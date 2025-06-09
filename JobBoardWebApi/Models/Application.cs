using JobBoardWebApi.Enum;
using System.Text.Json.Serialization;

namespace JobBoardWebApi.Models
{
    public class Application
    {
        public Guid Id { get; set; }      
        public StatusEnum Status { get; set; }
        public string CoverLetter { get; set; }
        public string FileUrl { get; set; }
        public DateTime Created_At { get; set; } = DateTime.Now;
        public Guid CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        public List<AppliedJob> ApplicationJobMapping { get; set; } = new List<AppliedJob>();
    }
}
