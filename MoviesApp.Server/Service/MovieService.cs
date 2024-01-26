using MoviesApp.Server.Common.constants;
using MoviesApp.Server.Common.Pagination;
using MoviesApp.Server.Common.Types;
using MoviesApp.Server.Domain;
using MoviesApp.Server.Domain.Dto;
using MoviesApp.Server.Infastructure;
using MoviesApp.Server.Infastructure.Repositories.Interface;
using MoviesApp.Server.Service.Interface;
using System.Net;

namespace MoviesApp.Server.Service
{
    public class MovieService(MovieDbContext dbContext, IMovieRepository movieRepository) : IMovieService
    {
        public async Task<APIResponse> CreateMovie(CreateMovieDto movie)
        {
            var movieEntity = new Movie
            {
                Id = Guid.NewGuid().ToString(),
                Title = movie.Title,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate,
                Genre = movie.Genre,
                Rating = movie.Rating,
                Country = movie.Country,
                TicketPrice = movie.TicketPrice,
                PhotoUrl = movie.PhotoUrl,
                Director = movie.Director,
            };
            await movieRepository.Create(movieEntity);
            return APIResponse.GetSuccessMessage(HttpStatusCode.Created, movie, MessageConstants.CreateSuccessMessage);
        }

        public async Task<APIResponse> GetMovieById(string id)
        {
            var movie = await movieRepository.Get(id);
            if (movie == null)
            {
                return APIResponse.GetFailureMessage(HttpStatusCode.NotFound, null, MessageConstants.FetchFailureMessage);
            }
            var movieDto = new MovieDto
            {
                Title = movie.Title,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate,
                Genre = movie.Genre,
                Rating = movie.Rating,
                Country = movie.Country,
                TicketPrice = movie.TicketPrice,
                PhotoUrl = movie.PhotoUrl,
                Director = movie.Director,
            };

            return APIResponse.GetSuccessMessage(HttpStatusCode.OK, movieDto, MessageConstants.FetchSuccessMessage);
        }

        public async Task<APIResponse> GetMovies()
        {
            var movies = await movieRepository.GetAll();
            if (!movies.Any())
            {
                return APIResponse.GetFailureMessage(HttpStatusCode.NotFound, null, MessageConstants.FetchFailureMessage);
            }

            var moviesList = movies.Select(movie => new MovieDto
            {
                Title = movie.Title,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate,
                Genre = movie.Genre,
                Rating = movie.Rating,
                Country = movie.Country,
                TicketPrice = movie.TicketPrice,
                PhotoUrl = movie.PhotoUrl,
                Director = movie.Director,
            }).ToList();

            return APIResponse.GetSuccessMessage(HttpStatusCode.OK, moviesList, MessageConstants.FetchSuccessMessage);
        }

        public async Task<APIResponse> UpdateMovie(UpdateMovieDto movie)
        {
            var movieEntity = new Movie
            {
                Title = movie.Title,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate,
                Genre = movie.Genre,
                Rating = movie.Rating,
                Country = movie.Country,
                TicketPrice = movie.TicketPrice,
                PhotoUrl = movie.PhotoUrl,
                Director = movie.Director,
            };
            await movieRepository.UpdateEntity(movieEntity);
            return APIResponse.GetSuccessMessage(HttpStatusCode.OK, null, MessageConstants.UpdateSuccessMessage);
        }

        public async Task<APIResponse> DeleteMovie(string id)
        {
            var movie = await movieRepository.Get(id);
            if (movie == null)
            {
                return APIResponse.GetFailureMessage(HttpStatusCode.NotFound, null, MessageConstants.FetchFailureMessage);
            }
            await movieRepository.Delete(movie);
            return APIResponse.GetSuccessMessage(HttpStatusCode.OK, null, MessageConstants.DeleteSuceessMessage);
        }

        public async Task<APIResponse> GetAllMoviesAsync(PaginationParameter pagination)
        {
            var movies = await movieRepository.GetAll();
            if (movies.Any())
            {
                var moviesList = movies.Select(movie => new MovieDto
                {
                    Title = movie.Title,
                    Description = movie.Description,
                    ReleaseDate = movie.ReleaseDate,
                    Genre = movie.Genre,
                    Rating = movie.Rating,
                    Country = movie.Country,
                    TicketPrice = movie.TicketPrice,
                    PhotoUrl = movie.PhotoUrl,
                    Director = movie.Director,
                }).ToList();

                var pagedResponse = moviesList.OrderByDescending(moviesList => moviesList.ReleaseDate).Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();
                return APIResponse.GetSuccessMessage(HttpStatusCode.OK, pagedResponse, MessageConstants.FetchSuccessMessage);

            }
            else
            {
                return null;
            }

        }

        public async Task<APIResponse> SearchMovie(string searchValue)
        {
            var movies = await movieRepository.GetAll();
            if (movies.Any())
            {
                var moviesList = movies.Select(movie => new MovieDto
                {
                    Title = movie.Title,
                    Description = movie.Description,
                    ReleaseDate = movie.ReleaseDate,
                    Genre = movie.Genre,
                    Rating = movie.Rating,
                    Country = movie.Country,
                    TicketPrice = movie.TicketPrice,
                    PhotoUrl = movie.PhotoUrl,
                    Director = movie.Director,
                }).ToList();

                var pagedResponse = moviesList.Where(moviesList => moviesList.Title.Contains(searchValue)).ToList();
                return APIResponse.GetSuccessMessage(HttpStatusCode.OK, pagedResponse, MessageConstants.FetchSuccessMessage);

            }
            else
            {
                return null;
            }
        }
    }
}
