
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Dtos;
using thirdAssignment.Aplication.Models;
using thirdAssignment.Domain.Entities;

namespace thirdAssignment.Aplication.Interfaces.Contracts
{
    public  interface IAppointmentService : IBaseService< SaveAppointmentsDto, UpdateAppointmentsDto, AppointmentModel, Appointment >, IGetWithCunsultingRoomIdInService<AppointmentModel>
    {
    }
}
