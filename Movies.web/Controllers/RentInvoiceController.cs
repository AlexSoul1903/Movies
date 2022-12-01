using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Service.Contracts;
using Movies.Service.Models;
using Movies.Service.Services;
using Movies.web.Extentions;

namespace Movies.web.Controllers
{
    public class RentInvoiceController : Controller
    {
        private readonly IRentInvoiceService _rentInvoiceService;
        public RentInvoiceController (IRentInvoiceService rentInvoiceService)
        {
            _rentInvoiceService = rentInvoiceService;
        }

        // GET: RentInvoiceController
        public ActionResult Index()
        {
            var rentInvoices = ((List<Service.Models.RentInvoiceModel>)_rentInvoiceService.GetAll().Data).ConvertRentInvoiceModelToModel();
            return View(rentInvoices);
        }

        // GET: RentInvoiceController/Details/5
        public ActionResult Details(int id)
        {
            var rentInvoice = ((Service.Models.RentInvoiceModel)_rentInvoiceService.GetById(id).Data).ConvertRentInvoiceToModel();
            return View(rentInvoice);
        }

        // GET: RentInvoiceController/Edit/5
        public ActionResult Edit(int id)
        {
            var rentInvoice = ((Service.Models.RentInvoiceModel)_rentInvoiceService.GetById(id).Data).ConvertRentInvoiceToModel();
            return View(rentInvoice);
        }

        // POST: RentInvoiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.RentInvoice rentInvoiceModel)
        {
            try
            {
                var rentInvoiceDto = new Service.Dtos.RentInvoiceUpdateDto()
                {
                    Id = rentInvoiceModel.Id,
                    RentId = rentInvoiceModel.RentId,
                    PaymentId = rentInvoiceModel.PaymentId,
                };

                _rentInvoiceService.Update(rentInvoiceDto);

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
            var rentInvoice = ((Service.Models.RentInvoiceModel)_rentInvoiceService.GetById(id).Data).ConvertRentInvoiceToModel();
            return View(rentInvoice);
        }

        // POST: RentInvoiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RentInvoiceModel rentInvoiceModel)
        {
            try
            {
                var rentInvoiceRemoveDto = new Service.Dtos.RentInvoiceRemoveDto()
                {
                    Id = rentInvoiceModel.Id,
                };

                _rentInvoiceService.Remove(rentInvoiceRemoveDto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
