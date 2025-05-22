namespace JobBoardWebApi.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

        public string? UserId { get; set; }
        public User User { get; set; }

        public Guid? CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}
