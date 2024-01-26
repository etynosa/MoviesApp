using MoviesApp.Server.Common.Types;

namespace MoviesApp.Server.Domain
{
    public class Genre : BaseEntity<string>
    {
        public Genre() : base(Guid.NewGuid().ToString())
        {
        }

        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
        public string Description { get; set; }
    }
}
