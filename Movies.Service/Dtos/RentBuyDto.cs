using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Service.Dtos
{
    public class RentBuyDto:Core.RentDto
    {
        public int MovieId { get; set; }
        public double RentPrice { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ExpirationDate { get; set; }

    }
}
