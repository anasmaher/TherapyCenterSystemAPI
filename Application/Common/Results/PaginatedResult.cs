namespace Application.Common.Results
{
    public class PaginatedResult<T>
    {
        public List<T> Items { get; set; } = [];
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public static PaginatedResult<T> Create(List<T> items, int total, int page, int size)
        {
            return new PaginatedResult<T>
            {
                Items = items,
                TotalCount = total,
                PageNumber = page,
                PageSize = size
            };
        }
    }
}
