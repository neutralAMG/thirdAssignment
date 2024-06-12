
using AutoMapper;
using Microsoft.AspNetCore.Http;
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Interfaces.Contracts;
using thirdAssignment.Aplication.Interfaces.Repository;
using thirdAssignment.Aplication.Models.User;
using thirdAssignment.Aplication.Utils.PasswordHasher;
using thirdAssignment.Aplication.Utils.ResultMessages;
using thirdAssignment.Aplication.Utils.SessionHandler;
using thirdAssignment.Domain.Entities;

namespace thirdAssignment.Aplication.Services
{
    public class UserService : BaseService<UserSaveModel, UserModel, User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ResultMessages _messages; 

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserModel currentUser;
        public UserService(IUserRepository userRepository, IMapper mapper, IPasswordHasher passwordHasher, IHttpContextAccessor httpContextAccessor) : base(userRepository, mapper, new ResultMessages("User"))
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            
            _messages = new("User");
            _httpContextAccessor = httpContextAccessor;
            currentUser = _httpContextAccessor.HttpContext.Session.Get<UserModel>("user");
        }

        public async Task<Result<List<UserModel>>> GetAll()
        {
            Result<List<UserModel>> result = new();
            try
            {
                List<User> usersGetted = await _userRepository.GetAll(currentUser.ConsultingRoom.Id);

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

                User userGetted = await _userRepository.Login(username);

                if (userGetted is null)
                {
                    result.IsSuccess = false;
                    result.Message = _messages.ResultMessage[TypeOfOperation.Save][State.Error];
                    return result;
                }

               bool verification = _passwordHasher.Verification(userGetted.Password,password);


                if (!verification)
                {
                    result.IsSuccess = false;
                    result.Message = _messages.ResultMessage[TypeOfOperation.Save][State.Error];
                    return result;
                }

                result.Data = _mapper.Map<UserModel>(userGetted);

                if (result.Data is null)
                {
                    result.IsSuccess = false;
                    result.Message = _messages.ResultMessage[TypeOfOperation.Save][State.Error];
                    return result;
                }

                result.Message = _messages.ResultMessage[TypeOfOperation.GetById][State.Success];

                _httpContextAccessor.HttpContext.Session.Set<UserModel>("user", result.Data);

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

        public async Task<Result<UserModel>> Register(UserSaveModel saveDto)
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

               bool registerResult = await _userRepository.Register(SavedUser);
                if (!registerResult)
                {
                    result.IsSuccess = false;
                  //  _messages.ResultMessage[TypeOfOperation.Save][State.Error];
                    result.Message = "User already exits" ;
                    return result;
                }

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


        public override async Task<Result<UserSaveModel>> Save(UserSaveModel saveDto)
        {
           saveDto.Password = _passwordHasher.hashPasword(saveDto.Password);
            saveDto.ConsultingRoomId = currentUser.ConsultingRoom.Id;
            saveDto.ConsultingRoomName = currentUser.ConsultingRoomName;
            return await base.Save(saveDto);

        }

		public virtual async Task<Result<UserSaveModel>> Update(UserSaveModel UpdateDto)
        {
				UpdateDto.Password = _passwordHasher.hashPasword(UpdateDto.Password);
		
            return await base.Update(UpdateDto);
        }

	}
}
