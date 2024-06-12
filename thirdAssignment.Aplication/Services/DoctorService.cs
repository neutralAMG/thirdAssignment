
using AutoMapper;
using Microsoft.AspNetCore.Http;
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Dtos;
using thirdAssignment.Aplication.Interfaces.Contracts;
using thirdAssignment.Aplication.Interfaces.Repository;
using thirdAssignment.Aplication.Models.Doctor;
using thirdAssignment.Aplication.Models.Patient;
using thirdAssignment.Aplication.Models.User;
using thirdAssignment.Aplication.Utils.ResultMessages;
using thirdAssignment.Aplication.Utils.SessionHandler;
using thirdAssignment.Domain.Entities;

namespace thirdAssignment.Aplication.Services
{
    public class DoctorService : BaseService<DoctorSaveModel, DoctorModel, Doctor>, IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        private readonly ResultMessages _messages;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserModel currentUser;
        public DoctorService(IDoctorRepository doctorRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(doctorRepository, mapper, new ResultMessages("Doctor"))
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
            _messages = new("Doctor");

            _httpContextAccessor = httpContextAccessor;
            currentUser = _httpContextAccessor.HttpContext.Session.Get<UserModel>("user");
        }

        public async Task<Result<List<DoctorModel>>> GetAll()
        {
            Result<List<DoctorModel>> result = new();
            try
            {
                List<Doctor> doctorsGetted = await _doctorRepository.GetAll(currentUser.ConsultingRoom.Id);

                result.Data = _mapper.Map<List<DoctorModel>>(doctorsGetted);

                result.Message = _messages.ResultMessage[TypeOfOperation.GetAll][State.Success];

                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = _messages.ResultMessage[TypeOfOperation.GetAll][State.Error];
                return result;
                throw;
            }
        }

        public override async Task<Result<DoctorSaveModel>> Save(DoctorSaveModel saveDto)
        {
            saveDto.ConsultingRoomId = currentUser.ConsultingRoom.Id;
            return await base.Save(saveDto);
        }


    }
}
