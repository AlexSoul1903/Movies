using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Service.Dtos
{
    public class SalesUpdateDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime SaleDate { get; set; }
        public int MovieId { get; set; }
        public double SalePrice { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
