//using System;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Threading.Tasks;
//using Newtonsoft.Json;

//class Program
//{
//    static async Task Main(string[] args)
//    {
//        // Replace 'YOUR_API_KEY' with your actual TMDb API key
//        string apiKey = "YOUR_API_KEY";
//        string movieName = "Matrix"; // Replace with the movie name you want to search for

//        // List to store all found movies
//        List<MovieInfo> allMovies = new List<MovieInfo>();

//        using (HttpClient client = new HttpClient())
//        {
//            // Encode the movie name to be included in the URL
//            string encodedMovieName = Uri.EscapeDataString(movieName);

//            int currentPage = 1;
//            int totalPages = 1; // Initialize totalPages to 1 to start the loop

//            // Iterate through all pages of search results
//            while (currentPage <= totalPages)
//            {
//                string url = $"https://api.themoviedb.org/3/search/movie?api_key={apiKey}&query={encodedMovieName}&page={currentPage}";

//                HttpResponseMessage response = await client.GetAsync(url);

//                if (response.IsSuccessStatusCode)
//                {
//                    string jsonResponse = await response.Content.ReadAsStringAsync();

//                    // Deserialize the JSON response to a MovieSearchResult object
//                    MovieSearchResult searchResult = JsonConvert.DeserializeObject<MovieSearchResult>(jsonResponse);

//                    // Update totalPages if it's not already updated
//                    if (totalPages == 1)
//                        totalPages = searchResult.TotalPages;

//                    // Add found movies to the list
//                    allMovies.AddRange(searchResult.Results);
//                }
//                else
//                {
//                    Console.WriteLine($"Failed to fetch data for page {currentPage}. Status code: {response.StatusCode}");
//                    break; // Break the loop on failure
//                }

//                currentPage++; // Move to the next page
//            }

//            // Display all found movies
//            foreach (var movie in allMovies)
//            {
//                Console.WriteLine($"Title: {movie.Title}");
//                Console.WriteLine($"Overview: {movie.Overview}");
//                Console.WriteLine(); // Add a line break for readability
//            }
//        }
//    }
//}

//// Define a class representing search results for movies
//public class MovieSearchResult
//{
//    public int Page { get; set; }
//    public int TotalResults { get; set; }
//    public int TotalPages { get; set; }
//    public List<MovieInfo> Results { get; set; }
//}

//// Define a class representing movie information
//public class MovieInfo
//{
//    public string Title { get; set; }
//    public string Overview { get; set; }
//    // ... (add other properties you're interested in)
//}
