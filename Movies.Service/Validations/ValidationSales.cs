

using Movies.Service.Core;

namespace Movies.Service.Validations
{
    public class ValidationSales
    {
        public static ServiceResult IsValidSale(SaleDto sale)
        {
            ServiceResult result = new();

            if (sale.SaleDate.Equals(null))
            {
                result.Success = false;
                result.Message = "Sale date is required";
                return result;
            }
            if (sale.SalePrice.Equals(null))
            {
                result.Success = false;
                result.Message = "Sale Price is required";
                return result;
            }
            if (sale.CreationDate.Equals(null))
            {
                result.Success = false;
                result.Message = "Sale Price is required";
                return result;
            }
            if (sale.MovieId.Equals(null))
            {
                result.Success = false;
                result.Message = "Sale Price is required";
                return result;
            }
            if (sale.ClientId.Equals(null))
            {
                result.Success = false;
                result.Message = "Sale Price is required";
                return result;
            }


            return result;
        }

    }
}
