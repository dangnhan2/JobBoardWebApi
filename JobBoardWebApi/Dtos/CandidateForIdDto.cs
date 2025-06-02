namespace JobBoardWebApi.Dtos
{
    public class CandidateForIdDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string ProfilePicUrl { get; set; }
        public List<SkillDto> Skills { get; set; } = new List<SkillDto>();
    }
}
