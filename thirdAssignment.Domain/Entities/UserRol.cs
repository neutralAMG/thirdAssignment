

using thirdAssignment.Domain.Core;

namespace thirdAssignment.Domain.Entities
{
    public class UserRol
    {
        public string Name { get; set; }
        public int Id {  get; set; }
        public IList<User> users { get; set; }
    }
}
