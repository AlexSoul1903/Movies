namespace Movies.web.Models
{
    public class Sales
    {

        public int Id { get; set; }
        public int ClientId { get; set; }
        public int MovieId { get; set; }
        public double SalePrice { get; set; }
        public DateTime SaleDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }

    }
}
