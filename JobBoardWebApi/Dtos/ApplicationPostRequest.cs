namespace JobBoardWebApi.Dtos
{
    public class ApplicationPostRequest
    {
        public string CoverLetter { get; set; }
        public string File { get; set; }
        public Guid CandidateId { get; set; }
        public HashSet<Guid> JobIds { get; set; }
    }
}
