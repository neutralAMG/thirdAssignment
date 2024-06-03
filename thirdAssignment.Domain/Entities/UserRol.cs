

using thirdAssignment.Domain.Core;

namespace thirdAssignment.Domain.Entities
{
    public class UserRol : BaseEntity
    { 
       public int UserRolId { get; set; } 
       public IList<User> users { get; set; }
    }
}
