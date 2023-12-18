using IMDbWebApi.Contracts;
using IMDbWebApi.Data.Models;
using IMDbWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace IMDbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService movieService;
        

        public MovieController(IMovieService _movieService)
        {
            movieService = _movieService;           
        }

        [HttpGet("movieName")]
        public async Task<ActionResult<Movie>> GetMovieByNameAsync(string movieName)
        {
             
            var movie = await movieService.GetMovieByNameAsync(movieName);

            if (movie == null)
            { 
                return NotFound(); // Movie not found
            }

            return Ok(movie); // Return the found movie
        }

        [HttpGet("allmovies")]
        public async Task<ActionResult<List<Movie>>> GetAllMoviesAsync()
        {

            var movies = await movieService.GetAllMoviesAsync();
            return Ok(movies);
        }


        //[HttpPost]
        //public async Task<ActionResult<List<Movie>>> AddMovie(Movie movie)
        //{
        //    movies.Add(movie);
        //    return Ok(movies);
        //}

        //[HttpGet("{id}")]
        //public async Task<string> GetMovieIdByTitle(string id)
        //{
        //    return await movieService.GetMovieIdByTitleAsync(movieId);
        //    movi
        //}

    }
}
