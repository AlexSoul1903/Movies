namespace Movies.web.Models
{
    public class RentMovies
    {
        public int Id { get; set; }
        public int Client_id { get; set; }
        public int Movie_id { get; set; }
        public double RentPrice { get; set; }
        public DateOnly RentDate { get; set; }
        public DateOnly ExpirationDate { get; set; }
       }
    }

