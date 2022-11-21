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
    public interface IRentService:IBaseService
    {
        RentBuyResponse RentMovie(RentBuyDto rentBuyDto);
        ServiceResult GetRent(RentDto rentDto);

    }
}
