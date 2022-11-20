using Movies.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Service.Validations
{
    public class ValidationsRentInvoice
    {
        public static ServiceResult IsValidRentInvoice (RentInvoiceDto rentInvoice)
        {
            ServiceResult result = new();

            if (rentInvoice.RentId == null)
            {
                result.Success = false;
                result.Message = "RentId is required";
                return result;
            }

            if (rentInvoice.PaymentId == null)
            {
                result.Success = false;
                result.Message = "PaymentId is required";
                return result;
            }

            return result;
        }
    }
}
