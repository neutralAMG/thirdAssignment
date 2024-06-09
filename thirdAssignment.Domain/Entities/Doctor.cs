
using thirdAssignment.Domain.Core;

namespace thirdAssignment.Domain.Entities
{
    public class Doctor : BaseNonUserLikeEntity
    {
        public IList<Appointment> appointments { get; set; }
    }
}
