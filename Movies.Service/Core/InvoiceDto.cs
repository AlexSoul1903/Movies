using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Service.Core
{
    public class InvoiceDto : BaseDto
    {
        public int? PaymentId { get; set; }

    }
}
