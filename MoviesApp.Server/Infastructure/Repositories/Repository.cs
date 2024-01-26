using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MoviesApp.Server.Common.Types;
using MoviesApp.Server.Infastructure.Repositories.Interface;
using System.Linq.Expressions;

namespace MoviesApp.Server.Infastructure.Repositories
{
    public class Repository<T, Tkey> : IRepository<T, Tkey> where T : BaseEntity<Tkey>
    {
        private readonly MovieDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Create(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task Create(List<T> entity)
        {
            await _dbSet.AddRangeAsync(entity);
        }

        public async Task UpdateEntity(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task<int> Count(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.CountAsync(expression);
        }

        public async Task<T> Get(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression)
        {
            if (expression != null)
            {
                return await _dbSet.FirstOrDefaultAsync(expression);
            }
            else
            {
                return await _dbSet.FirstOrDefaultAsync();
            }
        }

        public async Task<IQueryable<T>> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public async Task<IQueryable<T>> GetAll(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public async Task<int> Delete(T entity)
        {
            _dbSet.Remove(entity);
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
            return 1;
        }
    }
}
