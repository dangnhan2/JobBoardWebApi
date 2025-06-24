namespace JobBoardWebApi.Dtos.Request
{
    public class RecruiterRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public Guid CompanyId { get; set; }
    }
}
