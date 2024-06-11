using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Dtos;
using thirdAssignment.Aplication.Interfaces.Contracts;
using thirdAssignment.Aplication.Models;
using thirdAssignment.Aplication.Services;
using thirdAssignment.Presentation.Utils.SessionHandler;
using thirdAssignment.Presentation.Utils.UserValidations;

namespace thirdAssignment.Presentation.Controllers
{
    public class LabTestController : Controller
    {
		private readonly ILabTestService _labTestService;
		private readonly UserValidations _userValidations;

		public LabTestController(ILabTestService labTestService, UserValidations userValidations)
        {
			_labTestService = labTestService;
			_userValidations = userValidations;
		}
        // GET: LabTestController
        public async Task<IActionResult> Index()
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

            Result<List<LabTestModel>> result = new();
            try
            {
                var currentUser = HttpContext.Session.Get<UserModel>("user");

                result = await _labTestService.GetAll(currentUser.ConsultingRoom.Id);

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


        // GET: LabTestController/Create
        public async Task<IActionResult> SaveLabTest()
        {
			if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

			return View();
        }

        // POST: LabTestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveLabTest(SaveLabTestDto saveDto)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

            Result<LabTestModel> result = new();
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.message = ModelState.Values.SelectMany(v => v.Errors).First().ErrorMessage;
                    return View();
                }
                saveDto.ConsultingRoomId = HttpContext.Session.Get<UserModel>("user").ConsultingRoom.Id;

                result = await _labTestService.Save(saveDto);

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

        // GET: LabTestController/Edit/5
        public async Task<IActionResult> EditLabTest(Guid id)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

            Result<LabTestModel> result = new();
            try
            {

                result = await _labTestService.GetById(id);

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

        // POST: LabTestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditLabTest(Guid id, UpdateLabTestDto updateDto)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

            Result<LabTestModel> result = new();
            try
            {
                if (!ModelState.IsValid)
                {
                    result = await _labTestService.GetById(id);
                    ViewBag.message = ModelState.Values.SelectMany(v => v.Errors).First().ErrorMessage;
                    return View(result.Data);
                }

                result = await _labTestService.Update(updateDto);

                if (!result.IsSuccess)
                {
                    Result<LabTestModel> resultIner = new();

                    resultIner = await _labTestService.GetById(id);
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

        // GET: LabTestController/Delete/5
        public async Task<IActionResult> DeleteLabTest(Guid id)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

            Result<LabTestModel> result = new();
            try
            {
                result = await _labTestService.GetById(id);

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

        // POST: LabTestController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteLabTest(Guid id, IFormCollection collection)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

            Result<LabTestModel> result = new();
            try
            {
                result = await _labTestService.Delete(id);

                if (!result.IsSuccess)
                {
                    ViewBag.Message = result.Message;
                    return RedirectToAction(nameof(Index));
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
