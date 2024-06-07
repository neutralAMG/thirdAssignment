
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Models;


namespace thirdAssignment.Aplication.Interfaces.Contracts
{
    public interface ILabTestAppointmentService : IBaseService<LabTestAppointmentModel>
    {
        Task<Result<List<LabTestAppointmentModel>>> FilterByCedula(string cedulaa);
    }
}
