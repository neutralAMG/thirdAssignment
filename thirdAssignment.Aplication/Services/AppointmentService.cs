
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
    public class AppointmentService : BaseService<SaveAppointmentsDto, UpdateAppointmentsDto, AppointmentModel, Appointment>, IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        private readonly ResultMessages _messages;
        public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper) : base(appointmentRepository, mapper, new ResultMessages("Appointment"))
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
            _messages = new("Appointmets");
        }

        public async Task<Result<List<AppointmentModel>>> GetAll(Guid id)
        {
            Result<List<AppointmentModel>> result = new();
            try
            {
                List<Appointment> appointmentGetted = await _appointmentRepository.GetAll(id);

                result.Data = _mapper.Map<List<AppointmentModel>>(appointmentGetted);

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
