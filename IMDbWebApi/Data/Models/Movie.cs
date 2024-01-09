using System.Security.Principal;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace IMDbWebApi.Data.Models
{
    public class Movie
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } = null!;

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; } = null!;

        [JsonProperty(PropertyName = "overview")]
        public string? Overview { get; set; }

        [JsonProperty(PropertyName = "poster_path")]
        public string? ImgUrl { get; set; }

        [JsonProperty(PropertyName = "release_date")]
        public string Year { get; set; }


        [JsonProperty(PropertyName = "popularity")]
        public double Rating { get; set; }

        //[JsonProperty(PropertyName = "Director")]
        //public string Director { get; set; } = null!;

        //[JsonProperty(PropertyName = "Genre")]
        //public Genre Genre { get; set; }
       // public List<Actor> Actors { get; set; } = new List<Actor>();
        //public List<Writer> Writers { get; set; } = new List<Writer>();

    }
}
