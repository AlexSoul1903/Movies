using Microsoft.Extensions.Logging;
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
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository paymentRepository;
        private readonly ILoggerService<PaymentService> logger;

        public PaymentService(IPaymentRepository paymentRepository, ILoggerService<PaymentService>logger)
        {
            this.paymentRepository = paymentRepository;
            this.logger = logger;
        }


        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var payment = paymentRepository.GetEntities();
                result.Data = payment.Select(st => new Models.PaymentModel()
                {
                    Id=st.Id,
                    CardNumber = st.CardNumber,
                    OwnerName = st.OwnerName,
                    ExpirationDate = st.ExpirationDate,
                    Cvv = st.Cvv
                }).ToList();
             
                
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "An error occurred getting the payment";
                this.logger.LogError($"{result.Message}{ex.Message}", ex.ToString());

            }

            return result; 

        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                DAL.Entities.Payment payment = paymentRepository.GetEntity(Id);
                PaymentModel model = new PaymentModel()
                {   
                    Id=payment.Id,
                    CardNumber = payment.CardNumber,
                    OwnerName = payment.OwnerName,
                    ExpirationDate = payment.ExpirationDate,
                    Cvv = payment.Cvv
                };
                result.Data = model;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error getting the payment Id.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;

        }

        public ServiceResult GetPayment()
        {
            ServiceResult result = new ServiceResult();


            try
            {

                var payment = paymentRepository.GetEntities();

                result.Data = payment.Select(st => new Models.PaymentModel()
                {
                    Id = st.Id,
                    CardNumber = st.CardNumber,
                    OwnerName = st.OwnerName,
                    ExpirationDate = st.ExpirationDate,
                    Cvv = st.Cvv


                });

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error getting the payment";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult RemovePayment(PaymentRemoveDto paymentRemoveDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {


                PaymentSaveResponse payment = new PaymentSaveResponse();

                DAL.Entities.Payment paymentToRemove = paymentRepository.GetEntity((int)paymentRemoveDto.Id);

                paymentToRemove.Id = (int)paymentRemoveDto.Id;
                paymentToRemove.DeletedDate = DateTime.Now;

                paymentRepository.Remove(paymentToRemove);

                result.Message = "The payment was deleted.";


            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error deleting the payment";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());


            }

            return result;
        }

        public PaymentSaveResponse SavePayment(PaymentSaveDto paymentSaveDto)
        {
            PaymentSaveResponse result = new PaymentSaveResponse();

            try
            {

                var resutlIsValid = ValidationsPayment.IsValidPayment(paymentSaveDto);

                if (resutlIsValid.Success)
                {

                    
                    if (paymentRepository.Exists(st => st.OwnerName == paymentSaveDto.OwnerName && st.CardNumber == paymentSaveDto.CardNumber))
                    {

                        result.Success = false;
                        result.Message = "This payment is alredy registered.";
                        return result;
                    }

                    if (paymentSaveDto.Id == null)
                    {
                        result.Success = false;
                        result.Message = "An Id must be provided in order to update a client";
                        return result;
                    }

                    DAL.Entities.Payment PaymentToAdd = new DAL.Entities.Payment()
                    {
                        Id = (int)paymentSaveDto.Id,
                        CardNumber= paymentSaveDto.CardNumber,
                        OwnerName = paymentSaveDto.OwnerName,
                        CreationDate = DateTime.Now,
                        ExpirationDate = paymentSaveDto.ExpirationDate,
                        Cvv = paymentSaveDto.Cvv
                    };

                    paymentRepository.Save(PaymentToAdd);

                    result.Id = PaymentToAdd.Id;

                    result.Message = "The payment was added successfully";

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
                result.Message = "Error adding the payment";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }
            return result;
        }




        PaymentUpdateResponse IPaymentService.UpdatePayment(PaymentUpdateDto paymentUpdateDto)
        {

            PaymentUpdateResponse result = new PaymentUpdateResponse();

            try
            {


                var resultIsValid = ValidationsPayment.IsValidPayment(paymentUpdateDto);

                if (resultIsValid.Success)
                {


                    DAL.Entities.Payment paymentToUpdate = paymentRepository.GetEntity((int)paymentUpdateDto.Id); 

                    paymentToUpdate.CardNumber = paymentUpdateDto.CardNumber;
                    paymentToUpdate.OwnerName = paymentUpdateDto.OwnerName;
                    paymentToUpdate.ExpirationDate = paymentUpdateDto.ExpirationDate;
                    paymentToUpdate.Cvv = paymentUpdateDto.Cvv;
                    result.Message = "Payment updated successfully!";
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
                result.Message = "Error updating the payment";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }

            return result;

        }

       
    }
}
