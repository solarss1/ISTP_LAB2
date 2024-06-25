namespace CMSWebAppLab2.Models
{
    public partial class Cinema
    {
        public int Id { get; set; }

        public string CinemaName { get; set; } = null!;

        public string Address { get; set; } = null!;

        public virtual ICollection<Hall> Halls { get; set; } = new List<Hall>();
    }

    public partial class Hall
    {
        public int Id { get; set; }

        public int CinemaId { get; set; }

        public string HallName { get; set; } = null!;

        public int MaxPlaces { get; set; }

        public virtual Cinema Cinema { get; set; } = null!;

        public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
    }

    public partial class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public short Duration { get; set; }

        public string Genre { get; set; } = null!;

        public int ReleaseYear { get; set; }

        public virtual ICollection<PersonsToMovie> PersonsToMovies { get; set; } = new List<PersonsToMovie>();

        public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
    }

    public partial class Person
    {
        public int Id { get; set; }

        public string PersonName { get; set; } = null!;

        public string TookPartAs { get; set; } = null!;

        public virtual ICollection<PersonsToMovie> PersonsToMovies { get; set; } = new List<PersonsToMovie>();
    }

    public partial class PersonsToMovie
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        public int PersonId { get; set; }

        public virtual Movie Movie { get; set; } = null!;

        public virtual Person Person { get; set; } = null!;
    }

    public partial class Session
    {
        public int Id { get; set; }

        public int HallId { get; set; }

        public int MovieId { get; set; }

        public DateTime StartTime { get; set; }

        public decimal Price { get; set; }

        public virtual Hall Hall { get; set; } = null!;

        public virtual Movie Movie { get; set; } = null!;

        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }

    public partial class Ticket
    {
        public int Id { get; set; }

        public int SessionId { get; set; }

        public int SeatNumber { get; set; }

        public DateTime SoldTime { get; set; }

        public virtual Session Session { get; set; } = null!;
    }
}
