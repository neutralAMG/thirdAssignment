
using System.ComponentModel.DataAnnotations.Schema;
using thirdAssignment.Domain.Core;

namespace thirdAssignment.Domain.Entities
{
    public class LabTestAppointment : ConsultingRoomStateBaseEntity
    {
        public LabTestAppointment()
        {
            Name = $" test's for the appointment {AppointmetId}";
            IsNotPending = false;
        }
        public Guid AppointmetId { get; set; }
        public Guid LabTesttId { get; set; }
        public Guid DoctorsId { get; set; }
        public Guid PatientId { get; set; }
        public bool IsNotPending { get; set; }
        public string TestResult { get; set; }

        [ForeignKey("AppointmetId")]
        public Appointment Appointment { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
        [ForeignKey("DoctorsId")]
        public Doctor Doctor { get; set; }
        [ForeignKey("LabTesttId")]
        public LabTest LabTest { get; set; }

    }
}
