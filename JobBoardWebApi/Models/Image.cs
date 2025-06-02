namespace JobBoardWebApi.Models
{
    public class Image
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; } 
        public List<User> Users { get; set; } = new List<User>();
        public Guid? CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}
