using Microsoft.EntityFrameworkCore;
using MoviesApp.Server.Domain;

namespace MoviesApp.Server.Infastructure
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Genre)
                .WithMany(g => g.Movies)
                .UsingEntity(j => j.ToTable("MovieGenre"));
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }   
}
