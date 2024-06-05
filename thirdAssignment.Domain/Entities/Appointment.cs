
using thirdAssignment.Domain.Core;

namespace thirdAssignment.Domain.Entities
{
    public class Appointment : ConsultingRoomStateBaseEntity
    {
        
        public Appointment()
        {

            Name = $" Apointment for {Patient.Name} made in {AppointmentDate} on {AppointmentTime}";
        }


        public DateOnly AppointmentDate {  get; set; }
        public TimeOnly AppointmentTime {  get; set; }
        public string AppointmentCause { get; set; }

        public int AppointmentStateId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public Guid ConsultingRoomId { get; set; }

        public ConsultingRoom ConsultingRoom { get; set; }

        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }    
        public AppointmentState AppointmentState { get; set; }

        public IList<LabTestAppointment> labTestAppointments { get; set; }
    }
}
