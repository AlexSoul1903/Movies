using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DAL.Entities
{
    public class SaleInvoice: Core.Invoice
    {
        public int SaleId { get; set; }
    }
}
