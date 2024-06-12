
using AutoMapper;
using Microsoft.AspNetCore.Http;
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Interfaces.Contracts;
using thirdAssignment.Aplication.Interfaces.Repository;
using thirdAssignment.Aplication.Models.LabTestAppointment;
using thirdAssignment.Aplication.Models.User;
using thirdAssignment.Aplication.Utils.ResultMessages;
using thirdAssignment.Aplication.Utils.SessionHandler;
using thirdAssignment.Domain.Entities;

namespace thirdAssignment.Aplication.Services
{
    public class LabTestAppointmentService : BaseService<LabTestAppointmentSaveModel,  LabTestAppointmentModel, LabTestAppointment>, ILabTestAppointmentService
    {
        private readonly ILabTestAppointmentRepository _testAppointmentRepository;
        private readonly IMapper _mapper;

        private readonly ResultMessages _messages;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserModel currentUser;
        public LabTestAppointmentService(ILabTestAppointmentRepository labTestAppointmentRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(labTestAppointmentRepository, mapper, new ResultMessages("Lab test's"))
        {
            _testAppointmentRepository = labTestAppointmentRepository;
            _mapper = mapper;
            _messages = new("User");
            _httpContextAccessor = httpContextAccessor;
            currentUser = _httpContextAccessor.HttpContext.Session.Get<UserModel>("user");
        }


        public async Task<Result<List<LabTestAppointmentModel>>> GetAll()
        {
            Result<List<LabTestAppointmentModel>> result = new();
            try
            {
                List<LabTestAppointment> LabTestGetted = await _testAppointmentRepository.GetAll(currentUser.ConsultingRoom.Id);

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
                List<LabTestAppointment> filteredLabTestAppoinments = await _testAppointmentRepository.FilterByCedula(cedulaa, currentUser.ConsultingRoom.Id);

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

        public override async Task<Result<LabTestAppointmentSaveModel>> Save(LabTestAppointmentSaveModel saveDto)
        {
            saveDto.ConsultingRoomId = currentUser.ConsultingRoom.Id;

            return await base.Save(saveDto);
        }

        public async Task<Result<List<LabTestAppointmentModel>>> GetAllPending()
        {
            Result<List<LabTestAppointmentModel>> result = new();
            try
            {
                List<LabTestAppointment> LabTestGetted = await _testAppointmentRepository.GetAllPending(currentUser.ConsultingRoom.Id);

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
