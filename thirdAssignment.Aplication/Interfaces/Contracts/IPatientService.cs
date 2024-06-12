
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Models.Patient;
using thirdAssignment.Domain.Entities;

namespace thirdAssignment.Aplication.Interfaces.Contracts
{
    public interface IPatientService : IBaseService<PatienSaveModel, PatientModel, Patient>, IGetWithCunsultingRoomIdInService<PatientModel>
    {
    }
}
