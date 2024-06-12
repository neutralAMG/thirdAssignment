
using System.ComponentModel.DataAnnotations;
using thirdAssignment.Aplication.Models.Doctor;
using thirdAssignment.Aplication.Models.LabTestAppointment;
using thirdAssignment.Aplication.Models.Patient;

namespace thirdAssignment.Aplication.Models.Appointment
{
    public class AppointmentModel
    {

        public string Name { get; set; }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "the appointment date is a requierd field")]
        public DateOnly AppointmentDate { get; set; }

        [Required(ErrorMessage = "the appointment time is a requierd field")]
        public TimeOnly AppointmentTime { get; set; }

        [Required(ErrorMessage = "the appointment cause is a requierd field")]
        public string AppointmentCause { get; set; }

        public DoctorModel Doctor { get; set; }
        public PatientModel Patient { get; set; }
        public AppointmentStateModel AppointmentState { get; set; }

        public IList<LabTestAppointmentModel> labTestAppointments { get; set; }
    }
}
