
using thirdAssignment.Domain.Core;

namespace thirdAssignment.Domain.Entities
{
    public class AppointmentState : BaseEntity
    {
        public int AppointmentStateId { get; set; }
        public IList<Appointment> appointments { get; set; }
    }
}
