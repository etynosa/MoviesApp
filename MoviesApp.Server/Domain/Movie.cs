using Microsoft.EntityFrameworkCore.Storage;
using MoviesApp.Server.Common.Types;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Server.Domain
{

    public class Movie : BaseEntity<string>
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public string Description { get; set; }
        public List<Genre> Genre { get; set; }
        public float Rating { get; set; }
        public string Country { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float TicketPrice { get; set; }  

        public Movie() : base(Guid.NewGuid().ToString())
        {
        }
    }
}
