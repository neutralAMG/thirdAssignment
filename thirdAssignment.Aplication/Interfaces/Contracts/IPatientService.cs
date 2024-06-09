
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Dtos;
using thirdAssignment.Aplication.Models;
using thirdAssignment.Domain.Entities;

namespace thirdAssignment.Aplication.Interfaces.Contracts
{
    public interface IPatientService : IBaseService< SavePatientDto, UpdatePatientDto, PatientModel, Patient>, IGetWithCunsultingRoomIdInService<PatientModel>
    {
    }
}
