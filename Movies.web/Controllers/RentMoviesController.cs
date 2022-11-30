using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.web.Models;

namespace Movies.web.Controllers
{
    public class RentMoviesController : Controller
    {
        // GET: RentController
        public ActionResult Index()
        {

            IEnumerable<Rent> rentMovies = new List<Rent>() {

                new Rent
                {
                    ClientId=1,
                    ExpirationDate=DateTime.Now,
                    Id=2,
                    MovieId=3,
                    RentDate=DateTime.Now,
                    RentPrice=180
                }

            };

            return View(rentMovies);
        }

        // GET: RentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RentController/Create
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

        // GET: RentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RentController/Edit/5
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

        // GET: RentController/Delete/5
        public ActionResult Delete(int id)
        {
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
