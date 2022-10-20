namespace Movies.web.Models
{
    public class Sales
    {

        public int Id { get; set; }
        public int ClientId { get; set; }
        public int MovieId { get; set; }
        public double SalePrice { get; set; }
        public DateOnly SaleDate { get; set; }
  
    }
}
