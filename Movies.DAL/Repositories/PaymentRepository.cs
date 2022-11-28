using Microsoft.Extensions.Logging;
using Movies.DAL.Context;
using Movies.DAL.Entities;
using Movies.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DAL.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly MoviesContext context;
        private readonly ILogger<PaymentRepository> logger;
        public PaymentRepository(MoviesContext context, ILogger<PaymentRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public bool Exists(Expression<Func<Payment, bool>> filter)
        {
            return context.Payment.Any(filter);
        }

        public IEnumerable<Payment> GetEntities()
        {
            return context.Payment;
        }

        public Payment GetEntity(int paymentId)
        {
            return context.Payment.Find(paymentId);
        }

        public void Remove(Payment payment)
        {
            payment.DeletedDate = DateTime.Now;
            context.Payment.Remove(payment);
            context.SaveChanges();
        }

        public void Save(Payment payment)
        {
            context.Payment.Add(payment);
            context.SaveChanges();
        }

        public void Update(Payment payment)
        {
            try
            {
                Payment paymentToModify = GetEntity(payment.Id);

                paymentToModify.CardNumber = payment.CardNumber;
                paymentToModify.OwnerName = payment.OwnerName;
                paymentToModify.Cvv = payment.Cvv;
                paymentToModify.UpdatedDate = DateTime.Now;

                context.Payment.Update(paymentToModify);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error: {ex.Message}", ex.ToString());
            }
        }
    }
}
