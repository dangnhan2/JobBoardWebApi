namespace JobBoardWebApi.Filter
{
    public sealed class JobQueryParams
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Title { get; set; }
        public string? Location { get; set; }
        public string? Skill { get; set; }
        public string? Level { get; set; }
        public string? Company { get; set; }
    }
}
