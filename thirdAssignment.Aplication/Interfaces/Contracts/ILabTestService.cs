

using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Models;
using thirdAssignment.Aplication.Dtos;
using thirdAssignment.Domain.Entities;
namespace thirdAssignment.Aplication.Interfaces.Contracts
{
    public interface ILabTestService : IBaseService< SaveLabTestDto, UpdateLabTestDto, LabTestModel, LabTest>, IGetWithCunsultingRoomIdInService<LabTestModel>
    {
    }
}
