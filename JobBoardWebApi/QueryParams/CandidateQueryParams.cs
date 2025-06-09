namespace JobBoardWebApi.Filter
{
    public sealed class CandidateQueryParams
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

    }
}
