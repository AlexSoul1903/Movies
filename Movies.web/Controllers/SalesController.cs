using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movies.DAL.Interfaces;
using Movies.Service.Contracts;
using Movies.Service.Core;
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
    public class SalesController : Controller
    {
        // GET: SalesController

        private readonly ISalesService _SalesService;
        public SalesController(ISalesService salesService)
        {
            _SalesService = salesService;
        }


        public ActionResult Index()
        { 

            var sales = ((List<Service.Models.SaleModel>)_SalesService.GetAll().Data).ConvertSaleModelToModel();

            return View(sales);
        }

        // GET: SalesController/Details/5
        public ActionResult Details(int id)
        {
            var saleModel = ((SaleModel)this._SalesService.GetById(id).Data).ConvertFromSaleModelToSales();
            return View(saleModel);
        }

        // GET: SalesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sales saleModel)
        {
            try
            {
                
                Service.Dtos.SaleBuyDto saveSaleDto = new Service.Dtos.SaleBuyDto()
                {

                    ClientId = saleModel.ClientId,
                    MovieId = saleModel.MovieId,
                    SalePrice = saleModel.SalePrice,
                    SaleDate = saleModel.SaleDate,
                    CreationDate = DateTime.Now,
                };
                _SalesService.SaleResponse(saveSaleDto);

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
            var sales = (Service.Models.SaleModel)_SalesService.GetById(id).Data;

            Models.Sales salesModel = new Models.Sales()
            {
                Id = sales.Id,
                ClientId = sales.ClientId,
                MovieId = sales.MovieId,
                SaleDate = sales.SaleDate,
                SalePrice = sales.SalePrice,

            };



            return View(salesModel);
        }

        // POST: SalesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Sales saleModel)
        {
            try
            {
                var myModel = saleModel;

                Movies.Service.Dtos.SalesUpdateDto Sale = new Service.Dtos.SalesUpdateDto()
                {
                    Id = saleModel.Id,
                    ClientId = saleModel.ClientId,
                    MovieId = saleModel.MovieId,
                    SalePrice = saleModel.SalePrice,
                    SaleDate = saleModel.SaleDate,
                    UpdatedDate = DateTime.Now,

                };

                _SalesService.UpdateSale(Sale);
                return RedirectToAction(nameof(Index));

            }
            catch(Exception error)
            {
                Console.WriteLine(error);
                return View();
            }
        }

        // GET: SalesController/Delete/5
        public ActionResult Delete(int id)
        {
            var sale = (Service.Models.SaleModel)_SalesService.GetById(id).Data;

            Models.Sales ModelSales = new Models.Sales()
            {
                Id = sale.Id,
                ClientId = sale.ClientId,
                MovieId = sale.MovieId,
                SalePrice = sale.SalePrice,
                SaleDate = DateTime.Now,
                CreationDate = DateTime.Now
            };


            return View(ModelSales);
        }

        // POST: SalesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Sales saleModel)
        {
            try
            {
                var myModel = saleModel;

                Service.Dtos.SalesDeleteDto saleDelete = new Service.Dtos.SalesDeleteDto()
                {
                    Id = saleModel.Id

                };

                _SalesService.DeleteSale(saleDelete);



                return RedirectToAction(nameof(Index));
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return View();
            }
        }
    }
}
