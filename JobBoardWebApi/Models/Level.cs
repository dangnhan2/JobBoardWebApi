namespace JobBoardWebApi.Models
{
    public class Level
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Job> Jobs { get; set; } = new List<Job>();
    }
}
