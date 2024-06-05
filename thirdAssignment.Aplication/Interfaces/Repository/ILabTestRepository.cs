
using thirdAssignment.Aplication.Core;
using thirdAssignment.Domain.Entities;

namespace thirdAssignment.Aplication.Interfaces.Repository
{
    public interface ILabTestRepository : IBaseRepository<LabTest>, IGetWithCunsultingRoomId<LabTest>
    {
    }
}
