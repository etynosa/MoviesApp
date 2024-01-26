using MoviesApp.Server.Domain;
using MoviesApp.Server.Infastructure.Repositories.Interface;

namespace MoviesApp.Server.Infastructure.Repositories
{
    public class GenreRepository : Repository<Genre, string>, IGenreRepository
    {
        public GenreRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }
    }
}
