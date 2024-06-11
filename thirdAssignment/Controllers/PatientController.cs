using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Dtos;
using thirdAssignment.Aplication.Interfaces.Contracts;
using thirdAssignment.Aplication.Models;
using thirdAssignment.Aplication.Services;
using thirdAssignment.Presentation.Models;
using thirdAssignment.Presentation.Utils;
using thirdAssignment.Presentation.Utils.SessionHandler;
using thirdAssignment.Presentation.Utils.UserValidations;

namespace thirdAssignment.Presentation.Controllers
{
    public class PatientController : Controller
    {
		private readonly IPatientService _patientService;
		private readonly UserValidations _userValidations;
        private readonly GenerateSelectList _generateSelectList;
        private readonly string root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        public PatientController(IPatientService patientService ,UserValidations userValidations, GenerateSelectList generateSelectList)
        {
			_patientService = patientService;
			_userValidations = userValidations;
            _generateSelectList = generateSelectList;
        }
        // GET: PatientController
        public async Task<IActionResult> Index()
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

            Result<List<PatientModel>> result = new();
            try
            {
                var currentUser = HttpContext.Session.Get<UserModel>("user");

                result = await _patientService.GetAll(currentUser.ConsultingRoom.Id);

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



        // GET: PatientController/Create
        public async Task<IActionResult> SavePatient()
        {
			if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
            ViewBag.IsSmoker= true;
            ViewBag.HasAllergies = true;

            return View(_generateSelectList.GenereteCheckBoxList());
        }

        // POST: PatientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SavePatient(SavePatientDto saveDto, int smokes, int hasAlergies)
        
        {
            //IFormFile img
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

            Result<PatientModel> result = new();
            try
            {

                if (!ModelState.IsValid)
                {
                    ViewBag.message = ModelState.Values.SelectMany(v => v.Errors).First().ErrorMessage;
                    return View(_generateSelectList.GenereteCheckBoxList());
                }
                if (saveDto.ImgPath.IsNullOrEmpty())
                {
                    ViewBag.message = "the Imge field is requierd";
                    return View();
                }

                //if (img != null)
                //{
                //    var path = Path.Combine(root, DateTime.Now.Ticks.ToString() + Path.GetExtension(img.FileName));
                //    using (var stream = new FileStream(path, FileMode.Create))
                //    {
                //        await img.CopyToAsync(stream);
                //    }
                //    saveDto.ImgPath = path;
                //}


                saveDto.IsSmoker =  smokes == 1 ? true : false;

                saveDto.HasAllergies = hasAlergies == 1? true : false;

                saveDto.ConsultingRoomId = HttpContext.Session.Get<UserModel>("user").ConsultingRoom.Id;

                result = await _patientService.Save(saveDto);

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

        // GET: PatientController/Edit/5
        public async Task<IActionResult> EditPatient(Guid id)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

            Result<PatientModel> result = new();
            try
            {

                result = await _patientService.GetById(id);

                if (!result.IsSuccess)
                {
                    ViewBag.Message = result.Message;
                    return RedirectToAction(nameof(Index));
                }

                return View(new EditPatientModel{ Checkboxes = _generateSelectList.GenereteCheckBoxList(result.Data), patientModel= result.Data} );

            }
            catch
            {

                throw;
            }
        }

        // POST: PatientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPatient(Guid id, UpdatePatientDto updateDto, int smokes, int hasAlergies)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

            Result<PatientModel> result = new();
            try
            {


                if (!ModelState.IsValid)
                {
                    result = await _patientService.GetById(id);
                   ViewBag.message = ModelState.Values.SelectMany(v => v.Errors).First().ErrorMessage;
                    return View(new EditPatientModel { Checkboxes = _generateSelectList.GenereteCheckBoxList(result.Data), patientModel = result.Data });
                }

                updateDto.IsSmoker = smokes == 1 ? true : false;

                updateDto.HasAllergies = hasAlergies == 1 ? true : false;

                result = await _patientService.Update(updateDto);


                if (!result.IsSuccess)
                {
                    Result<PatientModel> resultIner = new();

                    resultIner = await _patientService.GetById(id);
                    ViewBag.Message = result.Message;
                    return View(new EditPatientModel { Checkboxes = _generateSelectList.GenereteCheckBoxList(resultIner.Data), patientModel = resultIner.Data });
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientController/Delete/5
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

            Result<PatientModel> result = new();
            try
            {
                result = await _patientService.GetById(id);

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

        // POST: PatientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePatient(Guid id, IFormCollection collection)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

            Result<PatientModel> result = new();
            try
            {
                result = await _patientService.Delete(id);

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
