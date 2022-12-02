using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Service.Dtos
{
    public class SaleBuyDto: Core.SaleDto
    {
        public int id { get; set; }
        public DateTime SaleDate { get; set; }
        public int MovieId { get; set; }
        public double SalePrice { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
