namespace Movies.web.Models
{
    public class Payment
    {
        public Int64 CardNumber { get; set; }
        public string OwnerName { get; set; }
        public int DateOfExpiry { get; set; }
        public int Cvv { get; set; }
    }
}
