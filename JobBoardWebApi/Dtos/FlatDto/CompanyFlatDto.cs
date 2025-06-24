using JobBoardWebApi.Enum;

namespace JobBoardWebApi.Dtos.FlatDto
{
    public class CompanyFlatDto
    {
        public Guid Id { get; set; }
        public string? Company { get; set; }
        public Guid? JobId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? Salary { get; set; }
        public StatusEnum? Status { get; set; }
        public DateTime? Created_At { get; set; }
        public string? Level { get; set; }
        public string? Skill { get; set; }
    }
}
        
