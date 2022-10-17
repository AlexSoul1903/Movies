using Microsoft.AspNetCore.Mvc;

namespace Movies.web.Controllers
{
	public class HomeController1 : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
