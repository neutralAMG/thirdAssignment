using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Dtos;
using thirdAssignment.Aplication.Interfaces.Contracts;
using thirdAssignment.Aplication.Models.Doctor;
using thirdAssignment.Aplication.Models.Patient;
using thirdAssignment.Aplication.Services;
using thirdAssignment.Presentation.Models;
using thirdAssignment.Presentation.Utils;
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
            if (!_userValidations.UserIsAssistent()) return RedirectToAction("index", "Home");

            Result<List<Aplication.Models.Patient.PatientModel>> result = new();
            try
            {


                result = await _patientService.GetAll();

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
            if (!_userValidations.UserIsAssistent()) return RedirectToAction("index", "Home");

            ViewBag.IsSmoker= true;
            ViewBag.HasAllergies = true;

            return View(_generateSelectList.GenereteCheckBoxList());
        }

        // POST: PatientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SavePatient(PatienSaveModel saveDto, int smokes, int hasAlergies)
        
        {
            //IFormFile img
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
            if (!_userValidations.UserIsAssistent()) return RedirectToAction("index", "Home");

            Result<PatienSaveModel> result = new();
            try
            {


                if (!ModelState.IsValid)
                {
                    ViewBag.message = ModelState.Values.SelectMany(v => v.Errors).First().ErrorMessage;
                    return View(_generateSelectList.GenereteCheckBoxList());
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

                result = await _patientService.Save(saveDto);




                PatienSaveModel savedDoctor = result.Data;

                if (savedDoctor != null && savedDoctor.Id != null)
                {
                    savedDoctor.ImgPath = UploadFile(saveDto.File, savedDoctor.Id);

                    result = await _patientService.Update(savedDoctor);
                }



                if (!result.IsSuccess)
                {
                    ViewBag.Message = result.Message;
                    return View(_generateSelectList.GenereteCheckBoxList());
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(_generateSelectList.GenereteCheckBoxList());
            }
        }

        private string UploadFile(IFormFile filePath, Guid id, bool editmode = false, string ImgUrl = "")
        {
            if (editmode && filePath == null)
            {
                return ImgUrl;
            }
            //Get directory path
            string basePath = $"/Images/Patients/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            //create folder if not exits
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            // get file path
            Guid guid = Guid.NewGuid();

            FileInfo fileInfo = new(filePath.FileName);

            string filename = guid + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, filename);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                filePath.CopyTo(stream);
            }

            if (editmode)
            {
                string[] oldImgUrlPort = ImgUrl.Split("/");
                string oldImageName = oldImgUrlPort[^1];
                string CompleteOldPath = Path.Combine(path, oldImageName);
                if (System.IO.File.Exists(CompleteOldPath))
                {
                    System.IO.File.Delete(CompleteOldPath); 
                }
			}
            return $"{basePath}/{ filename}";
        }

        // GET: PatientController/Edit/5
        public async Task<IActionResult> EditPatient(Guid id)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
            if (!_userValidations.UserIsAssistent()) return RedirectToAction("index", "Home");

            Result<Aplication.Models.Patient.PatientModel> result = new();
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
        public async Task<IActionResult> EditPatient(Guid id, PatienSaveModel updateDto, int smokes, int hasAlergies)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
            if (!_userValidations.UserIsAssistent()) return RedirectToAction("index", "Home");

            Result<PatienSaveModel> result = new();
            try
            {


                if (!ModelState.IsValid)
                {
                    Result<Aplication.Models.Patient.PatientModel> resultIner = new();

                    resultIner = await _patientService.GetById(id);
                    ViewBag.message = ModelState.Values.SelectMany(v => v.Errors).First().ErrorMessage;
                    return View(new EditPatientModel { Checkboxes = _generateSelectList.GenereteCheckBoxList(resultIner.Data), patientModel = resultIner.Data });
                }

                updateDto.IsSmoker = smokes == 1 ? true : false;

                updateDto.HasAllergies = hasAlergies == 1 ? true : false;

                PatientModel patient = _patientService.GetById(updateDto.Id).Result.Data;
				
                    
                updateDto.ImgPath = UploadFile(updateDto.File, patient.Id, true, patient.ImgPath);

				result = await _patientService.Update(updateDto);



                if (!result.IsSuccess)
                {
                    Result<Aplication.Models.Patient.PatientModel> resultIner = new();

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
            if (!_userValidations.UserIsAssistent()) return RedirectToAction("index", "Home");

            Result<Aplication.Models.Patient.PatientModel> result = new();
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
            if (!_userValidations.UserIsAssistent()) return RedirectToAction("index", "Home");

            Result<Aplication.Models.Patient.PatientModel> result = new();
            try
            {
                result = await _patientService.Delete(id);

                if (!result.IsSuccess)
                {
                    ViewBag.Message = result.Message;
                    return RedirectToAction(nameof(Index));
                }

				string basePath = $"/Images/Patients/{id}";
				string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");
				if (Directory.Exists(path))
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(path);
					foreach (FileInfo file in directoryInfo.GetFiles())
					{
						file.Delete();
					}

					foreach (DirectoryInfo folder in directoryInfo.GetDirectories())
					{
						folder.Delete(true);
					}
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
