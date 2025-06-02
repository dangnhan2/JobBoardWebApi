namespace JobBoardWebApi.Dtos
{
    public class ApplicationDto
    {   
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public string CoverLetter { get; set; }
        public string FileUrl { get; set; }
    }
}
