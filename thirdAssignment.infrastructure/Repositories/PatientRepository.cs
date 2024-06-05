
using Microsoft.EntityFrameworkCore;
using thirdAssignment.Aplication.Interfaces.Repository;
using thirdAssignment.Domain.Entities;
using thirdAssignment.Infrastructure.Persistence.Core;

namespace thirdAssignment.Infrastructure.Persistence.Repositories
{
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        private readonly Context.AppContext _appContext;

        public PatientRepository(Context.AppContext appContext) : base(appContext)
        {
            _appContext = appContext;
        }


        public override async Task<List<Patient>> GetAll()
        {
            return await _appContext.Patients.
                Include(u => u.ConsultingRoom).ToListAsync();
        }
        public  async Task<List<Patient>> GetAll(Guid id)
        {
            return await _appContext.Patients.Where(u => u.ConsultingRoomId == id).
                 Include(u => u.ConsultingRoom).ToListAsync();
        }

        public override async Task<Patient> GetById(Guid id)
        {
            try
            {
                if (await Exits(u => u.Id != id)) return null;

                return await _appContext.Patients.FirstOrDefaultAsync(u => u.Id == id);
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }

        public override async Task Save(Patient entity)
        {
            try
            {


                if (await Exits(u => u.Cedula == entity.Cedula)) return;

                if (await Exits(u => u.EMailAddress == entity.EMailAddress)) return;

                await base.Save(entity);

            }
            catch (Exception ex)
            {
                throw;
            }
       

        }

        public override async Task Update(Patient entity)
        {
            try
            {
                if (await Exits(u => u.Id != entity.Id)) return;

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


                await base.Update(PatientToBeUpdated);
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }

        public override async Task Delete(Patient entity)
        {
            try
            {
                if (await Exits(u => u.Id != entity.Id)) return;

                Patient PatientToBeDeleted = await GetById(entity.Id);

                await base.Delete(PatientToBeDeleted);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}
