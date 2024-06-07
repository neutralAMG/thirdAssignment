

using thirdAssignment.Domain.Core;

namespace thirdAssignment.Domain.Entities
{
    public class Patient : BaseNonUserLikeEntity
    {
        public Patient()
        {
            IsSmoker = false;
            HasAllergies = false;
        }
        public string Address { get; set; }
        public bool IsSmoker { get; set; }
        public bool HasAllergies { get; set; }
        public DateOnly BirthDate { get; set; }
        public Guid ConsultingRoomId { get; set; }
        public IList<Appointment> appointments { get; set; }
    }
}
