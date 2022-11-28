using Microsoft.AspNetCore.Mvc;
using Movies.Service.Contracts;
using Movies.Service.Core;
using Movies.Service.Models;
using Movies.web.Extentions;
using Movies.web.Models;

namespace Movies.web.Controllers
{
	public class AccessController : Controller
	{

        private readonly IClientService _clientService;
        public AccessController(IClientService clientService)
        {
            _clientService = clientService;
        }




        public IActionResult Index()
		{
			return View();
		}

		public IActionResult register()
		{
			return View();
		}

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

      


    }   
}
