using Movies.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Service.Validations
{
   public class ValidationsClient
    {

        public static ServiceResult IsValidClient(UserDto user)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(user.Name))
            {
                result.Success = false;
                result.Message = "Client name is required.";
                return result;
            }


            if (string.IsNullOrEmpty(user.LastName))
            {
                result.Success = false;
                result.Message = "Client Last Name is required.";
                return result;
            }
            if (string.IsNullOrEmpty(user.Email)) { 
            
                result.Success = false;
                result.Message = "Client email is required.";
                return result;
            }
            if (user.Age <=0)
            {

                result.Success = false;
                result.Message = "Client age is not valid.";
                return result;
            }

            if (user.Name.Length > 25)
            {
                result.Success = false;
                result.Message = "Client name legnth is not valid.";
                return result;
            }
            if (user.Email.Length > 60)
            {
                result.Success = false;
                result.Message = "Client length email is not valid.";
                return result;
            }
            if (user.Password.Length > 40)
            {
                result.Success = false;
                result.Message = "Client password length is not valid.";
                return result;
            }


            if (user.LastName.Length > 25)
            {
                result.Success = false;
                result.Message = "Client lastname length is not valid.";
                return result;
            }

           

            return result;
        }
    }
}
