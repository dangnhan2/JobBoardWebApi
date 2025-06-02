namespace JobBoardWebApi.Dtos
{
    public class JobType
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string LogoUrl { get; set; }
        public string Location { get; set; }
        public string Salary { get; set; }
    }
}
