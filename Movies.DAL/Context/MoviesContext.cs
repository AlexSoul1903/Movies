using Microsoft.EntityFrameworkCore;
using Movies.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DAL.Context
{
    public partial class MoviesContext : DbContext
    {

        public MoviesContext()
        {



        }

        public MoviesContext(DbContextOptions<MoviesContext> options):

            base(options)
        {


        }



        #region "entities"



        public DbSet<Clients> Clients { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Rent> Rent { get; set; }
        public DbSet<SaleInvoice> SaleInvoice { get; set; }
        public DbSet<RentInvoice> RentInvoice { get; set; }


        #endregion
    }
}
