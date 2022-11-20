using Movies.Service.Core;
using Movies.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Service.Validations
{
    public class ValidationsPayment
    {
        public static ServiceResult IsValidPayment(PaymentDto payment)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(payment.OwnerName))
            {
                result.Success = false;
                result.Message = "Owner name is required";
                return result;
            }
            
            if (payment.OwnerName.Length >30 )
            {
                result.Success = false;
                result.Message = "Owner name length is not valid.";
                return result;
            }
            return result;
        }

    }
}
