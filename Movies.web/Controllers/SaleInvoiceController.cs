using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.DAL.Entities;
using Movies.Service.Contracts;
using Movies.Service.Models;
using Movies.Service.Services;
using Movies.web.Extentions;

namespace Movies.web.Controllers
{
    public class SaleInvoiceController : Controller
    {
        private readonly ISaleInvoiceService _saleInvoiceService;

        public SaleInvoiceController(ISaleInvoiceService saleInvoiceService)
        {
            _saleInvoiceService = saleInvoiceService;
        }

        // GET: SaleInvoiceController
        public ActionResult Index()
        {
            var saleInvoices = ((List<Service.Models.SaleInvoiceModel>)_saleInvoiceService.GetAll().Data).ConvertSaleInvoiceModelToModel();
            return View(saleInvoices);
        }

        // GET: SaleInvoiceController/Details/5
        public ActionResult Details(int id)
        {
            var saleInvoice = ((Service.Models.SaleInvoiceModel)_saleInvoiceService.GetById(id).Data).ConvertSaleInvoiceToModel();
            return View(saleInvoice);
        }

        // GET: SaleInvoiceController/Edit/5
        public ActionResult Edit(int id)
        {
            var saleInvoice = ((Service.Models.SaleInvoiceModel)_saleInvoiceService.GetById(id).Data).ConvertSaleInvoiceToModel();
            return View(saleInvoice);
        }

        // POST: SaleInvoiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SaleInvoiceModel saleInvoiceModel)
        {
            try
            {
                var saleInvoiceDto = new Service.Dtos.SaleInvoiceUpdateDto()
                {
                    Id = saleInvoiceModel.Id,
                    SaleId = saleInvoiceModel.SaleId,
                    PaymentId = saleInvoiceModel.PaymentId,
                };

                _saleInvoiceService.Update(saleInvoiceDto);
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
            var saleInvoice = ((Service.Models.SaleInvoiceModel)_saleInvoiceService.GetById(id).Data).ConvertSaleInvoiceToModel();
            return View(saleInvoice);
        }

        // POST: SaleInvoiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SaleInvoiceModel saleInvoiceModel)
        {
            try
            {
                var saleInvoiceRemoveDto = new Service.Dtos.SaleInvoiceRemoveDto()
                {
                    Id = saleInvoiceModel.Id,
                };

                _saleInvoiceService.Remove(saleInvoiceRemoveDto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
