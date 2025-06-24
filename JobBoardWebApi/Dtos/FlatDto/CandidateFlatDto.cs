namespace JobBoardWebApi.Dtos.FlatDto
{
    public class CandidateFlatDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfilePicUrl { get; set; }
        //public string NormalizedEmail { get; set; }
        public Guid? SkillId { get; set; }
        public string? SkillName { get; set; }
    }
}
