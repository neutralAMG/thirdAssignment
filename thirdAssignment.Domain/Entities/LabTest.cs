

using thirdAssignment.Domain.Core;

namespace thirdAssignment.Domain.Entities
{
    public class LabTest : ConsultingRoomStateBaseEntity
    {
        public Guid Id { get; set; }
        public IList<LabTestAppointment> labTestAppointments { get; set; }
    }
}
