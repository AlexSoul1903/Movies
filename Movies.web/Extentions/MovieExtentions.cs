using Movies.web.Models;

using Movies.Service.Models;
using System.Collections.Generic;
using System.Linq;


namespace Movies.web.Extentions
{
    public static class MovieExtentions
    {

        public static List<Movie> ConvertMovieModelToModel(this List<Service.Models.MovieModel> movieModels)
        {
            var myMovies = movieModels.Select(movie => new Movie()
            {
             Director=movie.Director,
             Duration=movie.Duration,
             FrontPage=movie.FrontPage,
             Genre=movie.Genre,
             Id=movie.Id,
            ReleaseDate=movie.ReleaseDate,
             SalePrice =movie.SalePrice,
             Name=movie.Name,
             Rating=movie.Rating,
             RentPrice=movie.RentPrice,
             
             
            }).ToList();

            return myMovies;

        }


        public static List<Movie> GetMovies(List<Service.Models.MovieModel> movieModels)
        {
            var myMovies = movieModels.Select(movie => new Movie()
            {
                Director = movie.Director,
                Duration = movie.Duration,
                FrontPage = movie.FrontPage,
                Genre = movie.Genre,
                Id = movie.Id,
                ReleaseDate = movie.ReleaseDate,
                SalePrice = movie.SalePrice,
                Name = movie.Name,
                Rating = movie.Rating,
                RentPrice = movie.RentPrice,
            }).ToList();

            return myMovies;

        }

        public static Models.Movie ConvertFromMovieModelToMovie(this MovieModel movieModel)
        {
            return new Models.Movie()
            {
                Director = movieModel.Director,
                Duration = movieModel.Duration,
                FrontPage = movieModel.FrontPage,
                Genre = movieModel.Genre,
                Id = movieModel.Id,
                ReleaseDate = movieModel.ReleaseDate,
                SalePrice = movieModel.SalePrice,
                Name = movieModel.Name,
                Rating = movieModel.Rating,
                RentPrice = movieModel.RentPrice
                

            };
        }





    }
}
