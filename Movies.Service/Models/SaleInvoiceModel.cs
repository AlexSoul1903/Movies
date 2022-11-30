using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Service.Models
{
    public class SaleInvoiceModel
    {
        public int Id { get; set; }
        public int PaymentId { get; set; }
        public PaymentModel? Payment { get; set; }
        public int SaleId { get; set; }
        DateTime Date { get; set; }
    }
}
