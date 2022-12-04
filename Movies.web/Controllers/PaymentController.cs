using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.DAL.Interfaces;
using Movies.Service.Contracts;
using Movies.Service.Models;
using Movies.Service.Services;
using Movies.web.Extentions;
using Movies.web.Models;
using Movies.web.ViewModels;
using NuGet.Configuration;
using System;
using System.Linq;


namespace Movies.web.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }



        // GET: PaymentController
         public ActionResult Index()
        {
            var payments = ((List<Service.Models.PaymentModel>)_paymentService.GetAll().Data).ConvertPaymentModelToModel();
            

            return View(payments);
        }

        // GET: PaymentController/Details/5
        public ActionResult Details(int id)
        {
            var paymentModel = ((PaymentModel)this._paymentService.GetById(id).Data).ConvertFromPaymentModelToPayment();
            return View(paymentModel);
        }

        // GET: PaymentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Payment paymentModel)
        {
            try
            {
                Service.Dtos.PaymentSaveDto paymentSaveDto = new Service.Dtos.PaymentSaveDto()
                {
                    CardNumber = paymentModel.CardNumber,
                    OwnerName = paymentModel.OwnerName,
                    Id = paymentModel.Id,
                    ExpirationDate = paymentModel.ExpirationDate,
                    Cvv = paymentModel.Cvv
                };
                _paymentService.SavePayment(paymentSaveDto);
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
            var payment = (Service.Models.PaymentModel)_paymentService.GetById(id).Data;
            Models.Payment ModelPayment = new Models.Payment()
            {
                CardNumber = payment.CardNumber,
                OwnerName = payment.OwnerName,
                Id = payment.Id,
                ExpirationDate = payment.ExpirationDate,
                Cvv = payment.Cvv
            };
            
            return View(ModelPayment);
        }

        // POST: PaymentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Payment paymentModel)
        {
            try
            {
                var model = paymentModel;

                Movies.Service.Dtos.PaymentUpdateDto payment = new Service.Dtos.PaymentUpdateDto()
                {
                    CardNumber = paymentModel.CardNumber,
                    OwnerName = paymentModel.OwnerName,
                    Id = paymentModel.Id,
                    ExpirationDate = paymentModel.ExpirationDate,
                    Cvv = paymentModel.Cvv
                };

                _paymentService.UpdatePayment(payment);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception err)
            {
                Console.WriteLine(err);
                return View();
            }
        }

        // GET: PaymentController/Delete/5
        public ActionResult Delete(int Id)
        {
            var payment = (Service.Models.PaymentModel)_paymentService.GetById(Id).Data;
            Models.Payment ModelPayment = new Models.Payment()
            {
                CardNumber = payment.CardNumber,
                OwnerName = payment.OwnerName,
                Id = payment.Id,
                ExpirationDate = payment.ExpirationDate,
                Cvv = payment.Cvv

            };
            
            return View(ModelPayment);
        }

        // POST: PaymentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Payment paymentModel)
        {
            try
            {
                var myModel = paymentModel;
                Service.Dtos.PaymentRemoveDto paymentRemove = new Service.Dtos.PaymentRemoveDto()
                {
                    Id = paymentModel.Id
                };
                _paymentService.RemovePayment(paymentRemove);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return View();
            }
        }
    }
}