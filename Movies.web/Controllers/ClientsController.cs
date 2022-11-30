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
    public class ClientsController : Controller
    {

        private readonly IClientService _clientService;
        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }




        // GET: Clients
        public ActionResult Index()
        {

            var clients = ((List<Service.Models.ClientModel>)_clientService.GetAll().Data)
                                                                             .ConvertClientModelToModel();


            return View(clients);
        }

        // GET: Clients/Details/5
        public ActionResult Details(int id)
        {
            var clientModel = ((ClientModel)this._clientService.GetById(id).Data).ConvertFromClientModelToClient();
            return View(clientModel);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {

            return View();

        }

        // POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client clientModel)
        {
            try
            {

                Service.Dtos.ClientSaveDto saveClientDto = new Service.Dtos.ClientSaveDto()
                {
                    
                    Age = clientModel.Age,
                    CreationDate = DateTime.Now,
                    Email = clientModel.Email,
                    LastName = clientModel.LastName,
                    Name = clientModel.Name,
                    Password = clientModel.Password
                };
                  _clientService.SaveClient(saveClientDto);

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();

            }
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int Id)
        {
            var client = (Service.Models.ClientModel)_clientService.GetById(Id).Data;

            Models.Client ModelClient = new Models.Client()
            {
                Age = client.Age,
                Email = client.Email,
                LastName = client.LastName,
                Name = client.Name,
                Password = client.Password,
                Id=client.Id
            };



            return View(ModelClient);
        }

        // POST: Clients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Client clientModel)
        {
            try
            {
                var myModel = clientModel;

                Movies.Service.Dtos.ClientUpdateDto client = new Service.Dtos.ClientUpdateDto()
                {
                    UpdatedDate = DateTime.Now,
                    Age = clientModel.Age,
                    Email =clientModel.Email,
                    Id = clientModel.Id,
                    LastName = clientModel.LastName,
                    Name = clientModel.Name,
                    PaymentMethodId = clientModel.PaymentMethodId
                    
                    


                };
             
              _clientService.UpdateClient(client);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception err)
            {
                Console.WriteLine(err);
                return View();
            }
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int Id)
        {

            var client = (Service.Models.ClientModel)_clientService.GetById(Id).Data;

            Models.Client ModelClient = new Models.Client()
            {
                Age = client.Age,
                Email = client.Email,
                LastName = client.LastName,
                Name = client.Name,
                Password = client.Password,
                Id = client.Id
            };


            return View(ModelClient);
        }

        // POST: Clients/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Client clientModel)
        {


            try
            {
                var myModel = clientModel;

                Service.Dtos.ClientRemoveDto clientRemove = new Service.Dtos.ClientRemoveDto()
                {
                    Id = clientModel.Id

                };

                _clientService.RemoveClient(clientRemove);
                

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
