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
        public SalesBuyResponse BuyMovie(SaleBuyDto saleBuyDto)
        {
            ServiceResult result = new ServiceResult();
            SalesBuyResponse resultSale = new SalesBuyResponse();
            try
            {
                
                DAL.Entities.Sales SaleToAdd = new DAL.Entities.Sales()
                {
                    Id = (int)saleBuyDto.Id,
                    ClientId = saleBuyDto.ClientId,
                    MovieId = saleBuyDto.MovieId,
                    SaleDate = saleBuyDto.SaleDate,
                    SalePrice = saleBuyDto.SalePrice,
                    CreationDate = DateTime.Now
                };

                salesRepository.Save(SaleToAdd);

                resultSale.Id = SaleToAdd.Id;
                resultSale.ClientId = SaleToAdd.ClientId;
                resultSale.MovieId = SaleToAdd.MovieId;
                resultSale.SalePrice = SaleToAdd.SalePrice;
                resultSale.SaleDate = SaleToAdd.SaleDate;


                result.Message = "Sale succesful";
            

            }
            catch(Exception ex)
            {
                 result.Success= false;
                 result.Message= "Error to complete the sale";
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
                    SalePrice = st.SalePrice
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

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                DAL.Entities.Sales sale = salesRepository.GetEntity(Id);
                SaleModel model = new SaleModel()
                {
                    Id = sale.Id,
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
    }
}
