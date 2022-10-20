namespace Movies.web.Models
{
    public class Rent
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int MovieId { get; set; }
        public double RentPrice { get; set; }
        public DateOnly RentDate { get; set; }
        public DateOnly ExpirationDate { get; set; }
       }
    }

