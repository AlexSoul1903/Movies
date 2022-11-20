using Movies.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Service.Responses
{
    public class SaleInvoiceResponse : Core.ServiceResult
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public int PaymentId { get; set; }

        public PaymentModel? Payment { get; set; }

        public int SaleId { get; set; }
    }
}
