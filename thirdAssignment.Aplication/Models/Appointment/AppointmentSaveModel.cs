
using System.ComponentModel.DataAnnotations;


namespace thirdAssignment.Aplication.Models.Appointment
{
    public class AppointmentSaveModel
    {


        public Guid Id { get; set; }

        [Required(ErrorMessage = "the appointment date is a requierd field")]
        [DataType(DataType.Date)]
        public DateOnly AppointmentDate { get; set; }

        [Required(ErrorMessage = "the appointment time is a requierd field")]
        [DataType(DataType.Time)]
        public TimeOnly AppointmentTime { get; set; }

        [Required(ErrorMessage = "the appointment cause is a requierd field")]
        public string AppointmentCause { get; set; }

        [Required(ErrorMessage = "the Doctor  is a requierd field")]
        public Guid DoctorId { get; set; }

        [Required(ErrorMessage = "the patient is a requierd field")]
        public Guid PatientId { get; set; }

        public int AppointmentStateId { get; set; }

        public Guid? ConsultingRoomId { get; set; }
    }
}
