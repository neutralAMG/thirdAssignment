using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly ILabTestAppointmentService _labTestAppointmentService;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        private readonly ILabTestService _labTestService;
        private readonly UserValidations _userValidations;
        private readonly GenerateSelectList _generateSelectList;

        public AppointmentController(IAppointmentService appointmentService, ILabTestAppointmentService labTestAppointmentService, IPatientService patientService, IDoctorService doctorService, ILabTestService labTestService, UserValidations userValidations, GenerateSelectList generateSelectList)
        {
            _appointmentService = appointmentService;
            _labTestAppointmentService = labTestAppointmentService;
            _patientService = patientService;
            _doctorService = doctorService;
            _labTestService = labTestService;
            _userValidations = userValidations;
            _generateSelectList = generateSelectList;
        }
        // GET: AppointmentController
        public async Task<IActionResult> Index()
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

            Result<List<AppointmentModel>> result = new();
            try
            {
                var currentUser = HttpContext.Session.Get<UserModel>("user");

                result = await _appointmentService.GetAll(currentUser.ConsultingRoom.Id);

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

        // GET: AppointmentController/Details/5
        public async Task<IActionResult> AppointmentDetails(Guid id)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");


            Result<AppointmentModel> result = new();
            try
            {
                result = await _appointmentService.GetById(id);

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


        // GET: AppointmentController/Details/5
        public async Task<IActionResult> ConsultAnAppointmet(Guid id)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");


            Result<AppointmentModel> result = new();
            try
            {
                result = await _appointmentService.GetById(id);

                if (!result.IsSuccess)
                {

                }
                var currentUser = HttpContext.Session.Get<UserModel>("user");
                List<CheckBoxOption> Checkboxes = _generateSelectList.GenereteListOfLabTest(currentUser.ConsultingRoom.Id, _labTestService);

                CunsultAppointmentModel cunsultAppointment = new CunsultAppointmentModel { Checkboxes = Checkboxes, AppointmentModel = result.Data };

                return View(cunsultAppointment);

            }
            catch
            {

                throw;
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        // GET: AppointmentController/Details/5
        public async Task<IActionResult> ConsultAnAppointmet(Guid id, CunsultAppointmentModel cunsultAppointment, SaveAppointmentsDto saveDto)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

            try
            {

                Result<LabTestAppointmentModel> result = new();

                var currentUser = HttpContext.Session.Get<UserModel>("user");
                _appointmentService.Update(new UpdateAppointmentsDto { Id = cunsultAppointment.AppointmentModel.Id, AppointmentStateId = 2 });

                foreach (CheckBoxOption check in cunsultAppointment.Checkboxes)
                {
                    if (check.IsSelected == true)
                    {

                        result = await _labTestAppointmentService.Save(new SaveLabTestAppointmentDto
                        {
                            AppointmetId = cunsultAppointment.AppointmentModel.Id,
                            ConsultingRoomId = currentUser.ConsultingRoom.Id,
                            DoctorsId = saveDto.DoctorId,
                            PatientId = saveDto.PatientId,
                            labTesttId = new Guid(check.Id)
                        });


                        if (!result.IsSuccess)

                        {
                            Result<AppointmentModel> resultIner = new();
                            resultIner = await _appointmentService.GetById(id);
                            ViewBag.Message = result.Message;
                            return RedirectToAction("ConsultAnAppointmet");
                        }

                    }

                }

                return RedirectToAction("Index");

            }
            catch
            {

                throw;
            }
        }

        // GET: AppointmentController/Details/5
        public async Task<IActionResult> ReportAppointmentResult(Guid id)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");


            Result<AppointmentModel> result = new();
            try
            {
                result = await _appointmentService.GetById(id);

                if (!result.IsSuccess)
                {

                }
                var currentUser = HttpContext.Session.Get<UserModel>("user");

                return View(result.Data.labTestAppointments);

            }
            catch
            {

                throw;
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        // GET: AppointmentController/Details/5
        public async Task<IActionResult> ReportAppointmentResult(Guid id, UpdateAppointmentsDto updateAppointmentsDto)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

            try
            {

                Result<AppointmentModel> result = new();

                updateAppointmentsDto.AppointmentStateId = 3;

                result = await _appointmentService.Update(updateAppointmentsDto);
                if (!result.IsSuccess)
                {
                    Result<AppointmentModel> resultIner = new();
                    resultIner = await _appointmentService.GetById(id);
                    ViewBag.Message = result.Message;
                    return View(resultIner.Data.labTestAppointments);
                }
                return RedirectToAction("Index");

            }
            catch
            {

                throw;
            }
        }

        // GET: AppointmentController/Details/5
        public async Task<IActionResult> CheckAppointmentResult(Guid id)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");


            Result<AppointmentModel> result = new();
            try
            {
                result = await _appointmentService.GetById(id);

                if (!result.IsSuccess)
                {

                }
                var currentUser = HttpContext.Session.Get<UserModel>("user");

                return View(result.Data.labTestAppointments);

            }
            catch
            {

                throw;
            }
        }

        // POST: AppointmentController/Create
        public async Task<IActionResult> SaveAppointment()
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
            var currentUser = HttpContext.Session.Get<UserModel>("user");

            return View(new SaveAppointment { AppointmentList = _generateSelectList.ApoinmetsLists(currentUser.ConsultingRoom.Id, _patientService, _doctorService) });
        }

        // POST: AppointmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAppointment(SaveAppointmentsDto saveDto)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");

            Result<AppointmentModel> result = new();
            try
            {
               var currentUser = HttpContext.Session.Get<UserModel>("user");

                if (!ModelState.IsValid)
                {
                  
                    ViewBag.message = ModelState.Values.SelectMany(v => v.Errors).First().ErrorMessage;
                    return View(new SaveAppointment { AppointmentList = _generateSelectList.ApoinmetsLists(currentUser.ConsultingRoom.Id, _patientService, _doctorService) });
                }

               

                saveDto.ConsultingRoomId = currentUser.ConsultingRoom.Id;


                result = await _appointmentService.Save(saveDto);

                if (!result.IsSuccess)
                {
                    ViewBag.Message = result.Message;

                    return View(new SaveAppointment { AppointmentList = _generateSelectList.ApoinmetsLists(currentUser.ConsultingRoom.Id, _patientService, _doctorService) });
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
