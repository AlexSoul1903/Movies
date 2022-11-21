using Movies.DAL.Interfaces;
using Movies.DAL.Repositories;
using Movies.Service.Contracts;
using Movies.Service.Core;
using Movies.Service.Dtos;
using Movies.Service.Models;
using Movies.Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Service.Services
{
    public class RentService : IRentService
    {
        private readonly IRentRepository rentRepository;
        private readonly ILoggerService<RentService> logger;

        public RentService(IRentRepository rentRepository, ILoggerService<RentService> logger)
        {

            this.rentRepository = rentRepository;
            this.logger = logger;
        }


        public ServiceResult GetAll()
        {

            ServiceResult result = new ServiceResult();

            try
            {
                var rent= rentRepository.GetEntities();
                result.Data = rent.Select(st => new Models.RentModel()
                {
                    Id = st.Id,
                    ClientId = st.ClientId,
                    MovieId = st.MovieID,
                    RentPrice = st.RentPrice,
                    ExpirationDate= st.ExpirationDate,
                    RentDate=st.RentDate,
                   

                }).ToList();


            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error: The system can't get the rent";
                this.logger.LogError($"{result.Message}{ex.Message}", ex.ToString());

            }

            return result;





        }

        public ServiceResult GetById(int Id)
        {

            ServiceResult result = new ServiceResult();

            try
            {
                DAL.Entities.Rent rent = rentRepository.GetEntity(Id);
                RentModel model = new RentModel()
                {
                    Id = rent.Id,
                    ClientId = rent.ClientId,
                    MovieId = rent.MovieID,
                    RentDate = rent.RentDate,
                    RentPrice = rent.RentPrice,
                    ExpirationDate= rent.ExpirationDate
                };
                result.Data = model;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error: The system can't get the Rent Id.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;



        }

        public ServiceResult GetRent(RentDto rentDto)
        {
            ServiceResult result = new ServiceResult();


            try
            {

                var rent = rentRepository.GetEntities();

                result.Data = rent.Select(st => new Models.RentModel()
                {
                    Id = st.Id,
                    ClientId = st.ClientId,
                    MovieId = st.MovieID,
                    RentDate = st.RentDate,
                    RentPrice=st.RentPrice,
                    ExpirationDate=st.ExpirationDate
                });

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error: The system can't get the rent";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }

            return result;



        }

        public RentBuyResponse RentMovie(RentBuyDto rentBuyDto)
        {

            ServiceResult result = new ServiceResult();
            RentBuyResponse resultRent = new RentBuyResponse();
            try
            {

                DAL.Entities.Rent RentToAdd = new DAL.Entities.Rent()
                {
                    Id = (int)rentBuyDto.Id,
                   ClientID = rentBuyDto.ClientId,
                   MovieID  = rentBuyDto.MovieId,
                   RentDate=DateTime.Now,
                    RentPrice=rentBuyDto.RentPrice,
                    CreationDate = DateTime.Now
                };

                rentRepository.Save(RentToAdd);

                resultRent.Id = RentToAdd.Id;
                resultRent.ClientId = RentToAdd.ClientID;
                resultRent.MovieId = RentToAdd.MovieID;
                resultRent.SalePrice = RentToAdd.RentPrice;
        
            


                result.Message = "Rent succesful";


            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error to complete the rent";
                this.logger.LogError($"{ex.Message}", ex.ToString());

            }
            return resultRent;




        }
    }
}
