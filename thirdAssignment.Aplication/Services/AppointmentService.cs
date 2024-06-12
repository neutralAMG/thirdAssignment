
using AutoMapper;
using Microsoft.AspNetCore.Http;
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Interfaces.Contracts;
using thirdAssignment.Aplication.Interfaces.Repository;
using thirdAssignment.Aplication.Models.Appointment;
using thirdAssignment.Aplication.Models.User;
using thirdAssignment.Aplication.Utils.ResultMessages;
using thirdAssignment.Aplication.Utils.SessionHandler;
using thirdAssignment.Domain.Entities;

namespace thirdAssignment.Aplication.Services
{
    public class AppointmentService : BaseService<AppointmentSaveModel, AppointmentModel, Appointment>, IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        private readonly ResultMessages _messages;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserModel currentUser;
        public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(appointmentRepository, mapper, new ResultMessages("Appointment"))
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
            _messages = new("Appointmets");
            _httpContextAccessor = httpContextAccessor;
            currentUser = _httpContextAccessor.HttpContext.Session.Get<UserModel>("user");
        }

        public async Task<Result<List<AppointmentModel>>> GetAll()
        {
            Result<List<AppointmentModel>> result = new();
            try
            {
                List<Appointment> appointmentGetted = await _appointmentRepository.GetAll(currentUser.ConsultingRoom.Id);

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

        public override async Task<Result<AppointmentSaveModel>> Save(AppointmentSaveModel saveDto)
        {
            saveDto.ConsultingRoomId = currentUser.ConsultingRoom.Id;
            return await base.Save(saveDto);
        }

        public  async Task<Result<AppointmentSaveModel>> SetToReportResult(AppointmentSaveModel saveDto)
        {
            saveDto.ConsultingRoomId = currentUser.ConsultingRoom.Id;
            saveDto.AppointmentStateId = 2;
            return await base.Update(saveDto);
        }
        public  async Task<Result<AppointmentSaveModel>> SetToReportComplete(AppointmentSaveModel saveDto)
        {
            saveDto.ConsultingRoomId = currentUser.ConsultingRoom.Id;
            saveDto.AppointmentStateId = 3;
            return await base.Update(saveDto);
        }
    }
}
