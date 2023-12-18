using IMDbWebApi.Contracts;
using IMDbWebApi.Data.Models;
using Newtonsoft.Json;

namespace IMDbWebApi.Services
{
    public class MovieService : IMovieService
    {
        private HttpClient httpClient;
        private readonly string imdbApiKey;
        private readonly string baseUrl;

        public MovieService()
        {
            httpClient = new HttpClient();
            imdbApiKey = System.Environment.GetEnvironmentVariable("IMDB_API_KEY");
            baseUrl = System.Environment.GetEnvironmentVariable("IMDB_BASE_URL");
        }

        public async Task<Movie> GetMovieByNameAsync(string movieName)
        {
          
            string requestUri = $"{baseUrl}?apikey={imdbApiKey}&t={movieName}";

            // Make a request to the external API
            HttpResponseMessage response = await httpClient.GetAsync(requestUri);
                   
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                //Deserialize the string content to Movie object using Newtonsoft.Json
                var movie = JsonConvert.DeserializeObject<Movie>(content);

                return movie;
            }

            // Return null or handle errors appropriately
            throw new InvalidOperationException("No movie found or error occurred");
        }
        public async Task<List<Movie>> GetAllMoviesAsync()
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
                    List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(results);
                
                    if(movies != null && movies.Any())
                    {
                        return movies;
                    }                    
                }
            }
            // Handle errors appropriately
            throw new InvalidOperationException("No movies found or error occurred");
        }

    }
}
