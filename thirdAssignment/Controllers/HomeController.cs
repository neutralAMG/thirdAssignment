using Microsoft.AspNetCore.Mvc;
using thirdAssignment.Presentation.Utils.UserValidations;

namespace thirdAssignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly UserValidations _userValidations;

		public HomeController(ILogger<HomeController> logger,  UserValidations userValidations)
        {
            _logger = logger;
			_userValidations = userValidations;
		}
		public IActionResult Index()
        {
			if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
			return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}
