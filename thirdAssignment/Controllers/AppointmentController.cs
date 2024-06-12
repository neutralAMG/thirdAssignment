
using Microsoft.AspNetCore.Mvc;
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Interfaces.Contracts;
using thirdAssignment.Aplication.Models.Appointment;
using thirdAssignment.Presentation.Models;
using thirdAssignment.Presentation.Utils;
using thirdAssignment.Aplication.Utils.SessionHandler;
using thirdAssignment.Presentation.Utils.UserValidations;
using thirdAssignment.Aplication.Models.User;
using thirdAssignment.Aplication.Models.LabTestAppointment;

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
            if (!_userValidations.UserIsAssistent()) return RedirectToAction("index", "Home");

            Result<List<AppointmentModel>> result = new();
            try
            {


                result = await _appointmentService.GetAll();

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
            if (!_userValidations.UserIsAssistent()) return RedirectToAction("index", "Home");


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
            if (!_userValidations.UserIsAssistent()) return RedirectToAction("index", "Home");


            Result<AppointmentModel> result = new();
            try
            {
                result = await _appointmentService.GetById(id);

                if (!result.IsSuccess)
                {

                }
                var currentUser = HttpContext.Session.Get<UserModel>("user");
                List<CheckBoxOption> Checkboxes = _generateSelectList.GenereteListOfLabTest( _labTestService);

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
        public async Task<IActionResult> ConsultAnAppointmet(Guid id, CunsultAppointmentModel cunsultAppointment, AppointmentSaveModel saveDto)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
            if (!_userValidations.UserIsAssistent()) return RedirectToAction("index", "Home");

            try
            {

                Result<LabTestAppointmentSaveModel> result = new();

   

                foreach (CheckBoxOption check in cunsultAppointment.Checkboxes)
                {
                    if (check.IsSelected == true)
                    {

                        result = await _labTestAppointmentService.Save(new LabTestAppointmentSaveModel
                        {
                            AppointmetId = saveDto.Id,
                            labTesttId = new Guid(check.Id)
                        });


                        if (!result.IsSuccess)
                        {
                            Result<AppointmentModel> resultIner = new();
                            resultIner = await _appointmentService.GetById(id);
                            ViewBag.Message = resultIner.Message;
							List<CheckBoxOption> Checkboxes = _generateSelectList.GenereteListOfLabTest(_labTestService);

							CunsultAppointmentModel cunsultAppointmet = new CunsultAppointmentModel { Checkboxes = Checkboxes, AppointmentModel = resultIner.Data };
							return View(cunsultAppointmet);
                        }

                    }

                }

                
              await  _appointmentService.SetToReportResult(saveDto);

				if (!result.IsSuccess)
				{
					Result<AppointmentModel> resultIner = new();
					resultIner = await _appointmentService.GetById(id);
					ViewBag.Message = resultIner.Message;
					List<CheckBoxOption> Checkboxes = _generateSelectList.GenereteListOfLabTest(_labTestService);

					CunsultAppointmentModel cunsultAppointmet = new CunsultAppointmentModel { Checkboxes = Checkboxes, AppointmentModel = resultIner.Data };
					return View(cunsultAppointmet);
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
            if (!_userValidations.UserIsAssistent()) return RedirectToAction("index", "Home");


            Result<AppointmentModel> result = new();
            try
            {
                result = await _appointmentService.GetById(id);

                if (!result.IsSuccess)
                {

                }

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
        public async Task<IActionResult> ReportAppointmentResult(Guid id, AppointmentSaveModel updateAppointmentsDto)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
            if (!_userValidations.UserIsAssistent()) return RedirectToAction("index", "Home");

            try
            {

                Result<AppointmentSaveModel> result = new();

              

                result = await _appointmentService.SetToReportComplete(updateAppointmentsDto);
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
            if (!_userValidations.UserIsAssistent()) return RedirectToAction("index", "Home");

            var currentUser = HttpContext.Session.Get<UserModel>("user");

            return View(new SaveAppointment { AppointmentList = _generateSelectList.ApoinmetsLists( _patientService, _doctorService) });
        }

        // POST: AppointmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAppointment(AppointmentSaveModel saveDto)
        {
            if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
            if (!_userValidations.UserIsAssistent()) return RedirectToAction("index", "Home");

            Result<AppointmentSaveModel> result = new();
            try
            {
               var currentUser = HttpContext.Session.Get<UserModel>("user");

                if (!ModelState.IsValid)
                {
                  
                    ViewBag.message = ModelState.Values.SelectMany(v => v.Errors).First().ErrorMessage;
                    return View(new SaveAppointment { AppointmentList = _generateSelectList.ApoinmetsLists( _patientService, _doctorService) });
                }

                result = await _appointmentService.Save(saveDto);

                if (!result.IsSuccess)
                {
                    ViewBag.Message = result.Message;

                    return View(new SaveAppointment { AppointmentList = _generateSelectList.ApoinmetsLists( _patientService, _doctorService) });
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
