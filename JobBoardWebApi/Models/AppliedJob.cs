namespace JobBoardWebApi.Models
{
    public class AppliedJob
    {
        public Guid ApplicationId { get; set; }
        public Application Application { get; set; }
        public Guid JobId { get; set; }
        public Job Job { get; set; }
    }
}
