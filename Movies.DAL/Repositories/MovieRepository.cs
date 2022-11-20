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



    public class MovieRepository : IMoviesRepository
    {



        private readonly MoviesContext context;
        private readonly ILogger<MovieRepository> logger;


        public MovieRepository(MoviesContext context, ILogger<MovieRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public bool Exists(Expression<Func<Movie, bool>> filter)
        {
            return context.movie.Any(filter);

        }

        public IEnumerable<Movie> GetEntities()
        {

            return context.movie;

        }

        public Movie GetEntity(int movieid)
        {

            return context.movie.Find(movieid);

        }

        public void Remove(Movie entity)
        {


            entity.DeletedDate = DateTime.Now;
            context.movie.Remove(entity);


        }

        public void Save(Movie entity)
        {


            context.movie.Add(entity);
            context.SaveChanges();


        }

        public void Update(Movie entity)
        {

            try
            {
                Movie movieToModify = GetEntity(entity.Id);

                movieToModify.Name = entity.Name;
                movieToModify.Rating = entity.Rating;
                movieToModify.ReleaseDate = entity.ReleaseDate;
                movieToModify.FrontPage = entity.FrontPage;
                movieToModify.Duration = entity.Duration;
                movieToModify.Genre = entity.Genre;
                movieToModify.RentPrice = entity.RentPrice;
                movieToModify.SalePrice = entity.SalePrice;
                movieToModify.ReleaseDate = entity.ReleaseDate;
                movieToModify.Director = entity.Director;
               
                movieToModify.UpdatedDate = DateTime.Now;

                context.movie.Update(movieToModify);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error: {ex.Message}", ex.ToString());
            }




        }
    }
}
