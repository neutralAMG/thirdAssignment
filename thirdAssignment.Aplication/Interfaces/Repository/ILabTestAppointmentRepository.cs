
using thirdAssignment.Aplication.Core;
using thirdAssignment.Domain.Entities;

namespace thirdAssignment.Aplication.Interfaces.Repository
{
    public interface ILabTestAppointmentRepository : IBaseRepository<LabTestAppointment>, IGetWithCunsultingRoomId<LabTestAppointment>
    {
        Task<List<LabTestAppointment>> FilterByCedula(string cedulaa);
        Task<List<LabTestAppointment>> GetAllPending(Guid id);
    }
}
