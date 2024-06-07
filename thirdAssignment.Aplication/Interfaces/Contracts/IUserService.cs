
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Models;


namespace thirdAssignment.Aplication.Interfaces.Contracts
{
    public interface IUserService : IBaseService<UserModel>
    {
        Task<Result<UserModel>> Login(string username, string password);
    }
}
