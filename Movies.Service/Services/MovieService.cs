using Movies.DAL.Entities;
using Movies.DAL.Interfaces;
using Movies.Service.Contracts;
using Movies.Service.Core;
using Movies.Service.Dtos;
using Movies.Service.Models;
using Movies.Service.Responses;
using Movies.Service.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Service.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMoviesRepository moviesRepository;
        private readonly ILoggerService<MovieService> logger;

        public MovieService(IMoviesRepository moviesRepository, ILoggerService<MovieService> logger)
        {

            this.moviesRepository = moviesRepository;
            this.logger = logger;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new();
            try
            {
                var movies = moviesRepository.GetEntities();

                result.Data = movies.Select(movie => new MovieModel()
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    Director = movie.Director,
                    Duration = movie.Duration,
                    FrontPage = movie.FrontPage,
                    Genre = movie.Genre,
                    Rating = movie.Rating,
                    ReleaseDate = movie.ReleaseDate,
                    RentPrice = movie.RentPrice,
                    SalePrice = movie.SalePrice,
                }).ToList();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error getting the movies";
                this.logger.LogError($"{result.Message}: {ex.Message}");
                throw;
            }

            return result;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new();
            try
            {
                var movie = moviesRepository.GetEntity(Id);

                result.Data = new MovieModel()
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    Director = movie.Director,
                    Duration = movie.Duration,
                    FrontPage = movie.FrontPage,
                    Genre = movie.Genre,
                    Rating = movie.Rating,
                    ReleaseDate = movie.ReleaseDate,
                    RentPrice = movie.RentPrice,
                    SalePrice = movie.SalePrice,
                };
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error getting the movie";
                this.logger.LogError($"{result.Message}: {ex.Message}");
                throw;
            }

            return result;
        }

        public MovieSaveResponse Save(MovieSaveDto dto)
        {
            MovieSaveResponse result = new();
            try
            {
                var resultIsValidMovie = ValidationsMovie.IsValidMovie(dto);

                if (!resultIsValidMovie.Success)
                {
                    result.Success = resultIsValidMovie.Success;
                    result.Message = resultIsValidMovie.Message;
                    return result;
                }

                if (moviesRepository.Exists(movie => movie.Name == dto.Name))
                {
                    result.Success = false;
                    result.Message = "This movie is alredy registered.";
                    return result;
                }

                var movieToSave = new Movie()
                {
                    Name = dto.Name,
                    Genre = dto.Genre,
                    ReleaseDate = dto.ReleaseDate,
                    Duration = dto.Duration,
                    Rating = dto.Rating,
                    FrontPage = dto.FrontPage,
                    Director = dto.Director,
                    RentPrice = dto.RentPrice,
                    SalePrice = dto.SalePrice,
                    CreationDate = DateTime.Now
                };

                moviesRepository.Save(movieToSave);

                result.Message = "Movie saved successfully";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error saving the movie";
                this.logger.LogError($"{result.Message}: {ex.Message}");
                throw;
            }

            return result;
        }

   MovieUpdateResponse IMovieService.Update(MovieUpdateDto dto)
        {
            MovieUpdateResponse result = new MovieUpdateResponse();
            try
            {
                var movieToUpdate = moviesRepository.GetEntity(dto.Id);
                movieToUpdate.Id = dto.Id;
                movieToUpdate.UpdatedDate = DateTime.Now;
                movieToUpdate.Name = dto.Name;
                movieToUpdate.Rating = dto.Rating;
                movieToUpdate.ReleaseDate = dto.ReleaseDate;
                movieToUpdate.RentPrice = dto.RentPrice;
                movieToUpdate.SalePrice = dto.SalePrice;
                movieToUpdate.FrontPage = dto.FrontPage;
                movieToUpdate.Genre = dto.Genre;
                movieToUpdate.Director = dto.Director;
                movieToUpdate.Duration = dto.Duration;
              
              
                  
                moviesRepository.Update(movieToUpdate);

                result.Message = "Movie updated successfully";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error updating the movie";
                this.logger.LogError($"{result.Message}: {ex.Message}");
                throw;
            }

            return result;
        }

        public MovieDeleteResponse Remove(MovieRemoveDto dto)
        {
            MovieDeleteResponse result = new();
            try
            {
                var movieToDelete = moviesRepository.GetEntity(dto.Id);

                movieToDelete.DeletedDate = DateTime.Now;

                moviesRepository.Remove(movieToDelete);

                result.Message = "Movie deleted successfully";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error deleting the movie";
                this.logger.LogError($"{result.Message}: {ex.Message}");
                throw;
            }

            return result;
        }
    }
}
