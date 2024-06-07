
using thirdAssignment.Domain.Core;

namespace thirdAssignment.Domain.Entities
{
    public class LabTestAppointment : ConsultingRoomStateBaseEntity
    {
        public LabTestAppointment()
        {
            Name = $" test's for the appointment {appointment.Name}";
            IsNotPending = false;
        }
        public Guid LabTestAppointmentId { get; set; }
        public Guid AppointmetId { get; set; }
        public Guid labTesttId { get; set; }
        public bool IsNotPending { get; set; }
        public string TestResult { get; set; }

        public Guid ConsultingRoomId { get; set; }

        public Appointment appointment { get; set; }
        public Patient patient { get; set; }
        public LabTest labTest { get; set; }

    }
}
