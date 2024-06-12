
using Microsoft.EntityFrameworkCore;
using thirdAssignment.Aplication.Interfaces.Repository;
using thirdAssignment.Domain.Entities;
using thirdAssignment.Infrastructure.Persistence.Context;
using thirdAssignment.Infrastructure.Persistence.Core;

namespace thirdAssignment.Infrastructure.Persistence.Repositories
{
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        private readonly thirdAssignmentAppContext _appContext;

        public PatientRepository(thirdAssignmentAppContext appContext) : base(appContext)
        {
            _appContext = appContext;
        }


        public  async Task<List<Patient>> GetAll(Guid id)
        {
            return await _appContext.Patients.Where(u => u.ConsultingRoomId == id).ToListAsync();
        }

        public override async Task<Patient> GetById(Guid id)
        {
            try
            {


                return await base.GetById(id);

            }
            catch 
            {
                throw;
            }
           
        }

        public override async Task<Patient> Save(Patient entity)
        {
            try
            {

                return await base.Save(entity);

            }
            catch 
            {
                throw;
            }
       

        }

        public override async Task<Patient> Update(Patient entity)
        {
            try
            {


                Patient PatientToBeUpdated = await GetById(entity.Id);


                PatientToBeUpdated.Name = entity.Name;

                PatientToBeUpdated.LastName = entity.LastName;

                PatientToBeUpdated.PhoneNumber = entity.PhoneNumber;

                PatientToBeUpdated.BirthDate = entity.BirthDate;

                PatientToBeUpdated.Address = entity.Address;

                PatientToBeUpdated.Cedula = entity.Cedula; 
                
                PatientToBeUpdated.ImgPath = entity.ImgPath;

                PatientToBeUpdated.IsSmoker = entity.IsSmoker;

                PatientToBeUpdated.HasAllergies = entity.HasAllergies;


                return await base.Update(PatientToBeUpdated);
            }
            catch 
            {
                throw;
            }
           
        }

        public override async Task Delete(Patient entity)
        {
            try
            {


                Patient PatientToBeDeleted = await GetById(entity.Id);

                await base.Delete(PatientToBeDeleted);
            }
            catch 
            {
                throw;
            }
            
        }
    }
}
