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
    public interface ISalesService : IBaseService
    {
         SalesDeleteResponse DeleteSale(SalesDeleteDto saleDeleteDto);
        SalesUpdateResponse UpdateSale(SalesUpdateDto saleUpdateDto);
        SalesBuyResponse SaleResponse(SaleBuyDto saleBuyDto);
        ServiceResult GetSale(SaleDto saleDto);
    }
}
