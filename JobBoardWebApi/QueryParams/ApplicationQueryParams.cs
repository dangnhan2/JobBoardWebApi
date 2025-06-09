using JobBoardWebApi.Enum;

namespace JobBoardWebApi.Filter
{
    public sealed class ApplicationQueryParams
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public StatusEnum? Status { get; set; }

    }
}
