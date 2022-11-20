using Movies.Service.Core;
using Movies.Service.Dtos;
using Movies.Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Service.Contracts
{
    public interface IRentInvoiceService : IBaseService
    {
        public RentInvoiceSaveResponse Save(RentInvoiceSaveDto dto);
        public RentInvoiceUpdateResponse Update(RentInvoiceUpdateDto dto);
        public RentInvoiceDeleteResponse Remove (RentInvoiceRemoveDto dto);
    }
}
