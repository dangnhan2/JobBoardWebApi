namespace JobBoardWebApi.Dtos
{
    public class CandidateForIdDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public bool IsStudent { get; set; }
        public List<SkillDto> Skills { get; set; } = new List<SkillDto>();
        public List<ApplicationDto> Applications { get; set; } = new List<ApplicationDto>();
    }
}
