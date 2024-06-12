
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Models.Doctor;
using thirdAssignment.Domain.Entities;

namespace thirdAssignment.Aplication.Interfaces.Contracts
{
    public interface IDoctorService : IBaseService<DoctorSaveModel,  DoctorModel, Doctor>, IGetWithCunsultingRoomIdInService<DoctorModel>
    {
    }
}
