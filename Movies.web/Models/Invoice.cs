namespace Movies.web.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public Payment PaymentInfo { get; set; }
        public DateOnly Date { get; set; }
    }
}
