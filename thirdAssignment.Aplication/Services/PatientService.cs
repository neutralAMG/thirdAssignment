
using AutoMapper;
using Microsoft.AspNetCore.Http;
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Dtos;
using thirdAssignment.Aplication.Interfaces.Contracts;
using thirdAssignment.Aplication.Interfaces.Repository;
using thirdAssignment.Aplication.Models.Patient;
using thirdAssignment.Aplication.Models.User;
using thirdAssignment.Aplication.Utils.ResultMessages;
using thirdAssignment.Aplication.Utils.SessionHandler;
using thirdAssignment.Domain.Entities;

namespace thirdAssignment.Aplication.Services
{
    public class PatientService :BaseService<PatienSaveModel, PatientModel, Patient>, IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        private readonly ResultMessages _messages;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserModel currentUser;
        public PatientService(IPatientRepository patientRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(patientRepository, mapper, new ResultMessages("Patient"))
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
            _messages = new("Patient");
            _httpContextAccessor = httpContextAccessor;
            currentUser = _httpContextAccessor.HttpContext.Session.Get<UserModel>("user");
        }
        public async Task<Result<List<PatientModel>>> GetAll()
        {
            Result<List<PatientModel>> result = new();
            try
            {
                List<Patient> patientsGetted = await _patientRepository.GetAll(currentUser.ConsultingRoom.Id);

                result.Data = _mapper.Map<List<PatientModel>>(patientsGetted);

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
        public override async Task<Result<PatienSaveModel>> Save(PatienSaveModel saveDto)
        {
            saveDto.ConsultingRoomId = currentUser.ConsultingRoom.Id;
             return await base.Save(saveDto);
        }

    }
}
