
using thirdAssignment.Aplication.Core;
using thirdAssignment.Domain.Entities;
using thirdAssignment.Aplication.Models.LabTest;
namespace thirdAssignment.Aplication.Interfaces.Contracts
{
    public interface ILabTestService : IBaseService<LabTestSaveModel, LabTestModel, LabTest>, IGetWithCunsultingRoomIdInService<LabTestModel>
    {
    }
}
