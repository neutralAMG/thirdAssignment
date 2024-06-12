using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Interfaces.Contracts;
using thirdAssignment.Aplication.Models.LabTestAppointment;
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
        public async Task<IActionResult> Index()
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
            if (!_userValidations.UserIsAssistent()) return RedirectToAction("index", "Home");

            Result<List<LabTestAppointmentModel>> result = new();
            try
            {


                result = await _labTestAppointmentService.GetAllPending();

                if (!result.IsSuccess)
                {

                }
                return View(result.Data);

            }
            catch
            {

                throw;
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FilterByCedula(string Cedula)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
            if (!_userValidations.UserIsAssistent()) return RedirectToAction("index", "Home");

            Result<List<LabTestAppointmentModel>> result = new();
            try
            {
                if (Cedula.IsNullOrEmpty())
                {
                    result = await _labTestAppointmentService.GetAllPending();
                    ViewBag.Message = "Cedula was not enter";
                    return View("Index", result.Data);
                }
                result = await _labTestAppointmentService.FilterByCedula(Cedula);

                if (!result.IsSuccess)
                {

                }
                return View(result.Data);

            }
            catch
            {

                throw;
            }

        }


        // GET: LabResultsController/Create
        public async Task<IActionResult> SaveLabTestResult()
        {
			if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
            if (!_userValidations.UserIsAssistent()) return RedirectToAction("index", "Home");

            return View();
        }

        // POST: LabResultsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveLabTestResult(LabTestAppointmentSaveModel saveDto)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
            if (!_userValidations.UserIsAssistent()) return RedirectToAction("index", "Home");

            Result<LabTestAppointmentSaveModel> result = new();
            try
            {

                result = await _labTestAppointmentService.Save(saveDto);

                if (!result.IsSuccess)
                {
                    ViewBag.Message = result.Message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LabResultsController/Edit/5
        public async Task<IActionResult> EditLabTestResult(Guid id)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
            if (!_userValidations.UserIsAssistent()) return RedirectToAction("index", "Home");

            Result<LabTestAppointmentModel> result = new();
            try
            {
                result = await _labTestAppointmentService.GetById(id);

                if (!result.IsSuccess)
                {
                    ViewBag.Message = result.Message;
                    return RedirectToAction(nameof(Index));
                }

                return View(result.Data);

            }
            catch
            {

                throw;
            }

        }

        // POST: LabResultsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditLabTestResult(Guid id, LabTestAppointmentSaveModel updateDto)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
            if (!_userValidations.UserIsAssistent()) return RedirectToAction("index", "Home");

            Result<LabTestAppointmentSaveModel> result = new();
            try
            {

                updateDto.IsNotPending = true;

                result = await _labTestAppointmentService.Update(updateDto);

                if (!result.IsSuccess)
                {
                    Result<LabTestAppointmentModel> resultIner = new();

                    resultIner = await _labTestAppointmentService.GetById(id);
                    ViewBag.Message = result.Message;
                    return View(resultIner.Data);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}
