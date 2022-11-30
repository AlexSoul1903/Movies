using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Movies.web.Controllers
{
    public class RentInvoiceController : Controller
    {
        // GET: RentInvoiceController
        public ActionResult Index()
        {


            IEnumerable<Movies.web.Models.RentInvoice> invoice = new List<Movies.web.Models.RentInvoice>();
            return View(invoice);
        }

        // GET: RentInvoiceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RentInvoiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RentInvoiceController/Create
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

        // GET: RentInvoiceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RentInvoiceController/Edit/5
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

        // GET: RentInvoiceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RentInvoiceController/Delete/5
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
