using Movies.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movies.Service.Core;
using Movies.Service.Dtos;
using Movies.Service.Responses;


namespace Movies.Service.Contracts
{
    public interface IPaymentService : IBaseService
    {
        PaymentSaveResponse SavePayment(PaymentSaveDto paymentSaveDto);
        ServiceResult RemovePayment(PaymentRemoveDto paymentRemoveDto);
        ServiceResult GetPayment();
        PaymentUpdateResponse UpdatePayment(PaymentUpdateDto paymentUpdateDto);
    }
}
