namespace Movies.web.Models
{
    public class Rent
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int MovieId { get; set; }
        public double RentPrice { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ExpirationDate { get; set; }
       }
    }

