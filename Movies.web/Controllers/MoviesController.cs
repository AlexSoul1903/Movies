using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.web.Models;

namespace Movies.web.Controllers
{
    public class MoviesController : Controller
    {
        // GET: MoviesController
        public ActionResult Index() {


            IEnumerable<Movie> Movies = new List<Movie>()
            {

              new Movie
              {
                  Id=1,
                  Name="Avengers Infinity War",
                  Director="Anthony Russo ",
                  Front_page = "Images/Avenger.jpg",

            Genre ="Action",
                  Duration="2h 29m",
                  Relase_date= Convert.ToDateTime("04-27-18"),
                  Rating="PG-13",
                  Rent_price=70,
                  Sale_price=150
              },


                 new Movie
              {

                Id=2,
                  Name="Sherk",
            Director="Andrew Adamson, Vicky Jenson.",
            Front_page="Images/Sherk.jpg",
            Genre="Comedy",
                 Duration="1h 30m",
                 Relase_date= Convert.ToDateTime("04-22-2001"),
                 Rating="PG-MPAA",
                 Rent_price=40,
                 Sale_price=120

              },


          };


            return View(Movies);
        }

        // GET: MoviesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MoviesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MoviesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: MoviesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MoviesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: MoviesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MoviesController/Delete/5
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
