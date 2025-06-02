namespace JobBoardWebApi.Dtos
{
    public class RecruiterPutRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public IFormFile file { get; set; }
        public Guid CompanyId { get; set; }
    }
}
