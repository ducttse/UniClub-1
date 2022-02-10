namespace UniClub.Application.Common
{
    public abstract class RequestPaginationQuery
    {
        public string? SearchValue { get; set; }
        public string? OrderBy { get; set; }
        public bool IsAscending { get; set; } = true;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

    }
}
