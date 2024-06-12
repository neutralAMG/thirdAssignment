
using Microsoft.AspNetCore.Mvc;
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Dtos;
using thirdAssignment.Aplication.Interfaces.Contracts;
using thirdAssignment.Aplication.Models.Doctor;
using thirdAssignment.Aplication.Models.Patient;
using thirdAssignment.Aplication.Services;
using thirdAssignment.Presentation.Utils.UserValidations;

namespace thirdAssignment.Presentation.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly UserValidations _userValidations;
        private readonly string root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot") ;

        public DoctorController(IDoctorService doctorService, UserValidations userValidations)
        {
            _doctorService = doctorService;
            _userValidations = userValidations;
        }
        // GET: DoctorController
        public async Task<IActionResult> Index()
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
            if (!_userValidations.UserIsAdmin()) return RedirectToAction("index", "Home");

            Result<List<DoctorModel>> result = new();
            try
            {


                result = await _doctorService.GetAll();

                if (!result.IsSuccess)
                {

                }
          //      var displayData = result.Data.Where(d => d.ImgPath = Directory.GetFiles(root,".png").Select(Path.GetFileName) ).ToList();
                return View(result.Data);

            }
            catch
            {

                throw;
            }


        }

        // GET: DoctorController/Create
        public async Task<IActionResult> SaveDoctor()
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
            if (!_userValidations.UserIsAdmin()) return RedirectToAction("index", "Home");

            return View(new DoctorSaveModel());
        }

        // POST: DoctorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveDoctor(DoctorSaveModel saveDto)
        {
            //IFormFile img
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
            if (!_userValidations.UserIsAdmin()) return RedirectToAction("index", "Home");

            Result<DoctorSaveModel> result = new();
            try
            {



                //if (img != null)
                //{
                //    var path = Path.Combine(root,DateTime.Now.Ticks.ToString() + Path.GetExtension(img.FileName));
                //     using(var stream = new FileStream(path, FileMode.Create))
                //    {
                //        await img.CopyToAsync(stream);
                //    }
                 
                //}
         

                if (!ModelState.IsValid)
                {
                    ViewBag.message = ModelState.Values.SelectMany(v => v.Errors).First().ErrorMessage;
                    return View(new DoctorSaveModel());
                }
                //if (saveDto.ImgPath.IsNullOrEmpty()){
                //    ViewBag.message = "the Imge field is requierd";
                //    return View();
                //}
                
                 result = await _doctorService.Save(saveDto);

                 DoctorSaveModel savedDoctor = result.Data;

                  if (savedDoctor != null && savedDoctor.Id != null) { 

                    savedDoctor.ImgPath = UploadFile(saveDto.File, savedDoctor.Id);

                    result =  await _doctorService.Update(savedDoctor);
                   }



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

		private string UploadFile(IFormFile filePath, Guid id, bool editmode = false, string ImgUrl = "")
		{
			if (editmode && filePath == null)
			{
				return ImgUrl;
			}
			//Get directory path
			string basePath = $"/Images/Doctors/{id}";
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
			return $"{basePath}/{filename}";
		}
		// GET: DoctorController/Edit/5
		public async Task<IActionResult> EditDoctor(Guid id)
        {

            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
            if (!_userValidations.UserIsAdmin()) return RedirectToAction("index", "Home");

            Result<DoctorModel> result = new();
            try
            {
                result = await _doctorService.GetById(id);

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

        // POST: DoctorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDoctor(Guid id, DoctorSaveModel updateDto)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
            if (!_userValidations.UserIsAdmin()) return RedirectToAction("index", "Home");

            Result<DoctorSaveModel> result = new();
            try
            {
              

                if (!ModelState.IsValid)
                {
                   ViewBag.message = ModelState.Values.SelectMany(v => v.Errors).First().ErrorMessage;
                    Result<DoctorModel> resultIner = new();
                    resultIner = await _doctorService.GetById(id);
                    return View(resultIner.Data);
				}
               

				DoctorModel doctor = _doctorService.GetById(updateDto.Id).Result.Data;


				updateDto.ImgPath = UploadFile(updateDto.File, doctor.Id, true, doctor.ImgPath);

				
 result = await _doctorService.Update(updateDto);


				if (!result.IsSuccess)
                { 
                    ViewBag.Message = result.Message;
                    Result<DoctorModel> resultIner = new();
                    resultIner = await _doctorService.GetById(updateDto.Id);
                    return View(resultIner.Data);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DoctorController/Delete/5
        public async Task<IActionResult> DeleteDoctor(Guid id)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
            if (!_userValidations.UserIsAdmin()) return RedirectToAction("index", "Home");

            Result<DoctorModel> result = new();
            try
            {
                result = await _doctorService.GetById(id);

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

        // POST: DoctorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDoctor(Guid id, IFormCollection collection)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
            if (!_userValidations.UserIsAdmin()) return RedirectToAction("index", "Home");

            Result<DoctorModel> result = new();
            try
            {
                result = await _doctorService.Delete(id);

                if (!result.IsSuccess)
                {
                    ViewBag.Message = result.Message;
                    return RedirectToAction(nameof(Index));
                }

				string basePath = $"/Images/Doctors/{id}";
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
