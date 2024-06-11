
using AutoMapper;
using System.Collections.Generic;
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Dtos;
using thirdAssignment.Aplication.Interfaces.Contracts;
using thirdAssignment.Aplication.Interfaces.Repository;
using thirdAssignment.Aplication.Models;
using thirdAssignment.Aplication.Utils.ResultMessages;
using thirdAssignment.Domain.Entities;

namespace thirdAssignment.Aplication.Services
{
    public class LabTestAppointmentService : BaseService<SaveLabTestAppointmentDto, UpdateLabTestAppointmentDto, LabTestAppointmentModel, LabTestAppointment>, ILabTestAppointmentService
    {
        private readonly ILabTestAppointmentRepository _testAppointmentRepository;
        private readonly IMapper _mapper;

        private readonly ResultMessages _messages;
        public LabTestAppointmentService(ILabTestAppointmentRepository labTestAppointmentRepository, IMapper mapper) : base(labTestAppointmentRepository, mapper, new ResultMessages("Lab test's"))
        {
            _testAppointmentRepository = labTestAppointmentRepository;
            _mapper = mapper;
            _messages = new("User");
        }


        public async Task<Result<List<LabTestAppointmentModel>>> GetAll(Guid id)
        {
            Result<List<LabTestAppointmentModel>> result = new();
            try
            {
                List<LabTestAppointment> LabTestGetted = await _testAppointmentRepository.GetAll(id);

                result.Data = _mapper.Map<List<LabTestAppointmentModel>>(LabTestGetted);

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


        public async Task<Result<List<LabTestAppointmentModel>>> FilterByCedula(string cedulaa)
        {
            Result<List<LabTestAppointmentModel>> result = new();
            try
            {
                List<LabTestAppointment> filteredLabTestAppoinments = await _testAppointmentRepository.FilterByCedula(cedulaa);

                result.Data = _mapper.Map<List<LabTestAppointmentModel>>(filteredLabTestAppoinments);

                result.Message = _messages.ResultMessage[TypeOfOperation.Filter][State.Success];

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

        public async Task<Result<List<LabTestAppointmentModel>>> GetAllPending(Guid id)
        {
            Result<List<LabTestAppointmentModel>> result = new();
            try
            {
                List<LabTestAppointment> LabTestGetted = await _testAppointmentRepository.GetAllPending(id);

                result.Data = _mapper.Map<List<LabTestAppointmentModel>>(LabTestGetted);

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
    }
}
