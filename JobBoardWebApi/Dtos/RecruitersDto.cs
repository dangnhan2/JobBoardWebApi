namespace JobBoardWebApi.Dtos
{
    public class RecruitersDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public CompanyDto Company { get; set; }
    }
}

