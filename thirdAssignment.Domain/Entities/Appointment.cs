
using thirdAssignment.Domain.Core;

namespace thirdAssignment.Domain.Entities
{
    public class Appointment : ConsultingRoomStateBaseEntity
    {
        
        public Appointment()
        {
            AppointmentDate = DateOnly.FromDateTime(Date);
            AppointmentTime = TimeOnly.FromDateTime(Date);
            Name = $" Apointment for {Patient.Name} made in {AppointmentDate} on {AppointmentTime}";
        }

        private readonly DateTime Date = DateTime.Now;   
        public Guid AppointmentsId { get; set; }
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
