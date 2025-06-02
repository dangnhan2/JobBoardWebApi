namespace JobBoardWebApi.Dtos
{
    public class ApplicationPostRequest
    {
        public string CoverLetter { get; set; }
        public IFormFile File { get; set; }
        public Guid CandidateId { get; set; }
        public HashSet<Guid> JobIds { get; set; }
    }
}
