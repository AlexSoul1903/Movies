using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.DAL.Interfaces;
using Movies.Service.Contracts;
using Movies.Service.Models;
using Movies.Service.Services;
using Movies.web.Extentions;
using Movies.web.Models;
using Movies.web.ViewModels;
using NuGet.Configuration;
using System;
using System.Linq;

namespace Movies.web.Controllers
{
    public class RentMoviesController : Controller
    {
        // GET: RentController
        private readonly IRentService _rentService;
        public RentMoviesController(IRentService rentService)
        {
            _rentService = rentService;
        }
        public ActionResult Index()
        {
            var rent = ((List<Service.Models.RentModel>)_rentService.GetAll().Data).ConvertRentModelToModel();

            return View(rent);
        }

        // GET: RentController/Details/5
        public ActionResult Details(int id)
        {
            var rentModel = ((RentModel)this._rentService.GetById(id).Data).ConvertFromRentModelToRent();
            return View(rentModel);
        }

        // GET: RentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Rent rentModel)
        {
            try
            {

                Service.Dtos.RentBuyDto rentDto = new Service.Dtos.RentBuyDto()
                {

                    Id = rentModel.Id,
                    ClientId = rentModel.ClientId,
                    RentDate = rentModel.RentDate,
                    MovieId = rentModel.MovieId,
                    RentPrice = rentModel.RentPrice,
                    ExpirationDate = rentModel.ExpirationDate
                };
                _rentService.RentMovie(rentDto);

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();

            }
        }

        // GET: RentController/Edit/5
        public ActionResult Edit(int id)
        {
            var rent = (Service.Models.RentModel)_rentService.GetById(id).Data;

            Models.Rent ModelRent = new Models.Rent()
            {
                Id = rent.Id,
                ClientId = rent.ClientId,
                RentDate = rent.RentDate,
                MovieId = rent.MovieId,
                RentPrice = rent.RentPrice,
                ExpirationDate = rent.ExpirationDate
            };



            return View(ModelRent);
        }

        // POST: RentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Rent rentModel)
        {
            try
            {
                var myModel = rentModel;

                Movies.Service.Dtos.RentBuyDto rent = new Service.Dtos.RentBuyDto()
                {
                    UpdatedDate = DateTime.Now,
                    Id = rentModel.Id,
                    ClientId = rentModel.ClientId,
                    RentDate = rentModel.RentDate,
                    MovieId = rentModel.MovieId,
                    RentPrice = rentModel.RentPrice,
                    ExpirationDate = rentModel.ExpirationDate




                };

                _rentService.RentMovie(rent);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return View();
            }
        }

        // GET: RentController/Delete/5
        public ActionResult Delete(int id)
        {
            // We cannot delete the rents
            return View();
        }

        // POST: RentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
