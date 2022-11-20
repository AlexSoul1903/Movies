using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Service.Models
{
    public class PaymentModel
    {
        public int Id { get; set; }
        public int CardNumber { get; set; }
        public string OwnerName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Cvv { get; set; }
    }
}
