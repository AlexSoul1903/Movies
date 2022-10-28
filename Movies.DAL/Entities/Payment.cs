using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DAL.Entities
{
    public class Payment : Core.BaseEntity
    {
        public int Id { get; set; }
        public int Cardnumber { get; set; }
        public string OwnerName { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public int Cvv { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; } 

    }
}
