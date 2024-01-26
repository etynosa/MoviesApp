namespace MoviesApp.Server.Common.Pagination
{
    public class PaginationParameter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PaginationParameter()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public PaginationParameter(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}
