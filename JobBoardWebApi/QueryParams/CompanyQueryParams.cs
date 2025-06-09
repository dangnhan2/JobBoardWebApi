namespace JobBoardWebApi.QueryParams
{
    public sealed class CompanyQueryParams
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Name {get;set; }
    }
}
