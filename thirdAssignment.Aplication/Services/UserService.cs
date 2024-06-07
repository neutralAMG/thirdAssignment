
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Interfaces.Contracts;
using thirdAssignment.Aplication.Interfaces.Repository;
using thirdAssignment.Aplication.Models;
using thirdAssignment.Domain.Entities;

namespace thirdAssignment.Aplication.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<List<UserModel>>> GetAll(Guid id)
        {
            Result<List<UserModel>> result = new();
            try
            {
                List<User> usersGeted = await _userRepository.GetAll(id);
                result.Data = usersGeted.Select(u => new UserModel
                {
                    Name = u.Name,
                    LastName = u.LastName,
                    Id = u.Id,
                    Password = u.Password,
                    UserName = u.UserName,
                    EMailAddress = u.UserName,
                    RolId = u.RolId,
                    UserRol = new UserRolModel
                    {
                        Id = u.UserRol.Id,
                        Name = u.UserRol.Name,
                    },
                    ConsultingRoom = new ConsultingRoomModel
                    {
                        Id = u.ConsultingRoom.Id,
                        Name = u.ConsultingRoom.Name,
                    }

                }).ToList();
                result.Message = "Geting the user was a success";

                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Error geting the users";
                return result;
                throw;
            }
        }

        public async Task<Result<UserModel>> GetById(Guid id)
        {
            Result<UserModel> result = new();
            try
            {
                User UserGeted =  await _userRepository.GetById(id);

                if (UserGeted is null)
                {
                    result.IsSuccess = false;
                    result.Message = "Error geting the user";
                    return result;  
                }

                result.Data = new UserModel
                {
                    Name = UserGeted.Name,
                    LastName = UserGeted.LastName,
                    Id = UserGeted.Id,
                    Password = UserGeted.Password,
                    UserName = UserGeted.UserName,
                    EMailAddress = UserGeted.UserName,
                    RolId = UserGeted.RolId,
                    UserRol = new UserRolModel
                    {
                        Id = UserGeted.UserRol.Id,
                        Name = UserGeted.UserRol.Name,
                    },
                    ConsultingRoom = new ConsultingRoomModel
                    {
                        Id = UserGeted.ConsultingRoom.Id,
                        Name = UserGeted.ConsultingRoom.Name,
                    }
                };

                result.Message = "Geting the user was a success";
                return result;
            }
            catch (Exception ex) {

                result.IsSuccess = false;
                result.Message = "Error geting the user";
                return result;
                throw;
            }
        }

        public async Task<Result<UserModel>> Login(string username, string password)
        {
            Result<UserModel> result = new();
            try
            {
                User UserGeted = await _userRepository.Login(username, password);

                if (UserGeted is null)
                {
                    result.IsSuccess = false;
                    result.Message = "Error loging the user";
                    return result;
                }

                result.Data = new UserModel
                {
                    Name = UserGeted.Name,
                    LastName = UserGeted.LastName,
                    Id = UserGeted.Id,
                    Password = UserGeted.Password,
                    UserName = UserGeted.UserName,
                    EMailAddress = UserGeted.UserName,
                    RolId = UserGeted.RolId,
                    UserRol = new UserRolModel
                    {
                        Id = UserGeted.UserRol.Id,
                        Name = UserGeted.UserRol.Name,
                    },
                    ConsultingRoom = new ConsultingRoomModel
                    {
                        Id = UserGeted.ConsultingRoom.Id,
                        Name = UserGeted.ConsultingRoom.Name,
                    }
                };

                result.Message = "Loging the user was a success";
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Error loging the user";
                return result;
                throw;
            }
        }

        public async Task<Result<UserModel>> Save(UserModel entity)
        {
            Result<UserModel> result = new();
            try
            {
                if (entity is null)
                {
                    result.IsSuccess = false;
                    result.Message = "Error saving the user";
                    return result;
                }

               await _userRepository.Save(new User
                {
                    Name = entity.Name,
                    LastName = entity.LastName,
                    Id = entity.Id,
                    Password = entity.Password,
                    RolId = entity.RolId,
                    UserName = entity.UserName,
                    EMailAddress = entity.UserName,
                    ConsultingRoomId = entity.RolId,
                });


                result.Message = "Saving the user was a success";
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Error saving the user";
                return result;
                throw;
            }
        }

        public async Task<Result<UserModel>> Update(UserModel entity)
        {
            Result<UserModel> result = new();
            try
            {
                if (entity is null)
                {
                    result.IsSuccess = false;
                    result.Message = "Error updating the user";
                    return result;
                }

               await _userRepository.Update(new User
                {
                    Name = entity.Name,
                    LastName = entity.LastName,
                    Id = entity.Id,
                    Password = entity.Password,
                    UserName = entity.UserName,
                    EMailAddress = entity.UserName,

                });

                result.Message = "Updating the user was a success";
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Error updating the user";
                return result;
                throw;
            }
        }
        public async Task<Result<UserModel>> Delete(Guid id)
        {
            Result<UserModel> result = new();
            try
            {
                User UserDeleted = await _userRepository.GetById(id);

                if (UserDeleted is null)
                {
                    result.IsSuccess = false;
                    result.Message = "Error deleting the user";
                    return result;
                }

                await _userRepository.Delete(UserDeleted);


                result.Message = "Deleting the user was a success";
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Error deleting the user";
                return result;
                throw;
            }
        }

    }
}
