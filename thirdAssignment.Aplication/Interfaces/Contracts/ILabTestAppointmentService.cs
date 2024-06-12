
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Dtos;
using thirdAssignment.Aplication.Models.LabTestAppointment;
using thirdAssignment.Domain.Entities;


namespace thirdAssignment.Aplication.Interfaces.Contracts
{
    public interface ILabTestAppointmentService : IBaseService<LabTestAppointmentSaveModel,  LabTestAppointmentModel, LabTestAppointment>, IGetWithCunsultingRoomIdInService<LabTestAppointmentModel>
    {
        Task<Result<List<LabTestAppointmentModel>>> FilterByCedula(string cedulaa);
        Task<Result<List<LabTestAppointmentModel>>> GetAllPending();
    }
}
