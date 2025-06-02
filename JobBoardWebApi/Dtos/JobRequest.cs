using System.Text.Json.Serialization;

namespace JobBoardWebApi.Dtos
{
    public class JobRequest
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Location { get; set; }
        public string Salary { get; set; }
        public Guid LevelId { get; set; }
        public Guid SkillId { get; set; }
        public Guid CompanyId { get; set; }
    }
}
