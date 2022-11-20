using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Service.Core
{
    public class PaymentDto : DtoAudit
    {
        public int CardNumber { get; set; }
        public string OwnerName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Cvv { get; set; }
    }
}
