using System.Security.Principal;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace IMDbWebApi.Data.Models
{
    public class Movie
    {
        [JsonProperty(PropertyName = "imdbID")]
        public string Id { get; set; } = null!;

        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; } = null!;

        [JsonProperty(PropertyName = "Plot")]
        public string? Description { get; set; }

        [JsonProperty(PropertyName = "Poster")]
        public string? ImgUrl { get; set; }

        [JsonProperty(PropertyName = "Year")]
        public int Year { get; set; }


        [JsonProperty(PropertyName = "imdbRating")]
        public double Rating { get; set; }

        [JsonProperty(PropertyName = "Director")]
        public string Director { get; set; } = null!;

        [JsonProperty(PropertyName = "Genre")]
        public Genre Genre { get; set; }
       // public List<Actor> Actors { get; set; } = new List<Actor>();
        //public List<Writer> Writers { get; set; } = new List<Writer>();

    }
}
