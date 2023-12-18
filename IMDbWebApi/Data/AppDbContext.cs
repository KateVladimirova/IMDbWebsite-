using IMDbWebApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace IMDbWebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):
            base(options)
        {


        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Actor> Actors { get; set; }

    }
}
