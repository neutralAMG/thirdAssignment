
using thirdAssignment.Domain.Core;

namespace thirdAssignment.Domain.Entities
{
    public class AppointmentState : BaseEntity
    {

        public IList<Appointment> appointments { get; set; }
    }
}
