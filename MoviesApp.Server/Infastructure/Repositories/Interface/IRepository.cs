using MoviesApp.Server.Common.Types;
using System.Linq.Expressions;

namespace MoviesApp.Server.Infastructure.Repositories.Interface
{
    public interface IRepository<T, Tkey> where T : class
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        // Write 
        Task Create(T entity);
        Task Create(List<T> entity);
        Task UpdateEntity(T entity);

        // Read 
        Task<IQueryable<T>> GetAll();
        Task<IQueryable<T>> GetAll(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> GetAll(
                Expression<Func<T, bool>> filter = null,
                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                string includeProperties = "");
        Task<T> Get(object id);

        Task<T> Get(Expression<Func<T, bool>> expression);
        Task<int> Count(Expression<Func<T, bool>> expression);

        // Delete 
        Task<int> Delete(T entity);
    }
}
