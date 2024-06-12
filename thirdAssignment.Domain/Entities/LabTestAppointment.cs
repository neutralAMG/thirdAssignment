
using System.ComponentModel.DataAnnotations.Schema;
using thirdAssignment.Domain.Core;

namespace thirdAssignment.Domain.Entities
{
    public class LabTestAppointment : ConsultingRoomStateBaseEntity
    {

        public Guid AppointmetId { get; set; }
        public Guid LabTesttId { get; set; }
        public bool IsNotPending { get; set; }
        public string TestResult { get; set; }

        [ForeignKey("AppointmetId")]
        public Appointment Appointment { get; set; }
        [ForeignKey("LabTesttId")]
        public LabTest LabTest { get; set; }

    }
}
