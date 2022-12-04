using Movies.DAL.Entities;
using Movies.Service.Models;

namespace Movies.web.Extentions
{
    public static class PaymentExtentions
    {
        public static List<Movies.web.Models.Payment> ConvertPaymentModelToModel(this List<Service.Models.PaymentModel> paymentModels)
        {

            var myPayments = paymentModels.Select(payment => new Movies.web.Models.Payment()
            {
                CardNumber = payment.CardNumber,
                OwnerName = payment.OwnerName,
                Id = payment.Id,
                ExpirationDate = payment.ExpirationDate,
                Cvv = payment.Cvv

            }).ToList();

            return myPayments;
        }


        public static List<Payment> GetPayment(List<Service.Models.PaymentModel> paymentModels)
        {
            var myPayments = paymentModels.Select(payment => new Payment()
            {
                CardNumber = payment.CardNumber,
                OwnerName = payment.OwnerName,
                Id = payment.Id,
                ExpirationDate = payment.ExpirationDate,
                Cvv = payment.Cvv

            }).ToList();

            return myPayments;
        }


        public static Models.Payment ConvertFromPaymentModelToPayment(this PaymentModel paymentModel)
        {
            return new Models.Payment()
            {
                CardNumber = paymentModel.CardNumber,
                OwnerName = paymentModel.OwnerName,
                Id = paymentModel.Id,
                ExpirationDate = paymentModel.ExpirationDate

            };
        }

    }
}
