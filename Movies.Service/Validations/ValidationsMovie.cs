using Movies.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Service.Validations
{
    public class ValidationsMovie
    {
        public static ServiceResult IsValidMovie (MovieDto movie)
        {
            ServiceResult result = new();

            if (string.IsNullOrEmpty(movie.Name))
            {
                result.Success = false;
                result.Message = "Movie name is required";
                return result;
            }

            if (string.IsNullOrEmpty(movie.Genre))
            {
                result.Success = false;
                result.Message = "Movie genre is required";
                return result;
            }

            if (string.IsNullOrEmpty(movie.FrontPage))
            {
                result.Success = false;
                result.Message = "Movie front page is required";
                return result;
            }
            
            if (string.IsNullOrEmpty(movie.Director)) {
                result.Success = false;
                result.Message = "Movie director is required";
                return result;
            }

            if (string.IsNullOrEmpty(movie.Duration))
            {
                result.Success = false;
                result.Message = "Movie duration is required";
                return result;
            }

            return result;
        }
    }
}
