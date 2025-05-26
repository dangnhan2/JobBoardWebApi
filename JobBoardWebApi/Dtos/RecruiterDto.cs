namespace JobBoardWebApi.Dtos
{
    public class RecruiterDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public CompanyDto Company { get; set; }
    }
}
