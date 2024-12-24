namespace Api.Models
{
    public abstract class Paginate
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int Count { get; set; } = 0;
        public int TotalCount { get; set; } = 0;
    }
}
