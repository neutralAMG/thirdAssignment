using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Dtos;
using thirdAssignment.Aplication.Interfaces.Contracts;
using thirdAssignment.Aplication.Models;
using thirdAssignment.Models;
using thirdAssignment.Presentation.Utils.SessionHandler;
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
