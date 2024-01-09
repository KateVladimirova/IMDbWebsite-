using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace IMDbWebApi.Data.Models
{
    public class MovieInfo
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } = null!;

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; } = null!;

        [JsonProperty(PropertyName = "poster_path")]
        public string? ImgUrl { get; set; }

        //[JsonProperty(PropertyName = "release_date")]
        //public string Year { get; set; }

        //[JsonProperty(PropertyName = "popularity")]
        //public double Rating { get; set; }
    }
}
