using System.Drawing;

namespace Movies.web.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FrontPage  { get; set; }
        public string Genre { get; set; }
        public string Rating { get; set; }
        public string Director { get; set; }
        public string Duration  { get; set; }
        public DateOnly RelaseDate { get; set; }
        public double? SalePrice { get; set; }
        public double? RentPrice { get; set; }
        public Bitmap Image { get; internal set; }
    }
}
