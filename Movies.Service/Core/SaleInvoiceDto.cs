using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Service.Core
{
    public class SaleInvoiceDto : InvoiceDto
    {
        public int? SaleId { get; set; }
    }
}
