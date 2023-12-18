namespace IMDbWebApi.Data.Models
{
    public class Director
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}
