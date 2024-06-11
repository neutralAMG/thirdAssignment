using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Dtos;
using thirdAssignment.Aplication.Interfaces.Contracts;
using thirdAssignment.Aplication.Models;
using thirdAssignment.Presentation.Utils.SessionHandler;
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

            Result<List<DoctorModel>> result = new();
            try
            {
                var currentUser = HttpContext.Session.Get<UserModel>("user");

                result = await _doctorService.GetAll(currentUser.ConsultingRoom.Id);

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

        // GET: DoctorController/Details/5
        public async Task<IActionResult> DoctorDetails(Guid id)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");


            Result<DoctorModel> result = new();
            try
            {
                result = await _doctorService.GetById(id);

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

        // GET: DoctorController/Create
        public async Task<IActionResult> SaveDoctor()
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

            return View();
        }

        // POST: DoctorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveDoctor(SaveDoctorDto saveDto, IFormFile img)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

            Result<DoctorModel> result = new();
            try
            {
                if(img != null)
                {
                    var path = Path.Combine(root,DateTime.Now.Ticks.ToString() + Path.GetExtension(img.FileName));
                     using(var stream = new FileStream(path, FileMode.Create))
                    {
                        await img.CopyToAsync(stream);
                    }
                   saveDto.ImgPath = path;
                }
              
              
                saveDto.ConsultingRoomId = HttpContext.Session.Get<UserModel>("user").ConsultingRoom.Id;
                
                result = await _doctorService.Save(saveDto);

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

        // GET: DoctorController/Edit/5
        public async Task<IActionResult> EditDoctor(Guid id)
        {

            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

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
        public async Task<IActionResult> EditDoctor(Guid id, UpdateDoctorDto updateDto)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

            Result<DoctorModel> result = new();
            try
            {


                result = await _doctorService.Update(updateDto);

                if (!result.IsSuccess)
                {
                    Result<DoctorModel> resultIner = new();

                    resultIner = await _doctorService.GetById(id);
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

        // GET: DoctorController/Delete/5
        public async Task<IActionResult> DeleteDoctor(Guid id)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

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

            Result<DoctorModel> result = new();
            try
            {
                result = await _doctorService.Delete(id);

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
