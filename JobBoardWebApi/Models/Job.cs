using JobBoardWebApi.Enum;
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
        public StatusEnum Status { get; set; }
        public DateTime Created_At { get; set; } = DateTime.Now;
        public DateTime? Updated_At { get; set; }
        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }
        public Guid LevelId { get; set; }
        public Level Level { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public List<AppliedJob> ApplicationJobMapping { get; set; } = new List<AppliedJob>();
        public List<SavedJob> SavedJobs { get; set; } = new List<SavedJob>();
    }
}

