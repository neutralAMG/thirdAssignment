
using thirdAssignment.Aplication.Core;
using thirdAssignment.Domain.Entities;

namespace thirdAssignment.Aplication.Models
{
    public class UserModel 
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string EMailAddress { get; set; }

     //   public Guid ConsultingRoomId { get; set; }

        public string UserName { get; set; }

    //    public string Password { get; set; }

   //     public Guid RolId { get; set; }

        public UserRolModel UserRol { get; set; }
        public ConsultingRoomModel ConsultingRoom { get; set; }
    }
}
