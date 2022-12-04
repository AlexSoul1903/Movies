using Movies.DAL.Entities;
using Movies.DAL.Interfaces;
using Movies.DAL.Repositories;
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
    public class SalesService : ISalesService
    {
        private readonly ISalesRepository salesRepository;
        private readonly ILoggerService<SalesService> logger;

        public SalesService(ISalesRepository salesRepository, ILoggerService<SalesService> logger)
        {

            this.salesRepository = salesRepository;
            this.logger = logger;
        }
        public SalesBuyResponse SaleResponse(SaleBuyDto saleBuyDto)
        {
            SalesBuyResponse resultSale = new SalesBuyResponse();
            try
            {

                var resutlIsValid = ValidationSales.IsValidSale(saleBuyDto);
                if (resutlIsValid.Success)
                {

                    DAL.Entities.Sales SaleToAdd = new DAL.Entities.Sales()
                    {
                        ClientId = saleBuyDto.ClientId,
                        MovieId = saleBuyDto.MovieId,
                        SaleDate = saleBuyDto.SaleDate,
                        SalePrice = saleBuyDto.SalePrice,
                        CreationDate = DateTime.Now,
                    };

                    salesRepository.Save(SaleToAdd);

                    resultSale.Message = "Sale saved successfully";
                }
            
            }

            catch (Exception ex)
            {
                 resultSale.Success= false;
                 resultSale.Message= "Error to complete the sale";
                this.logger.LogError($"{ex.Message}", ex.ToString());

            }
            return resultSale;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var sale = salesRepository.GetEntities();
                result.Data = sale.Select(st => new Models.SaleModel()
                {
                    Id = st.Id,
                    ClientId = st.ClientId,
                    MovieId = st.MovieId,
                    SaleDate = st.SaleDate,
                    SalePrice = st.SalePrice,


                }).ToList();


            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error: The system can't get the sale";
                this.logger.LogError($"{result.Message}{ex.Message}", ex.ToString());

            }

            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                DAL.Entities.Sales sale = salesRepository.GetEntity(id);
                SaleModel model = new()
                {
                    Id=sale.Id,
                    ClientId = sale.ClientId,
                    MovieId = sale.MovieId,
                    SaleDate = sale.SaleDate,
                    SalePrice = sale.SalePrice
                };
                result.Data = model;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error: The system can't get the Sale Id.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetSale(SaleDto saleDto)
        {
            ServiceResult result = new ServiceResult();


            try
            {

                var sale = salesRepository.GetEntities();

                result.Data = sale.Select(st => new Models.SaleModel()
                {
                    Id = st.Id,
                    ClientId = st.ClientId,
                    MovieId = st.MovieId,
                    SaleDate = st.SaleDate,
                    SalePrice = st.SalePrice
                });

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error: The system can't get the sale";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }

            return result;
        }

        public SalesDeleteResponse DeleteSale(SalesDeleteDto saleDeleteDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {


                SalesBuyResponse sales = new SalesBuyResponse();

                DAL.Entities.Sales saleToDelete = salesRepository.GetEntity(saleDeleteDto.Id);

                saleToDelete.Id = saleToDelete.Id;
                saleToDelete.DeletedDate = DateTime.Now;

                salesRepository.Remove(saleToDelete);

                result.Message = "The Sale was deleted";


            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error delenting the Sale";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());


            }

            return (SalesDeleteResponse)result;

        }

        public SalesUpdateResponse UpdateSale(SalesUpdateDto saleUpdateDto)
        {
            SalesUpdateResponse result = new SalesUpdateResponse();

            try
            {
                

                        DAL.Entities.Sales saleToUpdate = salesRepository.GetEntity(saleUpdateDto.Id);
                        saleToUpdate.ClientId = saleUpdateDto.ClientId; 
                        saleToUpdate.Id = saleUpdateDto.Id;
                        saleToUpdate.MovieId = saleUpdateDto.MovieId;
                        saleToUpdate.SalePrice = saleUpdateDto.SalePrice;
                        saleToUpdate.SaleDate = saleUpdateDto.SaleDate;
                        saleToUpdate.UpdatedDate = DateTime.Now;

                        salesRepository.Update(saleToUpdate);



                        result.Message = "The Sale was added";
                    
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error updating the sale";
                this.logger.LogError($"{result.Message}: {ex.Message}");
                throw;
            }

            return result;
        }
    }
}
