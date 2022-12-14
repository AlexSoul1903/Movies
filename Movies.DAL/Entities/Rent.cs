using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DAL.Entities
{
    public class Rent : Core.BaseEntity
    {
     
        public int ClientId { get; set; }
        public int MovieID { get; set; }
        public double RentPrice{ get; set; }
        public DateTime RentDate{ get; set; }
        public DateTime ExpirationDate{ get; set; }
    }
}
