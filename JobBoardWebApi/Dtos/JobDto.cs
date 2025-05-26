namespace JobBoardWebApi.Dtos
{
    public class JobDto
    {   
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Location { get; set; }
        public string Salary { get; set; }
        public string Status { get; set; }
        public TimeSpan Created_At { get; set; }
        public string Company { get; set; }
        public string Level { get; set; }
        public string Skill { get; set; }
    }
}

