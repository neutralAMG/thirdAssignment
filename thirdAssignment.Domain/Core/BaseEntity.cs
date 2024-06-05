

using thirdAssignment.Domain.Entities;

namespace thirdAssignment.Domain.Core
{
    public class BaseEntity
    {
        public string Name { get; set; }
        public Guid Id = Guid.NewGuid();
    }

    public class ConsultingRoomStateBaseEntity : BaseEntity
    {
        public Guid ConsultingRoomId { get; set; }
        public ConsultingRoom ConsultingRoom { get; set; }
    }

    public class BaseUserLikeEntity : ConsultingRoomStateBaseEntity
    {
        public string LastName { get; set; }
        public string EMailAddress { get; set; }

    }

    public class BaseNonUserLikeEntity : BaseUserLikeEntity
    {
        public string PhoneNumber { get; set; }
        public string Cedula { get; set; }
        public string? ImgPath { get; set; }

    }
     
}
