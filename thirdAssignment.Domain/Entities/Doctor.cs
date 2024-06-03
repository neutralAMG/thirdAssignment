
using thirdAssignment.Domain.Core;

namespace thirdAssignment.Domain.Entities
{
    public class Doctor : BaseNonUserLikeEntity
    {
        public Guid DoctorId { get; set; }
        public IList<Appointment> appointments { get; set; }
    }
}
