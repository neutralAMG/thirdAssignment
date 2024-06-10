using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thirdAssignment.Aplication.Interfaces.Contracts;
using thirdAssignment.Presentation.Utils.UserValidations;

namespace thirdAssignment.Presentation.Controllers
{
    public class LabResultsController : Controller
    {
		private readonly ILabTestAppointmentService _labTestAppointmentService;
		private readonly UserValidations _userValidations;

		public LabResultsController(ILabTestAppointmentService labTestAppointmentService, UserValidations userValidations)
        {
			_labTestAppointmentService = labTestAppointmentService;
			_userValidations = userValidations;
		}
        // GET: LabResultsController
        public ActionResult Index()
        {
			if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
			return View();
        }

        // GET: LabResultsController/Details/5
        public ActionResult Details(int id)
        {
			if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

			return View();
        }

        // GET: LabResultsController/Create
        public ActionResult Create()
        {
			if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

			return View();
        }

        // POST: LabResultsController/Create
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

        // GET: LabResultsController/Edit/5
        public ActionResult Edit(int id)
        {
			if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

			return View();
        }

        // POST: LabResultsController/Edit/5
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

        // GET: LabResultsController/Delete/5
        public ActionResult Delete(int id)
        {
			if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

			return View();
        }

        // POST: LabResultsController/Delete/5
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
