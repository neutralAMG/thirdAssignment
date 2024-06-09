
using AutoMapper;
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Dtos;
using thirdAssignment.Aplication.Interfaces.Contracts;
using thirdAssignment.Aplication.Interfaces.Repository;
using thirdAssignment.Aplication.Models;
using thirdAssignment.Aplication.Utils.ResultMessages;
using thirdAssignment.Domain.Entities;

namespace thirdAssignment.Aplication.Services
{
    public class PatientService :BaseService<SavePatientDto, UpdatePatientDto, PatientModel, Patient>, IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        private readonly ResultMessages _messages;
        public PatientService(IPatientRepository patientRepository, IMapper mapper) : base(patientRepository, mapper, new ResultMessages("Patient"))
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
            _messages = new("Patient");
        }
        public async Task<Result<List<PatientModel>>> GetAll(Guid id)
        {
            Result<List<PatientModel>> result = new();
            try
            {
                List<Patient> patientsGetted = await _patientRepository.GetAll(id);

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

    }
}
