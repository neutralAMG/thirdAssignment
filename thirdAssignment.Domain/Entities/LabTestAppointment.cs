
using thirdAssignment.Domain.Core;

namespace thirdAssignment.Domain.Entities
{
    public class LabTestAppointment : ConsultingRoomStateBaseEntity
    {
        public LabTestAppointment()
        {
            Name = $" test's for the appointment {appointment.Name}";
        }
        public int LabTestAppointmentId { get; set; }
        public Guid AppointmetId { get; set; }
        public Guid TestId { get; set; }
        public bool IsPending { get; set; }
        public string TestResult { get; set; }

        public Appointment appointment { get; set; }
        public LabTest labTest { get; set; }

    }
}
