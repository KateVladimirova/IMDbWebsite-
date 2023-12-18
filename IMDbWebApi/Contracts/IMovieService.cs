using IMDbWebApi.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace IMDbWebApi.Contracts
{
    public interface IMovieService
    {
        Task<Movie> GetMovieByNameAsync(string movieName);
        Task<List<Movie>> GetAllMoviesAsync();

        //Task<string> GetMovieIdByTitleAsync(string movieName);
    }
}
