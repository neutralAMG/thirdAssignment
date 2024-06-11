using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Dtos;
using thirdAssignment.Aplication.Interfaces.Contracts;
using thirdAssignment.Aplication.Models;
using thirdAssignment.Aplication.Services;
using thirdAssignment.Presentation.Utils.SessionHandler;
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

            Result<List<LabTestAppointmentModel>> result = new();
            try
            {
                var currentUser = HttpContext.Session.Get<UserModel>("user");

                result = await _labTestAppointmentService.GetAllPending(currentUser.ConsultingRoom.Id);

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

            Result<List<LabTestAppointmentModel>> result = new();
            try
            {
                var currentUser = HttpContext.Session.Get<UserModel>("user");

                if (Cedula.IsNullOrEmpty())
                {
                    
                    result = await _labTestAppointmentService.GetAllPending(currentUser.ConsultingRoom.Id);
                    return View("Index", result.Data);
                }
                result = await _labTestAppointmentService.FilterByCedula(Cedula);

                if (!result.IsSuccess)
                {

                }
                return View("Index", result.Data);

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

			return View();
        }

        // POST: LabResultsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveLabTestResult(SaveLabTestAppointmentDto saveDto)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

            Result<LabTestAppointmentModel> result = new();
            try
            {

                saveDto.ConsultingRoomId = HttpContext.Session.Get<UserModel>("user").ConsultingRoom.Id;

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
        public async Task<IActionResult> EditLabTestResult(Guid id, UpdateLabTestAppointmentDto updateDto)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

            Result<LabTestAppointmentModel> result = new();
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
