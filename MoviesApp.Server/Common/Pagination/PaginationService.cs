using Microsoft.EntityFrameworkCore;
using MoviesApp.Server.Common.Types;
using System.Linq.Dynamic;
using System.Linq.Expressions;
namespace MoviesApp.Server.Common.Pagination
{
    public class PaginationService
    {
        public async Task<PagedResponse<T>> GetPagination<T>(IQueryable<T> query, int page, Expression<Func<T, object>> orderBy, string sortName, bool orderByDesc, int pageSize)
        {
            var pagination = new PagedResponse<T>
            {
                TotalNoItems = query.Count(),
                PageSize = pageSize,
                CurrentPage = page,
                OrderBy = orderBy.Parameters.Select(x => x.Name.Concat("-")).ToString(),
                OrderByDesc = orderByDesc
            };

            var skip = (page - 1) * pageSize;

            if (orderByDesc)
            {
                query.OrderBy(sortName);

                pagination.Data = await query
                    .OrderBy(orderBy)
                    .Skip(skip)
                    .Take(pageSize)
                    .ToListAsync();

                return pagination;
            }

            pagination.Data = await query
                .OrderBy(orderBy)
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();

            return pagination;
        }
    }
}
