using Movies.Service.Core;
using Movies.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Service.Validations
{
    public class ValidationsRent
    {
        public static ServiceResult IsValidRent(RentSaveDto rent)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(rent.Name))
            {
                result.Success = false;
                result.Message = "Client name is required.";
                return result;
            }


            if (string.IsNullOrEmpty(rent.LastName))
            {
                result.Success = false;
                result.Message = "Client Last Name is required.";
                return result;
            }
            if (string.IsNullOrEmpty(rent.Email))
            {

                result.Success = false;
                result.Message = "Client email is required.";
                return result;
            }
            if (rent.Age <= 0)
            {

                result.Success = false;
                result.Message = "Client age is not valid.";
                return result;
            }

            if (rent.Name.Length > 25)
            {
                result.Success = false;
                result.Message = "Client name legnth is not valid.";
                return result;
            }
            if (rent.Email.Length > 60)
            {
                result.Success = false;
                result.Message = "Client length email is not valid.";
                return result;
            }
            if (rent.Password.Length > 40)
            {
                result.Success = false;
                result.Message = "Client password length is not valid.";
                return result;
            }


            if (rent.LastName.Length > 25)
            {
                result.Success = false;
                result.Message = "Client lastname length is not valid.";
                return result;
            }



            return result;
        }
    }
}
