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
    public class RentInvoiceRepository : IRentInvoiceRepository
    {
        private readonly MoviesContext context;
        private readonly ILogger<RentInvoiceRepository> logger;
        public RentInvoiceRepository(MoviesContext context, ILogger<RentInvoiceRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public bool Exists(Expression<Func<RentInvoice, bool>> filter)
        {
            return context.RentInvoice.Any(filter);
        }

        public IEnumerable<RentInvoice> GetEntities()
        {
            return context.RentInvoice;
        }

        public RentInvoice GetEntity(int rentInvoiceId)
        {
            return context.RentInvoice.Find(rentInvoiceId);
        }

        public void Remove(RentInvoice rentInvoice)
        {
            rentInvoice.DeletedDate = DateTime.Now;
            context.RentInvoice.Remove(rentInvoice);
            context.SaveChanges();
        }

        public void Save(RentInvoice rentInvoice)
        {
            context.RentInvoice.Add(rentInvoice);
            context.SaveChanges();
        }

        public void Update(RentInvoice rentInvoice)
        {
            try
            {
                RentInvoice rentInvoiceToModify = GetEntity(rentInvoice.Id);
                rentInvoiceToModify.PaymentId = rentInvoice.PaymentId;
                rentInvoiceToModify.UpdatedDate = DateTime.Now;

                context.RentInvoice.Update(rentInvoiceToModify);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error: {ex.Message}", ex.ToString());
            }
        }
    }
}
