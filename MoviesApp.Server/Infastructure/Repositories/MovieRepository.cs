using MoviesApp.Server.Common.Types;
using MoviesApp.Server.Domain;
using MoviesApp.Server.Infastructure.Repositories.Interface;

namespace MoviesApp.Server.Infastructure.Repositories
{
    public class MovieRepository : Repository<Movie, string>, IMovieRepository
    {
        public MovieRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }
    }
}
