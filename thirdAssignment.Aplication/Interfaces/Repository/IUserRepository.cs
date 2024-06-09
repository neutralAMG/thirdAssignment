

using thirdAssignment.Aplication.Core;
using thirdAssignment.Domain.Entities;

namespace thirdAssignment.Aplication.Interfaces.Repository
{
    public interface IUserRepository : IBaseRepository<User>, IGetWithCunsultingRoomId<User>
    {
        Task<User> Login (string username, string password);
        Task Register(User entity);


    }
}
