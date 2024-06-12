using Microsoft.AspNetCore.Mvc.Rendering;

using thirdAssignment.Aplication.Interfaces.Contracts;
using thirdAssignment.Aplication.Models;
using thirdAssignment.Aplication.Models.Appointment;
using thirdAssignment.Aplication.Models.Patient;
using thirdAssignment.Aplication.Models.User;
using thirdAssignment.Presentation.Models;


namespace thirdAssignment.Presentation.Utils
{
    public class GenerateSelectList
    {
        private readonly List<UserRolModel> rols = ValuesHelper.GetRols().Select(r => r.Value).ToList();

        private readonly List<AppointmentStateModel> appoinments = ValuesHelper.GetAppointmentState().Select(a => a.Value).ToList();
        public List<SelectListItem> GenereteRollsSelectList()
        {

            List<SelectListItem>? AllRols = rols.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name.ToString(),
            }).ToList();

            AllRols.Add(new SelectListItem { Value = null, Selected = true, Text = "Select Rol" });



            return AllRols;
        }
        public List<SelectListItem> GenereteAppointmentStateSelectList()
        {
            List<SelectListItem>? AllappoinmentsState = appoinments.Select(g => new SelectListItem
            {
                Value = g.Id.ToString(),
                Text = g.Name,
            }).ToList();

            AllappoinmentsState.Add(new SelectListItem { Value = null, Selected = true, Text = "Select AppointmentState" });
            return AllappoinmentsState;
        }

        public List<SelectListItem> GenereteRollsSelectList(UserModel userModel)
        {

            List<SelectListItem>? AllRols = rols.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name.ToString(),
            }).ToList();

            if (AllRols.Any()) AllRols.Find(p => p.Value == userModel.UserRol.Id.ToString()).Selected = true;

            return AllRols;
        }
        public List<SelectListItem> GenereteAppointmentStateSelectList(AppointmentModel appointmentModel)
        {
            List<SelectListItem>? AllappoinmentsState = appoinments.Select(g => new SelectListItem
            {
                Value = g.Id.ToString(),
                Text = g.Name,
            }).ToList();

            if (AllappoinmentsState.Any()) AllappoinmentsState.Find(p => p.Value == appointmentModel.AppointmentState.Id.ToString()).Selected = true;

            return AllappoinmentsState;
        }
        public Dictionary<int, List<SelectListItem>> GenereteCheckBoxList()
        {
            List<SelectListItem>? Smokes = new()
            {
                new SelectListItem
                {

                    Value = 1.ToString(),
                    Text = "Smokes",
                },
                new SelectListItem
                {


                    Value = 2.ToString(),
                    Text = "Dont Smokes",
                }
            };
            Smokes.Add(new SelectListItem { Value = null, Selected = true, Text = "Does The pasient smoke's?" });


            List<SelectListItem>? HasAlergiies = new()
            {
                new SelectListItem
                {

                    Value = 1.ToString(),
                    Text = "Has Alergies",
                },
                new SelectListItem
                {
                    Value = 2.ToString(),
                    Text = "Dont have allergies",
                }
            };


            HasAlergiies.Add(new SelectListItem { Value = null, Selected = true, Text = "The pasient has allergies?" });


            Dictionary<int, List<SelectListItem>> selects = new()
            {
                {1, Smokes},
                {2, HasAlergiies}
            };
            return selects;
        }


        public Dictionary<int, List<SelectListItem>> GenereteCheckBoxList(PatientModel patientModel)
        {
            List<SelectListItem>? Smokes = new()
            {
                new SelectListItem
                {

                    Value = 1.ToString(),
                    Text = "Smokes",
                },
                new SelectListItem
                {


                    Value = 2.ToString(),
                    Text = "Dont Smokes",
                }
            };
            if (patientModel.IsSmoker == true)
            {
                Smokes[0].Selected = true;

            }
            else { Smokes[1].Selected = true; }




            List<SelectListItem>? HasAlergiies = new()
            {
                new SelectListItem
                {

                    Value = 1.ToString(),
                    Text = "Has Alergies",
                },
                new SelectListItem
                {
                    Value = 2.ToString(),
                    Text = "Dont have allergies",
                }
            };
            if (patientModel.HasAllergies == true)
            {
                HasAlergiies[0].Selected = true;

            }
            else { HasAlergiies[1].Selected = true; }



            Dictionary<int, List<SelectListItem>> selects = new()
            {
                {1, Smokes},
                {2, HasAlergiies}
            };
            return selects;
        }

        public  Dictionary<int, List<SelectListItem>> ApoinmetsLists( IPatientService patientService, IDoctorService doctorService)
        {
            List<SelectListItem>? patients = patientService.GetAll().Result.Data.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name,
            }).ToList();

             patients.Add(new SelectListItem { Value = null, Selected = true, Text = "Select a patient" });


            List<SelectListItem>? Doctors = doctorService.GetAll().Result.Data.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name,
            }).ToList();

            Doctors.Add(new SelectListItem { Value = null, Selected = true, Text = "Select a Doctor" });

            Dictionary<int, List<SelectListItem>> selects = new()
            {
                {1, patients},
                {2, Doctors}
            };

            return selects;
        }
        public List<CheckBoxOption> GenereteListOfLabTest(ILabTestService labTestService)
        {
            List<CheckBoxOption>? AllLabTest = labTestService.GetAll().Result.Data.Select(l => new CheckBoxOption
            {
               Id = l.Id.ToString(),
               Name = l.Name,
               IsSelected = false,
            }).ToList();

            return AllLabTest;
        }
    }
}
