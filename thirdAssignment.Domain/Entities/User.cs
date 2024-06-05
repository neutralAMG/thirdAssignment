

using thirdAssignment.Domain.Core;

namespace thirdAssignment.Domain.Entities
{
    public class User : BaseUserLikeEntity
    {
      
        public string UserName { get; set; }
        public string Password { get; set; }

        public int RolId { get; set; } 
        public UserRol UserRol { get; set; }
    }
}
