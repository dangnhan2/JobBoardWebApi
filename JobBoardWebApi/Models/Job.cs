using System.Reflection.Emit;
using System.Text.Json.Serialization;

namespace JobBoardWebApi.Models
{
    public class Job
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Location { get; set; }

        public string Salary { get; set; }
        public string Status { get; set; }
        public TimeSpan Created_At { get; set; }
        public TimeSpan? Updated_At { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid LevelId { get; set; }
        public Level Level { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public List<ApplicationJobMapping> ApplicationJobs { get; set; } = new List<ApplicationJobMapping>();
    }
}
