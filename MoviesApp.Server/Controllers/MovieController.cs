using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Server.Common.Pagination;
using MoviesApp.Server.Common.Types;
using MoviesApp.Server.Domain.Dto;
using MoviesApp.Server.Infastructure.Repositories.Interface;
using MoviesApp.Server.Service.Interface;

namespace MoviesApp.Server.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MovieController(IMovieService movieService) : ControllerBase
    {

        /// <summary>
        /// Creates a new movie.
        /// </summary>
        /// <param name="movie">The movie data.</param>
        /// <returns>The created movie.</returns>
        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateMovie([FromBody] CreateMovieDto movie)
        {
            var result = await movieService.CreateMovie(movie);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves all movies.
        /// </summary>
        /// <returns>All movies.</returns>
        [HttpGet]
        [Route("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetAllMovies()
        {
            var result = await movieService.GetMovies();
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a movie by its ID.
        /// </summary>
        /// <param name="id">The ID of the movie to retrieve.</param>
        /// <returns>The movie with the specified ID.</returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<APIResponse>> GetMovieById([FromQuery]string id)
        {
            var result = await movieService.GetMovieById(id);
            return Ok(result);
        }

        /// <summary>
        /// Updates an existing movie.
        /// </summary>
        /// <param name="movie">The updated movie data.</param>
        /// <returns>The updated movie.</returns>
        [HttpPut]
        public async Task<ActionResult<APIResponse>> UpdateMovie([FromBody] UpdateMovieDto movie)
        {
            var result = await movieService.UpdateMovie(movie);
            return Ok(result);
        }

        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<APIResponse>> SearchMovies([FromQuery] string title, [FromQuery] string genre, [FromQuery] string actor)
        {
            var result = await movieService.SearchMovie(title);
            return Ok(result);
        }

        [HttpGet]
        [Route("filter")]
        public async Task<ActionResult<APIResponse>> FilterMovies([FromQuery] PaginationParameter pagefilter)
        {
            var result = await movieService.GetAllMoviesAsync(pagefilter);
            return Ok(result);
        }
    }
}
