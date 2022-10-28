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
        public PaymentRepository(MoviesContext context)
        {

        }
        public bool Exists(Expression<Func<Payment, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Payment> GetEntities()
        {
            throw new NotImplementedException();
        }

        public Payment GetEntity(int entityid)
        {
            throw new NotImplementedException();
        }

        public void Remove(Payment entity)
        {
            throw new NotImplementedException();
        }

        public void Save(Payment entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Payment entity)
        {
            throw new NotImplementedException();
        }
    }
}
