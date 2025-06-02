namespace JobBoardWebApi.Dtos
{
    public class RecruiterDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public Guid CompanyId { get; set; }
        public string Company { get; set; }
       
    }
}
