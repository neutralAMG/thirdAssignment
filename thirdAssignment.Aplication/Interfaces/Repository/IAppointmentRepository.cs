

using thirdAssignment.Aplication.Core;
using thirdAssignment.Domain.Entities;

namespace thirdAssignment.Aplication.Interfaces.Repository
{
    public interface IAppointmentRepository : IBaseRepository<Appointment>, IGetWithCunsultingRoomId<Appointment>
    {
    }
}
