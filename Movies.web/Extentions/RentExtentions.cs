using Movies.web.Models;
using Movies.Service.Models;
using System.Collections.Generic;
using System.Linq;


namespace Movies.web.Extentions
{
    public static class RentExtentions
    {
        public static List<Rent> ConvertRentModelToModel(this List<Service.Models.RentModel> rentModels)
        {

            var myRents = rentModels.Select(rent=> new Rent()
            {
                Id = rent.Id,
                ClientId = rent.ClientId,
                RentDate  = rent.RentDate,
                MovieId = rent.MovieId,
                RentPrice = rent.RentPrice,
                ExpirationDate = rent.ExpirationDate


            }).ToList();

            return myRents;
        }


        public static List<Rent> GetRent(List<Service.Models.RentModel> rentModels)
        {
            var myRents = rentModels.Select(rent => new Rent()
            {
                Id = rent.Id,
                ClientId = rent.ClientId,
                RentDate = rent.RentDate,
                MovieId = rent.MovieId,
                RentPrice = rent.RentPrice,
                ExpirationDate = rent.ExpirationDate

            }).ToList();

            return myRents;
        }


        public static Models.Rent ConvertFromRentModelToRent(this RentModel rentModel)
        {
            return new Models.Rent()
            {
                Id = rentModel.Id,
                ClientId = rentModel.ClientId,
                RentDate = rentModel.RentDate,
                MovieId = rentModel.MovieId,
                RentPrice = rentModel.RentPrice,
                ExpirationDate = rentModel.ExpirationDate

            };
        }

    }
}
