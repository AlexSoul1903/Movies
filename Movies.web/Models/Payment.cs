namespace Movies.web.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int CardNumber { get; set; }
        public string OwnerName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Cvv { get; set; }
    }
}
