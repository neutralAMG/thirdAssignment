
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
    public class LabTestService : BaseService<SaveLabTestDto, UpdateLabTestDto, LabTestModel, LabTest>, ILabTestService
    {
        private readonly ILabTestRepository _labTestRepository;
        private readonly IMapper _mapper;
        private readonly ResultMessages _messages;
        public LabTestService(ILabTestRepository labTestRepository, IMapper mapper) : base(labTestRepository, mapper, new ResultMessages("Lab test"))
        {
            _labTestRepository = labTestRepository;         
            _mapper = mapper;
            _messages = new("Lab test");
        }

        public async Task<Result<List<LabTestModel>>> GetAll(Guid id)
        {
            Result<List<LabTestModel>> result = new();
            try
            {
                List<LabTest> LabTestGetted = await _labTestRepository.GetAll(id);

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

    }
}
