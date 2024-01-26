namespace MoviesApp.Server.Common.Types
{
    public class PagedResponse<T>
    {
            public int CurrentPage { get; set; }
            public int PageNumber { get; set; }
            public int PageSize { get; set; }

            public int TotalNoItems { get; set; }
            public int TotalPages { get; set; }

            public string OrderBy { get; set; }
            public bool OrderByDesc { get; set; }

            public int? NextPage { get; set; }
            public int? PreviousPage { get; set; }
            public List<T> Data { get; set; }
        
    }
}
