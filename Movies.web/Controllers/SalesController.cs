using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.DAL.Interfaces;
using Movies.web.Models;

namespace Movies.web.Controllers
{
    public class SalesController : Controller
    {
        // GET: SalesController
        
        public ActionResult Index()
        {

            IEnumerable<Movie> sales = new List<Movie>() {

                new Movie
                {
                     Id=1,
                  Name="Avengers Infinity War",
                  Director="Anthony Russo",
                 FrontPage = "Images/Avenger.jpg",
                  Genre ="Action",
                  Duration="2h 29m",
                  RelaseDate= new DateOnly(2018, 4, 12),
                  Rating="PG-13",
                  RentPrice=70,
                  SalePrice=150
                },

                new Movie
                {
                 Id=2,
                 Name="Sherk",
                 Director="Andrew Adamson, Vicky Jenson.",
                 FrontPage="Images/Sherk.jpg",
                 Genre="Comedy",
                 Duration="1h 30m",
                 RelaseDate= new DateOnly(2001, 4, 12),
                 Rating="PG-MPAA",
                 RentPrice=40,
                 SalePrice=120
                },
                   new Movie
              {

                  Id=3,
                  Name="Harry Potter",
                  Director="Chris Columbus",
                  FrontPage="Images/Harry Potter.jpg",
                  Genre="Fiction",
                  Duration="2h 32m",
                  RelaseDate= new DateOnly(2001, 11, 14),
                  Rating="PG-MPAA",
                  RentPrice=50,
                  SalePrice=130

              },
                 new Movie
              {

                  Id=4,
                  Name="Kimetsu",
                  Director="Haruo Sotozaki",
                  FrontPage="Images/Kimetsu.jpg",
                  Genre="Fiction",
                  Duration="1h 57m",
                  RelaseDate= new DateOnly(2020, 10, 16),
                  Rating="PG-MPAA",
                  RentPrice=45,
                  SalePrice=130

              },

                  new Movie
              {

                  Id=5,
                  Name="Pitufos 2",
                  Director="Raja Gosnell",
                  FrontPage="Images/Pitufos 2.jpg",
                  Genre="Comedy",
                  Duration="1h 45m",
                  RelaseDate= new DateOnly(2013, 7, 28),
                  Rating="PG-MPAA",
                  RentPrice=45,
                  SalePrice=130

              },

                   new Movie
              {

                  Id=6,
                  Name="Titanic",
                  Director="James Cameron",
                  FrontPage="Images/Titanic.jpg",
                  Genre="Romance/Drama",
                  Duration="3h 14m",
                  RelaseDate= new DateOnly(1997, 12, 19),
                  Rating="PG-MPAA",
                  RentPrice=50,
                  SalePrice=115

              },



            };
            return View(sales);
        }

        // GET: SalesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SalesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalesController/Create
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

        // GET: SalesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SalesController/Edit/5
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

        // GET: SalesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SalesController/Delete/5
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
