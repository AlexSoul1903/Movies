using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Movies.DAL.Context;
using Movies.DAL.Entities;
using Movies.DAL.Interfaces;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DAL.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        private readonly MoviesContext context;
        private readonly ILogger<SalesRepository> logger;
        public SalesRepository(MoviesContext context, ILogger<SalesRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }
   
        


        public bool Exists(Expression<Func<Sales, bool>> filter)
        {
            return context.Sale.Any(filter);
        }

        public IEnumerable<Sales> GetEntities()
        {
            return context.Sale;
        }

        public Sales GetEntity(int Salesid)
        {
            return context.Sale.Find(Salesid);
        }

    

        public void Remove(Sales sales)
        {
            sales.DeletedDate = DateTime.Now;
            context.Sale.Remove(sales);
            context.SaveChanges();
        }

        public void Save(Sales sales)
        {
            context.Sale.Add(sales);
            context.SaveChanges();
        }

        public void Update(Sales sales)
        {
            try
            {
                Sales salesToModify = GetEntity(sales.Id);
                salesToModify.Id = sales.Id;
                salesToModify.ClientId = sales.ClientId;
                salesToModify.MovieId = sales.MovieId;
                salesToModify.SalePrice = sales.SalePrice;
                salesToModify.SaleDate = sales.SaleDate;

                context.Sale.Add(salesToModify);
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error: {ex.Message}", ex.ToString );
            }
        }
    }
}
