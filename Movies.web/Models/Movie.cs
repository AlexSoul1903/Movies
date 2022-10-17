using System.Drawing;

namespace Movies.web.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Front_page  { get; set; }
        public string Genre { get; set; }
        public string Rating { get; set; }
        public string Director { get; set; }
        public string Duration  { get; set; }
        public DateTime Relase_date { get; set; }
        public double? Sale_price { get; set; }
        public double? Rent_price { get; set; }
        public Bitmap Image { get; internal set; }
    }
}
