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
    public class RentInvoiceService : IRentInvoiceService
    {
        private readonly ISaleInvoiceRepository rentInvoiceRepository;
        private readonly IPaymentRepository paymentRepository;
        private readonly ILoggerService<RentInvoiceService> logger;

        public RentInvoiceService(ISaleInvoiceRepository rentInvoiceRepository, IPaymentRepository paymentRepository, ILoggerService<RentInvoiceService> logger)
        {
            this.rentInvoiceRepository = rentInvoiceRepository;
            this.paymentRepository = paymentRepository;
            this.logger = logger;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new();
            try
            {
                var rentInvoices = rentInvoiceRepository.GetEntities();

                result.Data = rentInvoices.Select((rentInvoice) =>
                {
                    var rentInvoicePayment = paymentRepository.GetEntity(rentInvoice.PaymentId);

                    return new RentInvoiceModel()
                    {
                        Id = rentInvoice.Id,
                        PaymentId = rentInvoice.PaymentId,
                        RentId = rentInvoice.RentId,
                        Payment = rentInvoicePayment != null ? new PaymentModel()
                        {
                            Id = rentInvoicePayment.Id,
                            CardNumber = rentInvoicePayment.CardNumber,
                            Cvv = rentInvoicePayment.Cvv,
                            OwnerName = rentInvoicePayment.OwnerName,
                            ExpirationDate = rentInvoicePayment.ExpirationDate,
                        } : null,
                    };
                }).ToList();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error getting the rent invoices";
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
                var rentInvoice = rentInvoiceRepository.GetEntity(Id);
                var rentInvoicePayment = paymentRepository.GetEntity(rentInvoice.PaymentId);

                result.Data = new RentInvoiceModel()
                {
                    Id = rentInvoice.Id,
                    RentId = rentInvoice.RentId,
                    PaymentId = rentInvoice.PaymentId,
                    Payment = rentInvoicePayment != null ? new PaymentModel()
                    {
                        Id = rentInvoicePayment.Id,
                        CardNumber = rentInvoicePayment.CardNumber,
                        Cvv = rentInvoicePayment.Cvv,
                        OwnerName = rentInvoicePayment.OwnerName,
                        ExpirationDate = rentInvoicePayment.ExpirationDate,
                    } : null
                };
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error getting the rent invoice";
                this.logger.LogError($"{result.Message}: {ex.Message}");
                throw;
            }

            return result;
        }

        public RentInvoiceSaveResponse Save(RentInvoiceSaveDto dto)
        {
            RentInvoiceSaveResponse result = new();
            try
            {
                var resultIsValidRentInvoice = ValidationsRentInvoice.IsValidRentInvoice(dto);

                if (!resultIsValidRentInvoice.Success)
                {
                    result.Success = resultIsValidRentInvoice.Success;
                    result.Message = resultIsValidRentInvoice.Message;
                    return result;
                }

                var rentInvoiceToSave = new RentInvoice()
                {   PaymentId = (int)dto.PaymentId!,
                    RentId = (int)dto.RentId!,
                    CreationDate = DateTime.Now
                };

                rentInvoiceRepository.Save(rentInvoiceToSave);

                result.Message = "Rent invoice saved successfully";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error saving the rent invoice";
                this.logger.LogError($"{result.Message}: {ex.Message}");
                throw;
            }

            return result;
        }

        public RentInvoiceUpdateResponse Update(RentInvoiceUpdateDto dto)
        {
            RentInvoiceUpdateResponse result = new();
            try
            {
                if (dto.Id == null)
                {
                    result.Success = false;
                    result.Message = "An Id must be provided in order to update a rent invoice";
                    return result;
                };

                var rentInvoiceToUpdate = rentInvoiceRepository.GetEntity((int)dto.Id);

                rentInvoiceToUpdate.UpdatedDate = DateTime.Now;

                rentInvoiceRepository.Update(rentInvoiceToUpdate);

                result.Message = "Rent invoice updated successfully";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error updating the rent invoice";
                this.logger.LogError($"{result.Message}: {ex.Message}");
                throw;
            }

            return result;
        }

        public RentInvoiceDeleteResponse Remove(RentInvoiceRemoveDto dto)
        {
            RentInvoiceDeleteResponse result = new();
            try
            {
                var rentInvoiceToDelete = rentInvoiceRepository.GetEntity(dto.Id);

                rentInvoiceToDelete.DeletedDate = DateTime.Now;

                rentInvoiceRepository.Remove(rentInvoiceToDelete);

                result.Message = "Rent invoice deleted successfully";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error deleting the rent invoice";
                this.logger.LogError($"{result.Message}: {ex.Message}");
                throw;
            }

            return result;
        }
    }
}
