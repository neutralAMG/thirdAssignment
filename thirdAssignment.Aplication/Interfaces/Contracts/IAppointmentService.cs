
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Models.Appointment;
using thirdAssignment.Domain.Entities;

namespace thirdAssignment.Aplication.Interfaces.Contracts
{
    public  interface IAppointmentService : IBaseService<AppointmentSaveModel,  AppointmentModel, Appointment >, IGetWithCunsultingRoomIdInService<AppointmentModel>
    {

        public  Task<Result<AppointmentSaveModel>> SetToReportResult(AppointmentSaveModel saveDto);

        public   Task<Result<AppointmentSaveModel>> SetToReportComplete(AppointmentSaveModel saveDto);
    }
}
