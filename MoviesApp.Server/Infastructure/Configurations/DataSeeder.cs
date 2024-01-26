using MoviesApp.Server.Domain;

namespace MoviesApp.Server.Infastructure.Configurations
{
    public class DataSeeder
    {
        private readonly MovieDbContext _context;

        public DataSeeder(MovieDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            if (!_context.Movies.Any())
            {
                var movies = new List<Movie>
                {
                     new Movie
                    {
                        Title = "Inception",
                        Director = "Christopher Nolan",
                        Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.",
                        Genre = new List<Genre> { new Genre { Name = "Action", Description = "Test" }, new Genre { Name = "Adventure", Description = "Test" }, new Genre { Name = "Sci-Fi", Description = "Test" } },
                        Rating = 8.8f,
                        Country = "USA",
                        PhotoUrl = "https://www.example.com/inception.jpg",
                        ReleaseDate = new DateTime(2010, 7, 16)
                    },
                    new Movie
                    {
                        Title = "Forrest Gump",
                        Director = "Robert Zemeckis",
                        Description = "The presidencies of Kennedy and Johnson, the events of Vietnam, Watergate, and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.",
                        Genre = new List<Genre> { new Genre { Name = "Drama", Description = "Test" }, new Genre { Name = "Romance", Description = "Test" } },
                        Rating = 8.8f,
                        Country = "USA",
                        PhotoUrl = "https://www.example.com/forrest_gump.jpg",
                        ReleaseDate = new DateTime(1994, 7, 6)
                    },
                    new Movie
                    {
                        Title = "The Dark Knight",
                        Director = "Christopher Nolan",
                        Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
                        Genre = new List<Genre> { new Genre { Name = "Action" , Description = "Test"}, new Genre { Name = "Crime", Description = "Test" }, new Genre { Name = "Drama", Description = "Test" } },
                        Rating = 9.0f,
                        Country = "USA",
                        PhotoUrl = "https://www.example.com/the_dark_knight.jpg",
                        ReleaseDate = new DateTime(2008, 7, 18)
                    },
                    new Movie
                    {
                        Title = "Pulp Fiction",
                        Director = "Quentin Tarantino",
                        Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                        Genre = new List<Genre> { new Genre { Name = "Crime", Description = "Test" }, new Genre { Name = "Drama", Description = "Test" } },
                        Rating = 8.9f,
                        Country = "USA",
                        PhotoUrl = "https://www.example.com/pulp_fiction.jpg",
                        ReleaseDate = new DateTime(1994, 10, 14)
                    },
                };

                _context.Movies.AddRange(movies);
                _context.SaveChanges();
            }
        }
    }
}
