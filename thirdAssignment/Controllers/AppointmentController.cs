using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thirdAssignment.Aplication.Interfaces.Contracts;
using thirdAssignment.Presentation.Utils.UserValidations;

namespace thirdAssignment.Presentation.Controllers
{
    public class AppointmentController : Controller
    {
		private readonly IAppointmentService _appointmentService;
		private readonly UserValidations _userValidations;

		public AppointmentController(IAppointmentService appointmentService, UserValidations userValidations)
        {
			_appointmentService = appointmentService;
			_userValidations = userValidations;
		}
        // GET: AppointmentController
        public ActionResult Index()
        {
			if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

			return View();
        }

        // GET: AppointmentController/Details/5
        public ActionResult Details(int id)
        {
			if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

			return View();
        }

        // GET: AppointmentController/Create
        public ActionResult Create()
        {
			if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

			return View();
        }

        // POST: AppointmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
			if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

			try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AppointmentController/Edit/5
        public ActionResult Edit(int id)
        {
			if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

			return View();
        }

        // POST: AppointmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
			if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

			try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AppointmentController/Delete/5
        public ActionResult Delete(int id)
        {
			if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

			return View();
        }

        // POST: AppointmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
			if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

			try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
