namespace JobBoardWebApi.Dtos
{
    public class JobsTypeDto
    {
        public ICollection<JobType>? SavedJob { get; set; } 
        public ICollection<JobType>? AppliedJob { get; set; } 
    }
}
