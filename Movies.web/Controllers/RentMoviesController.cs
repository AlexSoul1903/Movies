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

            IEnumerable<Movie> RentMovie = new List<Movie>() {

                new Movie
                {
                     Id=1,
                  Name="Avengers Infinity War",
                  Director="Anthony Russo",
                 Front_page = "Images/Avenger.jpg",
                  Genre ="Action",
                  Duration="2h 29m",
                  Relase_date= Convert.ToDateTime("04/12/18"),
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
                 Relase_date= Convert.ToDateTime("04/12/2001"),
                 Rating="PG-MPAA",
                 Rent_price=40,
                 Sale_price=120
                },
                   new Movie
              {

                  Id=3,
                  Name="Harry Potter",
                  Director="Chris Columbus",
                  Front_page="Images/Harry Potter.jpg",
                  Genre="Fiction",
                  Duration="2h 32m",
                  Relase_date= Convert.ToDateTime("11/14/2001"),
                  Rating="PG-MPAA",
                  Rent_price=50,
                  Sale_price=130

              },
                 new Movie
              {

                  Id=4,
                  Name="Kimetsu",
                  Director="Haruo Sotozaki",
                  Front_page="Images/Kimetsu.jpg",
                  Genre="Fiction",
                  Duration="1h 57m",
                  Relase_date= Convert.ToDateTime("10/16/20"),
                  Rating="PG-MPAA",
                  Rent_price=45,
                  Sale_price=130

              },

                  new Movie
              {

                  Id=5,
                  Name="Pitufos 2",
                  Director="Raja Gosnell",
                  Front_page="Images/Pitufos 2.jpg",
                  Genre="Comedy",
                  Duration="1h 45m",
                  Relase_date= Convert.ToDateTime("07/28/13"),
                  Rating="PG-MPAA",
                  Rent_price=45,
                  Sale_price=130

              },

                   new Movie
              {

                  Id=6,
                  Name="Titanic",
                  Director="James Cameron",
                  Front_page="Images/Titanic.jpg",
                  Genre="Romance/Drama",
                  Duration="3h 14m",
                  Relase_date= Convert.ToDateTime("12/19/1997"),
                  Rating="PG-MPAA",
                  Rent_price=50,
                  Sale_price=115

              },



            };

            return View(RentMovie);
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
