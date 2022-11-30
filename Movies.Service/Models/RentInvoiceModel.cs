using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Service.Models
{
    public class RentInvoiceModel
    {
        public int Id { get; set; }
        public int PaymentId { get; set; }
        public PaymentModel? Payment { get; set; }
        public int RentId { get; set; }
        public DateTime Date { get; set; }
    }
}
