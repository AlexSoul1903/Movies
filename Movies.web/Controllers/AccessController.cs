using Microsoft.AspNetCore.Mvc;
using Movies.web.Models;

namespace Movies.web.Controllers
{
	public class AccessController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult register()
		{
			return View();
		}




	}   
}
