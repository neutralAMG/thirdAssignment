
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Dtos;
using thirdAssignment.Aplication.Models;
using thirdAssignment.Domain.Entities;


namespace thirdAssignment.Aplication.Interfaces.Contracts
{
    public interface ILabTestAppointmentService : IBaseService< SaveLabTestAppointmentDto, UpdateLabTestDto, LabTestAppointmentModel, LabTestAppointment>, IGetWithCunsultingRoomIdInService<LabTestAppointmentModel>
    {
        Task<Result<List<LabTestAppointmentModel>>> FilterByCedula(string cedulaa);
        Task<Result<List<LabTestAppointmentModel>>> GetAllPending(Guid id);
    }
}
