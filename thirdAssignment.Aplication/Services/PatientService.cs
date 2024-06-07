
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Interfaces.Contracts;
using thirdAssignment.Aplication.Interfaces.Repository;
using thirdAssignment.Aplication.Models;
using thirdAssignment.Domain.Entities;

namespace thirdAssignment.Aplication.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Result<List<PatientModel>>> GetAll(Guid id)
        {
            Result<List<PatientModel>> result = new();
            try
            {
                List<Patient> patientssGeted = await _patientRepository.GetAll(id);
                result.Data = patientssGeted.Select(p => new PatientModel
                {
                    Id = p.Id,
                    Name = p.Name, 
                    LastName = p.LastName,
                    Cedula = p.Cedula,
                    EMailAddress = p.EMailAddress,
                    Address = p.Address,
                    BirthDate = p.BirthDate,
                    IsSmoker = p.IsSmoker,
                    HasAllergies = p.HasAllergies,
                    ImgPath = p.ImgPath,
                    PhoneNumber = p.PhoneNumber,
                    ConsultingRoomId = p.ConsultingRoomId,

                }).ToList();
                result.Message = "Geting the Patients was a success";

                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Error geting the Patients";
                return result;
                throw;
            }
        }
          
        public async Task<Result<PatientModel>> GetById(Guid id)
        {
            Result<PatientModel> result = new();
            try
            {
                Patient PatientGeted = await _patientRepository.GetById(id);

                if (PatientGeted is null)
                {
                    result.IsSuccess = false;
                    result.Message = "Error geting the patient";
                    return result;
                }

                result.Data = new PatientModel
                {
                    Id = PatientGeted.Id,
                    Name = PatientGeted.Name,
                    LastName = PatientGeted.LastName,
                    Cedula = PatientGeted.Cedula,
                    EMailAddress = PatientGeted.EMailAddress,
                    Address = PatientGeted.Address,
                    BirthDate = PatientGeted.BirthDate,
                    IsSmoker = PatientGeted.IsSmoker,
                    HasAllergies = PatientGeted.HasAllergies,
                    ImgPath = PatientGeted.ImgPath,
                    PhoneNumber = PatientGeted.PhoneNumber,
                    ConsultingRoomId = PatientGeted.ConsultingRoomId,
                };

                result.Message = "Geting the patient was a success";
                return result;
            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                result.Message = "Error geting the patient";
                return result;
                throw;
            }
        }

        public async Task<Result<PatientModel>> Save(PatientModel entity)
        {
            Result<PatientModel> result = new();
            try
            {
                if (entity is null)
                {
                    result.IsSuccess = false;
                    result.Message = "Error saving the patient";
                    return result;
                }

                 await _patientRepository.Save(new Patient
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    LastName = entity.LastName,
                    PhoneNumber = entity.PhoneNumber,
                    BirthDate = entity.BirthDate,
                    Address = entity.Address,
                    Cedula = entity.Cedula,
                    ImgPath = entity.ImgPath,
                    IsSmoker = entity.IsSmoker,
                    HasAllergies = entity.HasAllergies,
                    EMailAddress = entity.EMailAddress,
                    ConsultingRoomId = entity.ConsultingRoomId,
                    
                });

                result.Message = "Saving the patient was a success";
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Error saving the patient";
                return result;
                throw;
            }
        }

        public async Task<Result<PatientModel>> Update(PatientModel entity)
        {
            Result<PatientModel> result = new();
            try
            {
                if (entity is null)
                {
                    result.IsSuccess = false;
                    result.Message = "Error updating  the patient";
                    return result;
                }

                await _patientRepository.Update(new Patient
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    LastName = entity.LastName,
                    PhoneNumber = entity.PhoneNumber,
                    BirthDate = entity.BirthDate,
                    Address = entity.Address,
                    Cedula = entity.Cedula,
                    ImgPath = entity.ImgPath,
                    IsSmoker = entity.IsSmoker,
                    HasAllergies = entity.HasAllergies,

                });

                result.Message = "Updating the patient was a success";
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Error updating the patient";
                return result;
                throw;
            }
        }      
        public async Task<Result<PatientModel>> Delete(Guid id)
        {
            Result<PatientModel> result = new();
            try
            {
                Patient PatientDeleted = await _patientRepository.GetById(id);

                if (PatientDeleted is null)
                {
                    result.IsSuccess = false;
                    result.Message = "Error deleting the patient";
                    return result;
                }

                await _patientRepository.Delete(PatientDeleted);


                result.Message = "Deleting the patient was a success";
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Error deleting the patient";
                return result;
                throw;
            }
        }
    
    }
}
