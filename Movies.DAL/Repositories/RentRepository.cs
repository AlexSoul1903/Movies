using Microsoft.Extensions.Logging;
using Movies.DAL.Context;
using Movies.DAL.Entities;
using Movies.DAL.Interfaces;
using Movies.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DAL.Repositories
{
    public class RentRepository : IRentRepository
    {
        private readonly MoviesContext context;
        private readonly ILogger<ClientRepository> logger;

        public RentRepository(MoviesContext context, ILogger<ClientRepository> logger)
        {

            this.context = context;
            this.logger = logger;

        }
        public bool Exists(Expression<Func<Rent, bool>> filter)
        {
            return context.Rent.Any(filter);
        }

        public IEnumerable<Rent> GetEntities()
        {
            return context.Rent;
        }

        public Rent GetEntity(int rentid)
        {
            return context.Rent.Find(rentid);
        }

        public void Remove(Rent rent)
        {
            rent.DeletedDate = DateTime.Now;
            context.Rent.Remove(rent);
        }

        public void Save(Rent rent)
        {
            context.Rent.Add(rent);
            context.SaveChanges();
        }

        public void Update(Rent rent)
        {
            try
            {
                Rent rentToModify = GetEntity(rent.Id);

                rentToModify.Id = rent.Id;
                rentToModify.ClientID = rent.ClientID;
                rentToModify.RentPrice = rent.RentPrice;
                rentToModify.RentDate = rent.RentDate;
                rentToModify.ExpirationDate = rent.ExpirationDate;
                rentToModify.UpdatedDate = DateTime.Now;

                context.Rent.Update(rentToModify);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error: {ex.Message}", ex.ToString());
            }
        }
    }
}
