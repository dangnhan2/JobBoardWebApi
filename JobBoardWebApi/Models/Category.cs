namespace JobBoardWebApi.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Job> Jobs { get; set; } = new List<Job>();
    }
}
