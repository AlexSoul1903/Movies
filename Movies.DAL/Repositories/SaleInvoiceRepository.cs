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
    public class SaleInvoiceRepository : ISaleInvoiceRepository
    {
        private readonly MoviesContext context;
        private readonly ILogger<SaleInvoiceRepository> logger;

        public SaleInvoiceRepository(MoviesContext context, ILogger<SaleInvoiceRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public bool Exists(Expression<Func<SaleInvoice, bool>> filter)
        {
            return context.SaleInvoice.Any(filter);

        }

        public IEnumerable<SaleInvoice> GetEntities()
        {
            return context.SaleInvoice;
        }

        public SaleInvoice GetEntity(int saleInvoiceId)
        {
            return context.SaleInvoice.Find(saleInvoiceId);
        }

        public void Remove(SaleInvoice saleInvoice)
        {
            saleInvoice.DeletedDate = DateTime.Now;
            context.SaleInvoice.Remove(saleInvoice);
            context.SaveChanges();
        }

        public void Save(SaleInvoice saleInvoice)
        {
            context.SaleInvoice.Add(saleInvoice);
            context.SaveChanges();
        }

        public void Update(SaleInvoice saleInvoice)
        {
            try
            {
                SaleInvoice saleInvoiceToModify = GetEntity(saleInvoice.Id);
                saleInvoiceToModify.SaleId = saleInvoice.SaleId;
                saleInvoiceToModify.PaymentId = saleInvoice.PaymentId;
                saleInvoiceToModify.UpdatedDate = DateTime.Now;

                context.SaleInvoice.Update(saleInvoiceToModify);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error: {ex.Message}", ex.ToString());
            }
        }
    }
}
