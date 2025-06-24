namespace JobBoardWebApi.Dtos.Request
{
    public class RecruiterPutRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfilePicUrl { get; set; }
        public Guid CompanyId { get; set; }
    }
}
