using Movies.DAL.Entities;
using Movies.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Service.Validations
{
    public class ValidationsSaleInvoice
    {
        public static ServiceResult IsValidSaleInvoice (SaleInvoiceDto saleInvoice)
        {
            ServiceResult result = new();

            if (saleInvoice.SaleId == null)
            {
                result.Success = false;
                result.Message = "SaleId is required";
                return result;
            }

            if (saleInvoice.PaymentId == null)
            {
                result.Success = false;
                result.Message = "PaymentId is required";
                return result;
            }

            return result;
        }
    }
}
