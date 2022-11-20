using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Service.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FrontPage { get; set; }
        public string Genre { get; set; }
        public string Rating { get; set; }
        public string Director { get; set; }
        public string Duration { get; set; }
        public DateOnly RelaseDate { get; set; }
        public double? SalePrice { get; set; }
        public double? RentPrice { get; set; }
    }
}
