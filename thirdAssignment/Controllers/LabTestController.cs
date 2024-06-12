using Microsoft.AspNetCore.Mvc;
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Interfaces.Contracts;
using thirdAssignment.Aplication.Models.LabTest;
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
            if (!_userValidations.UserIsAdmin()) return RedirectToAction("index", "Home");

            Result<List<LabTestModel>> result = new();
            try
            {


                result = await _labTestService.GetAll();

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
            if (!_userValidations.UserIsAdmin()) return RedirectToAction("index", "Home");

            return View();
        }

        // POST: LabTestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveLabTest(LabTestSaveModel saveDto)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
            if (!_userValidations.UserIsAdmin()) return RedirectToAction("index", "Home");

            Result<LabTestSaveModel> result = new();
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.message = ModelState.Values.SelectMany(v => v.Errors).First().ErrorMessage;
                    return View();
                }

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
            if (!_userValidations.UserIsAdmin()) return RedirectToAction("index", "Home");

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
        public async Task<IActionResult> EditLabTest(Guid id, LabTestSaveModel updateDto)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
            if (!_userValidations.UserIsAdmin()) return RedirectToAction("index", "Home");

            Result<LabTestSaveModel> result = new();
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.message = ModelState.Values.SelectMany(v => v.Errors).First().ErrorMessage;
                    return View(await _labTestService.GetById(id));
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
            if (!_userValidations.UserIsAdmin()) return RedirectToAction("index", "Home");

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
            if (!_userValidations.UserIsAdmin()) return RedirectToAction("index", "Home");

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
