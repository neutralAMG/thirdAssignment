
using thirdAssignment.Aplication.Core;
using thirdAssignment.Domain.Entities;

namespace thirdAssignment.Aplication.Interfaces.Repository
{
    public interface ILabTestAppointmentRepository : IBaseRepository<LabTestAppointment>
    {
        Task<List<LabTestAppointment>> FilteryCedula(string cedulaa);
    }
}
