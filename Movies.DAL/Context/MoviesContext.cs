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



        #endregion
    }
}
