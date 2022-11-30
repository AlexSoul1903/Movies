using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.DAL.Entities;

namespace Movies.web.Controllers
{
    public class SaleInvoiceController : Controller
    {
        // GET: SaleInvoiceController
        public ActionResult Index()
        {

            IEnumerable<Movies.web.Models.SaleInvoice> invoice = new List<Movies.web.Models.SaleInvoice>();
            return View(invoice);
        }

        // GET: SaleInvoiceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SaleInvoiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SaleInvoiceController/Create
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

        // GET: SaleInvoiceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SaleInvoiceController/Edit/5
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

        // GET: SaleInvoiceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SaleInvoiceController/Delete/5
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
