
using thirdAssignment.Domain.Core;

namespace thirdAssignment.Domain.Entities
{
    public class Doctor : BaseNonUserLikeEntity
    {
        public Guid ConsultingRoomId { get; set; }
        public IList<Appointment> appointments { get; set; }
    }
}
