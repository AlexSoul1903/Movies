using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Service.Exceptions
{
    public class RentInvoiceException : Exception
    {
        public RentInvoiceException (string Message) : base(Message)
        {

        }
    }
}
