using MoviesApp.Server.Domain;

namespace MoviesApp.Server.Infastructure.Repositories.Interface
{
    public interface IMovieRepository : IRepository<Movie, string>
    {
    }
}
