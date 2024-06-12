
using System.ComponentModel.DataAnnotations.Schema;
using thirdAssignment.Domain.Core;

namespace thirdAssignment.Domain.Entities
{
    public class Appointment : ConsultingRoomStateBaseEntity
    {

        public DateOnly AppointmentDate { get; set; }
        public TimeOnly AppointmentTime { get; set; }

        public string AppointmentCause { get; set; }
        public int AppointmentStateId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }


        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
        [ForeignKey("AppointmentStateId")]
        public AppointmentState AppointmentState { get; set; }

        public IList<LabTestAppointment> labTestAppointments { get; set; }
    }
}
