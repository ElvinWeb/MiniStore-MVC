namespace MiniStore.UI.Pagination
{
    public class PaginatedList<T> : List<T>
    {
        public PaginatedList(List<T> items, int count, int page, int pageSize)
        {
            this.AddRange(items);
            PageIndex = page;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage { get => PageIndex > 1; }
        public bool HasNextPage { get => PageIndex < TotalPages; }

        public static PaginatedList<T> CreatePagination(List<T> values, int page, int pageSize)
        {
            var count = values.Count;
            var items = values.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return new PaginatedList<T>(items, count, page, pageSize);
        }


    }
}
