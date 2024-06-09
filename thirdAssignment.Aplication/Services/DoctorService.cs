
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
    public class DoctorService : BaseService<SaveDoctorDto, UpdateDoctorDto, DoctorModel, Doctor>, IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        private readonly ResultMessages _messages;
        public DoctorService(IDoctorRepository doctorRepository, IMapper mapper) : base(doctorRepository, mapper, new ResultMessages("Doctor"))
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
            _messages = new("Doctor");
        }

        public async Task<Result<List<DoctorModel>>> GetAll(Guid id)
        {
            Result<List<DoctorModel>> result = new();
            try
            {
                List<Doctor> doctorsGetted = await _doctorRepository.GetAll(id);

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


    }
}
