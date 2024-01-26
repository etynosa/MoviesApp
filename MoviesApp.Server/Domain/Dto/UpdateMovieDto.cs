namespace MoviesApp.Server.Domain.Dto
{
    public class  UpdateMovieDto
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
    }
}
