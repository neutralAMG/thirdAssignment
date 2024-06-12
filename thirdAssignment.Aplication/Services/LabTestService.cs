
using AutoMapper;
using Microsoft.AspNetCore.Http;
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Dtos;
using thirdAssignment.Aplication.Interfaces.Contracts;
using thirdAssignment.Aplication.Interfaces.Repository;
using thirdAssignment.Aplication.Models.LabTest;
using thirdAssignment.Aplication.Models.User;
using thirdAssignment.Aplication.Utils.ResultMessages;
using thirdAssignment.Aplication.Utils.SessionHandler;
using thirdAssignment.Domain.Entities;

namespace thirdAssignment.Aplication.Services
{
    public class LabTestService : BaseService<LabTestSaveModel,  LabTestModel, LabTest>, ILabTestService
    {
        private readonly ILabTestRepository _labTestRepository;
        private readonly IMapper _mapper;
        private readonly ResultMessages _messages;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserModel currentUser;
        public LabTestService(ILabTestRepository labTestRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(labTestRepository, mapper, new ResultMessages("Lab test"))
        {
            _labTestRepository = labTestRepository;
            _mapper = mapper;
            _messages = new("Lab test");
            _httpContextAccessor = httpContextAccessor;
            currentUser = _httpContextAccessor.HttpContext.Session.Get<UserModel>("user");
        }

        public async Task<Result<List<LabTestModel>>> GetAll()
        {
            Result<List<LabTestModel>> result = new();
            try
            {
                List<LabTest> LabTestGetted = await _labTestRepository.GetAll(currentUser.ConsultingRoom.Id);

                result.Data = _mapper.Map<List<LabTestModel>>(LabTestGetted);

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
        public override async Task<Result<LabTestSaveModel>> Save(LabTestSaveModel saveDto)
        {
            saveDto.ConsultingRoomId = currentUser.ConsultingRoom.Id;
            return await base.Save(saveDto);
        }
    }
}
