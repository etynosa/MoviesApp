using MoviesApp.Server.Common.Pagination;
using MoviesApp.Server.Common.Types;
using MoviesApp.Server.Domain.Dto;

namespace MoviesApp.Server.Service.Interface
{
    public interface IMovieService
    {
        Task<APIResponse> CreateMovie(CreateMovieDto movie);
        Task<APIResponse> GetMovieById(string id);
        Task<APIResponse> GetMovies();
        Task<APIResponse> UpdateMovie(UpdateMovieDto movie);
        Task<APIResponse> DeleteMovie(string id);
        Task<APIResponse> GetAllMoviesAsync(PaginationParameter pagination);
        Task<APIResponse> SearchMovie(string searchValue);
    }
}
