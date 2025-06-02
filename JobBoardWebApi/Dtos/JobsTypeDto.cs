namespace JobBoardWebApi.Dtos
{
    public class JobsTypeDto
    {
        public HashSet<JobType>? SavedJob { get; set; } = new HashSet<JobType>();
        public HashSet<JobType>? AppliedJob { get; set; } = new HashSet<JobType>();
    }
}
