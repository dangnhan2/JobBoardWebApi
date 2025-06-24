namespace JobBoardWebApi.Dtos.FlatDto
{
    public class RecruiterFlatDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string ProfilePirUrl { get; set; }
        public string Email { get; set; }
        public Guid CompanyId { get; set; }
        public string Company { get; set; }
        public string LogoUrl { get; set; }
    }
}
