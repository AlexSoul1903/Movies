using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.web.Models;


namespace Movies.web.Controllers
{
    public class PaymentController : Controller
    {
        // GET: PaymentController
        public ActionResult Index()
        {
            IEnumerable<Payment> pay = new List<Payment>();
            

            return View(pay);
        }

        // GET: PaymentController/Details/5
        public ActionResult Details(int id)
        {
            Payment payment = new Payment();
            payment.CardNumber = Convert.ToInt64(Request.Form["CardNumber"]);
            payment.OwnerName = Request.Form["OwnerName"].ToString();
            payment.ExpirationDate = Convert.ToInt32(Request.Form["ExpirationDate"]);
            payment.Cvv = Convert.ToInt32(Request.Form["CVV"]);
            return View();
        }

        // GET: PaymentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentController/Create
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

        // GET: PaymentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PaymentController/Edit/5
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

        // GET: PaymentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PaymentController/Delete/5
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