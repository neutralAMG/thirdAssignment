
using AutoMapper;
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Dtos;
using thirdAssignment.Aplication.Interfaces.Contracts;
using thirdAssignment.Aplication.Interfaces.Repository;
using thirdAssignment.Aplication.Models;
using thirdAssignment.Aplication.Utils.PasswordHasher;
using thirdAssignment.Aplication.Utils.ResultMessages;
using thirdAssignment.Domain.Entities;

namespace thirdAssignment.Aplication.Services
{
    public class UserService : BaseService<SaveUserDto, UpdateUserDto, UserModel, User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ResultMessages _messages;
        public UserService(IUserRepository userRepository, IMapper mapper, IPasswordHasher passwordHasher) : base(userRepository, mapper, new ResultMessages("User"))
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _messages = new("User");
        }

        public async Task<Result<List<UserModel>>> GetAll(Guid id)
        {
            Result<List<UserModel>> result = new();
            try
            {
                List<User> usersGetted = await _userRepository.GetAll(id);

                result.Data = _mapper.Map<List<UserModel>>(usersGetted);

                result.Message = _messages.ResultMessage[TypeOfOperation.GetAll][State.Success];

                return result;
            }
            catch 
            {
                result.IsSuccess = false;
                result.Message = _messages.ResultMessage[TypeOfOperation.GetAll][State.Error];
                return result;
                throw;
            }
        }

        public async Task<Result<UserModel>> Login(string username, string password)
        {
            Result<UserModel> result = new();
            try
            {
                string passwordHashed = _passwordHasher.hashPasword(password);

                User userGetted = await _userRepository.Login(username, passwordHashed);

                result.Data = _mapper.Map<UserModel>(userGetted);

                result.Message = _messages.ResultMessage[TypeOfOperation.GetById][State.Success];

                return result;
            }
            catch
            {
                result.IsSuccess = false;
                result.Message = _messages.ResultMessage[TypeOfOperation.GetById][State.Error];
                return result;
                throw;
            }
        }

        public async Task<Result<UserModel>> Register(SaveUserDto saveDto)
        {
            Result<UserModel> result = new();
            try
            {
                if (saveDto is null)
                {
                    result.IsSuccess = false;
                    result.Message = _messages.ResultMessage[TypeOfOperation.Save][State.Error];
                    return result;
                }

                saveDto.Password = _passwordHasher.hashPasword(saveDto.Password);

                User SavedUser = _mapper.Map<User>(saveDto);

                await _userRepository.Save(SavedUser);


                result.Message = _messages.ResultMessage[TypeOfOperation.Save][State.Success];
                return result;
            }
            catch
            {
                result.IsSuccess = false;
                result.Message = _messages.ResultMessage[TypeOfOperation.Save][State.Error];
                return result;
                throw;
            }
        }

        public override async Task<Result<UserModel>> Save(SaveUserDto saveDto)
        {
           saveDto.Password = _passwordHasher.hashPasword(saveDto.Password);
           return await base.Save(saveDto);
        }
    }
}
