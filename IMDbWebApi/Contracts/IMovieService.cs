using IMDbWebApi.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace IMDbWebApi.Contracts
{
    public interface IMovieService
    {
        Task<List<MovieInfo>> GetMovieByNameAsync(string movieName);
        Task<List<MovieInfo>> GetAllMoviePartsAsync();

        //Task<string> GetMovieIdByTitleAsync(string movieName);
    }
}
