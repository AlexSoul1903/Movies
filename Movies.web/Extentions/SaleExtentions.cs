using Movies.Service.Models;
using Movies.web.Models;

namespace Movies.web.Extentions
{
    public static class SaleExtentions
    {
        public static List<Sales> ConvertSaleModelToModel(this List<Service.Models.SaleModel> salesModels)
        {
            var mySales = salesModels.Select(sales => new Sales()
            {
                Id = sales.Id,
                ClientId = sales.ClientId,
                MovieId = sales.MovieId,
                SalePrice = sales.SalePrice,
                SaleDate = sales.SaleDate,
            }).ToList();

            return mySales;

        }
        public static List<Sales> GetSales(List<Service.Models.SaleModel> saleModels)
        {
            var mySales = saleModels.Select(sale => new Sales()
            {
                Id = sale.Id,
                ClientId = sale.ClientId,
                MovieId =sale.MovieId,
                SalePrice = sale.SalePrice,
                SaleDate = sale.SaleDate
            }).ToList();

            return mySales;

        }

        public static Models.Sales ConvertFromSaleModelToSales(this SaleModel saleModel)
        {
            return new Models.Sales()
            {
               Id = saleModel.Id,
                MovieId = saleModel.MovieId,
                ClientId = saleModel.ClientId,
                SalePrice = saleModel.SalePrice,
                SaleDate = saleModel.SaleDate

            };
        }


    }
}
