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
    public class SaleInvoiceService : ISaleInvoiceService
    {
        private readonly ISaleInvoiceRepository saleInvoiceRepository;
        private readonly IPaymentRepository paymentRepository;
        private readonly ILoggerService<SaleInvoiceService> logger;

        public SaleInvoiceService(ISaleInvoiceRepository saleInvoiceRepository, IPaymentRepository paymentRepository, ILoggerService<SaleInvoiceService> logger)
        {
            this.saleInvoiceRepository = saleInvoiceRepository;
            this.paymentRepository = paymentRepository;
            this.logger = logger;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new();
            try
            {
                var saleInvoice = saleInvoiceRepository.GetEntities();

                result.Data = saleInvoice.Select((saleInvoice) =>
                {
                    var saleInvoicePayment = paymentRepository.GetEntity(saleInvoice.PaymentId);

                    return new SaleInvoiceModel()
                    {
                        Id = saleInvoice.Id,
                        PaymentId = saleInvoice.PaymentId,
                        SaleId = saleInvoice.SaleId,
                        Payment = saleInvoicePayment != null ? new PaymentModel()
                        {
                            Id = saleInvoicePayment.Id,
                            CardNumber = saleInvoicePayment.CardNumber,
                            Cvv = saleInvoicePayment.Cvv,
                            OwnerName = saleInvoicePayment.OwnerName,
                            ExpirationDate = saleInvoicePayment.ExpirationDate,
                        } : null,
                    };
                }).ToList();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error getting the sale invoices";
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
                var saleInvoice = saleInvoiceRepository.GetEntity(Id);
                var saleInvoicePayment = paymentRepository.GetEntity(saleInvoice.PaymentId);

                result.Data = new SaleInvoiceModel()
                {
                    Id = saleInvoice.Id,
                    SaleId = saleInvoice.SaleId,
                    PaymentId = saleInvoice.PaymentId,
                    Payment = saleInvoicePayment != null ? new PaymentModel()
                    {
                        Id = saleInvoicePayment.Id,
                        CardNumber = saleInvoicePayment.CardNumber,
                        Cvv = saleInvoicePayment.Cvv,
                        OwnerName = saleInvoicePayment.OwnerName,
                        ExpirationDate = saleInvoicePayment.ExpirationDate,
                    } : null
                };
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error getting the sale invoice";
                this.logger.LogError($"{result.Message}: {ex.Message}");
                throw;
            }

            return result;
        }

        public SaleInvoiceSaveResponse Save(SaleInvoiceSaveDto dto)
        {
            SaleInvoiceSaveResponse result = new();
            try
            {
                var resultIsValidSaleInvoice = ValidationsSaleInvoice.IsValidSaleInvoice(dto);

                if (!resultIsValidSaleInvoice.Success)
                {
                    result.Success = resultIsValidSaleInvoice.Success;
                    result.Message = resultIsValidSaleInvoice.Message;
                    return result;
                }

                var saleInvoiceToSave = new SaleInvoice()
                {
                    PaymentId = (int)dto.PaymentId!,
                    SaleId = (int)dto.SaleId!,
                    CreationDate = DateTime.Now
                };

                saleInvoiceRepository.Save(saleInvoiceToSave);

                result.Message = "Sale invoice saved successfully";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error saving the sale invoice";
                this.logger.LogError($"{result.Message}: {ex.Message}");
                throw;
            }

            return result;
        }

        public SaleInvoiceUpdateResponse Update(SaleInvoiceUpdateDto dto)
        {
            SaleInvoiceUpdateResponse result = new();
            try
            {
                if (dto.Id == null)
                {
                    result.Success = false;
                    result.Message = "An Id must be provided in order to update a sale invoice";
                    return result;
                };

                var saleInvoiceToUpdate = saleInvoiceRepository.GetEntity((int)dto.Id);

                saleInvoiceToUpdate.UpdatedDate = DateTime.Now;

                saleInvoiceRepository.Update(saleInvoiceToUpdate);

                result.Message = "Sale invoice updated successfully";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error updating the sale invoice";
                this.logger.LogError($"{result.Message}: {ex.Message}");
                throw;
            }

            return result;
        }

        public SaleInvoiceDeleteResponse Remove(SaleInvoiceRemoveDto dto)
        {
            SaleInvoiceDeleteResponse result = new();
            try
            {
                var saleInvoiceToDelete = saleInvoiceRepository.GetEntity(dto.Id);

                saleInvoiceToDelete.DeletedDate = DateTime.Now;

                saleInvoiceRepository.Remove(saleInvoiceToDelete);

                result.Message = "Sale invoice deleted successfully";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error deleting the sale invoice";
                this.logger.LogError($"{result.Message}: {ex.Message}");
                throw;
            }

            return result;
        }
    }
}
