
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Dtos;
using thirdAssignment.Aplication.Models.User;
using thirdAssignment.Domain.Entities;


namespace thirdAssignment.Aplication.Interfaces.Contracts
{
    public interface IUserService : IBaseService<UserSaveModel,  UserModel, User>, IGetWithCunsultingRoomIdInService<UserModel>
    {
        Task<Result<UserModel>> Login(string username, string password);
        Task<Result<UserModel>> Register(UserSaveModel entity);
    }
}
