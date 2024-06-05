

using thirdAssignment.Domain.Core;

namespace thirdAssignment.Domain.Entities
{
    public class UserRol : BaseEntity
    { 
      
       public IList<User> users { get; set; }
    }
}
