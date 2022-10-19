namespace Movies.web.Models
{
    public class Sales
    {

        public int Id { get; set; }
        public int Client_id { get; set; }
        public int Movie_id { get; set; }
        public double SalePrice { get; set; }
        public DateOnly SaleDate { get; set; }
  
    }
}
