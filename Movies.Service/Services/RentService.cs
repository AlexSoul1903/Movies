using Movies.Service.Contracts;
using Movies.Service.Core;
using Movies.Service.Dtos;
using Movies.Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movies.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using Movies.Service.Exceptions;
using Movies.Service.Models;
using Movies.Service.Validations;
using Movies.Service.Contracts;

namespace Movies.Service.Services
{
    public class RentService
    {
        private readonly IRentRepository rentRepository;
        private readonly ILogger<RentService> logger;
        public RentService(IRentRepository rentRepository, ILogger<RentService> logger)
        {

            this.rentRepository = rentRepository;
            this.logger = logger;
        }

        public ServiceResult GetAll()
        {

            ServiceResult result = new ServiceResult();

            try
            {
                var rents = rentRepository.GetEntities();

                result.Data = rents.Select(st => new Models.RentModel()
                {
                    ID = st.ID,
                    ClientID = st.ClientID,
                    RentPrice = st.RentPrice,
                    RentDate = st.RentDate,
                    ExpirationDate = st.ExpirationDate

                }).ToList();

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error getting the rents";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
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
                   ID= rent.ID,
                   ClientID = rent.ClientID,
                   RentPrice = rent.RentPrice,
                   RentDate = rent.RentDate,
                   ExpirationDate = rent.ExpirationDate
                };

                result.Data = model;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error getting the rent Id.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;

        }
        public ServiceResult GetRents()
        {
            ServiceResult result = new ServiceResult();


            try
            {

                var rent = rentRepository.GetEntities();

                result.Data = rent.Select(st => new Models.RentModel()
                {
                    ID = st.ID,
                    ClientID = st.ClientID,
                    RentPrice = st.RentPrice,
                    RentDate = st.RentDate,
                    ExpirationDate = st.ExpirationDate

                });

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error getting the rents";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult RemoveRent(RentRemoveDto rentRemoveDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {


                RentSaveResponse client = new RentSaveResponse();

                DAL.Entities.Rent rentToRemove = rentRepository.GetEntity(rentRemoveDto.Id);

                rentToRemove.Id = rentRemoveDto.Id;
                rentToRemove.DeletedDate = DateTime.Now;

                rentRepository.Remove(rentToRemove);

                result.Message = "The rent was deleted";


            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error deleting the rent";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());


            }

            return result;

        }

        public RentSaveResponse SaveRent(RentSaveDto rentSaveDto)
        {
            RentSaveResponse result = new RentSaveResponse();

            try
            {

                var resutlIsValid = ValidationsRent.IsValidRent(rentSaveDto);

                if (resutlIsValid.Success)
                {
         

                    DAL.Entities.Rent RentToAdd = new DAL.Entities.Rent()
                    {
                        ID = rentSaveDto.Id,
                        ClientID = rentSaveDto.ClientID,
                        RentPrice = rentSaveDto.RentPrice,
                        RentDate = rentSaveDto.RentDate,
                        ExpirationDate = rentSaveDto.ExpirationDate
                    };

                    rentRepository.Save(RentToAdd);

                    result.ID = RentToAdd.Id;

                    result.Message = "The rent was added successfully";

                }

                else
                {
                    result.Success = resutlIsValid.Success;
                    result.Message = resutlIsValid.Message;
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error adding the rent";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }
            return result;
        }

        RentUpdateResponse IRentService.UpdateRent(RentUpdateDto rentUpdateDto)
        {

            RentUpdateResponse result = new RentUpdateResponse();

            try
            {


                var resultIsValid = ValidationsClient.IsValidClient(rentUpdateDto);

                if (resultIsValid.Success)
                {


                    DAL.Entities.Rent rentToUpdate = rentRepository.GetEntity(rentUpdateDto.Id); // Se busca el estudiante a actualizar //

                    rentToUpdate.ID = rentUpdateDto.Id;
                    rentToUpdate.ClientID = rentUpdateDto.ClientID;
                    rentToUpdate.RentPrice = rentUpdateDto.RentPrice;
                    rentToUpdate.RentDate = rentUpdateDto.RentDate;
                    rentToUpdate.ExpirationDate = rentUpdateDto.ExpirationDate;
                    rentToUpdate.UpdatedDate = DateTime.Now;
                    rentRepository.Update(rentToUpdate);

                    result.Message = "Rent updated successfully";
                }


                else
                {
                    result.Success = false;
                    result.Message = resultIsValid.Message;
                }

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error updating the rent";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }

            return result;




        }


    }
}
