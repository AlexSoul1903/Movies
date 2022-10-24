using Microsoft.EntityFrameworkCore;
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







        #endregion
    }
}
