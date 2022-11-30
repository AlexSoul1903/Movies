using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.web.Models;
using Movies.DAL.Interfaces;
using Movies.Service.Contracts;
using Movies.Service.Models;
using Movies.Service.Services;
using Movies.web.Extentions;
using Movies.web.ViewModels;
using NuGet.Configuration;
using System;
using System.Linq;

namespace Movies.web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _moviesService;
        public MoviesController(IMovieService moviesService)
        {
            _moviesService = moviesService;
        }


        // GET: MoviesController
        public ActionResult Index() {

            var movies = ((List<Service.Models.MovieModel>)_moviesService.GetAll().Data).ConvertMovieModelToModel();


            return View(movies);
        }

        // GET: MoviesController/Details/5
        public ActionResult Details(int id)
        {
            var movieModel = ((MovieModel)this._moviesService.GetById(id).Data).ConvertFromMovieModelToMovie();
            return View(movieModel);
        }

        // GET: MoviesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MoviesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movieModel)
        {
            try
            {

                Service.Dtos.MovieSaveDto saveMovieDto = new Service.Dtos.MovieSaveDto()
                {

                    Name = movieModel.Name,
                    FrontPage = movieModel.FrontPage,
                    Genre = movieModel.Genre,
                    Rating = movieModel.Rating,
                    Director = movieModel.Director,
                    Duration = movieModel.Duration,
                    ReleaseDate = movieModel.ReleaseDate,
                    SalePrice = movieModel.SalePrice,
                    RentPrice = movieModel.RentPrice



                };
                _moviesService.Save(saveMovieDto);

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();

            }
        }

        // GET: MoviesController/Edit/5
        public ActionResult Edit(int id)
        {
            var movie = (Service.Models.MovieModel)_moviesService.GetById(id).Data;

            Models.Movie ModelMovie = new Models.Movie()
            {
             
                Director=movie.Director,
                Duration=movie.Duration,
                ReleaseDate=movie.ReleaseDate,
                FrontPage=movie.FrontPage,
                Genre=movie.Genre,
                Id=movie.Id,
                Name=movie.Name,
                SalePrice=movie.SalePrice,
                Rating=movie.Rating,
                RentPrice=movie.RentPrice,

            };



            return View(ModelMovie);


        }

        // POST: MoviesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Movie movieModel)
        {
            try
            {
                var myModel = movieModel;

                Movies.Service.Dtos.MovieUpdateDto movie = new Service.Dtos.MovieUpdateDto()
                {
                    UpdatedDate = DateTime.Now,
                    Director = movieModel.Director,
                    Duration = movieModel.Duration,
                    FrontPage = movieModel.FrontPage,
                    Genre = movieModel.Genre,
                    Id = movieModel.Id,
                    Name = movieModel.Name,
                    Rating = movieModel.Rating,
                    ReleaseDate = movieModel.ReleaseDate,
                    RentPrice = movieModel.RentPrice,
                    SalePrice = movieModel.SalePrice,
                    

                };

                _moviesService.Update(movie);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return View();
            }
        }

        // GET: MoviesController/Delete/5
        public ActionResult Delete(int id)
        {
            var movie = (Service.Models.MovieModel)_moviesService.GetById(id).Data;

            Models.Movie ModelMovie = new Models.Movie()
            {
              Director= movie.Director,
              Duration=movie.Duration,
              ReleaseDate=movie.ReleaseDate,
              FrontPage=movie.FrontPage,
              Genre=movie.Genre,
              Id=movie.Id,
              Name=movie.Name,
              Rating=movie.Rating,
              RentPrice=movie.RentPrice,
              SalePrice=movie.SalePrice
            };


            return View(ModelMovie);
        }

        // POST: MoviesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Movie movieModel)
        {

            try
            {
                var myModel = movieModel;

                Service.Dtos.MovieRemoveDto movieRemove = new Service.Dtos.MovieRemoveDto()
                {
                    Id = movieModel.Id

                };

                _moviesService.Remove(movieRemove);


                return RedirectToAction(nameof(Index));
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return View();
            }
        }
    }
}
