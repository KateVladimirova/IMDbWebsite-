using IMDbWebApi.Contracts;
using IMDbWebApi.Data.Models;
using IMDbWebApi.ViewModels;
using Microsoft.AspNetCore.Http;
//using IMDbWebApi.ViewModels;

using Newtonsoft.Json;


namespace IMDbWebApi.Services
{
    public class MovieService : IMovieService
    {
        private HttpClient httpClient;
        private readonly string imdbApiKey;
        private readonly string baseUrl;
        private readonly List<MovieInfo> movies;

        public MovieService()
        {
            httpClient = new HttpClient();
            imdbApiKey = Environment.GetEnvironmentVariable("IMDB_API_KEY");
            baseUrl = Environment.GetEnvironmentVariable("IMDB_BASE_URL");
            movies = new List<MovieInfo>();
        }

        public async Task<List<MovieInfo>> GetMovieByNameAsync(string movieName)
        {
          
            string requestUri = $"{baseUrl}3/search/movie?api_key={imdbApiKey}&query={movieName}"; //={movieName}?api_key={imdbApiKey}";

            // Make a request to the external API
            HttpResponseMessage response = await httpClient.GetAsync(requestUri);
                   
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(content))
                {
                    //Deserialize the string content to Movie object using Newtonsoft.Json
                    MovieSearchResult result = JsonConvert.DeserializeObject<MovieSearchResult>(content);

                    if (result.Results != null)
                    {
                        movies.AddRange(result.Results);
                        // return movies;
                    }
                    else
                    {
                        throw new InvalidOperationException("No movie found or error occurred");
                    }                    
                }
                else
                {
                    //handle errors
                   // Console.WriteLine($"Failed to fetch data. Status code: {response.StatusCode}");
                    throw new InvalidOperationException("No movie found or error occurred");
                }               

            }
                    return movies;
        }
        public async Task<List<MovieInfo>> GetAllMoviePartsAsync()
        {
            string requestUri = $"{baseUrl}?apikey={imdbApiKey}";

            // Make a request to the external API
            HttpResponseMessage response = await httpClient.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                // l'API retourne une liste de résultats.
                var results = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(results))
                {
                    var listOfMovies = JsonConvert.DeserializeObject<List<MovieInfo>>(results);

                    movies.AddRange(listOfMovies);
                    return movies;
                }
            }
            // Handle errors appropriately
            throw new InvalidOperationException("No movies found or error occurred");
        }

    }
}
