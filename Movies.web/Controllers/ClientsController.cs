using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.DAL.Interfaces;
using Movies.web.Models;
using Movies.web.ViewModels;
using System;
using System.Linq;

namespace Movies.web.Controllers
{
    public class ClientsController : Controller
    {


        // GET: Clients
        public ActionResult Index()
        {


          

           
            IEnumerable<Client> clients = new List<Client>()
            {
                
              new Client
              {

                  Id=1,
                  Name="Alex",
              LastName="Frias Molina",
                  Password="123",
                  Email="Alex@gmail.com",
                  Age=18


              },

                 new Client
              {

                  Id=2,
                  Name="Alexa",
                  LastName="Frias Molina",
                  Password="123d",
                  Email="Alexa@gmail.com",
                  Age=13


              },

          };

     

            return View(clients);
        }

        // GET: Clients/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
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

        // GET: Clients/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Clients/Edit/5
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

        // GET: Clients/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Clients/Delete/5
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
