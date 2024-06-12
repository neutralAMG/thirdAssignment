
using Microsoft.EntityFrameworkCore;
using thirdAssignment.Aplication.Interfaces.Repository;
using thirdAssignment.Domain.Entities;
using thirdAssignment.Infrastructure.Persistence.Context;
using thirdAssignment.Infrastructure.Persistence.Core;

namespace thirdAssignment.Infrastructure.Persistence.Repositories
{
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {
        private readonly thirdAssignmentAppContext _appContext;

        public DoctorRepository(thirdAssignmentAppContext appContext) : base(appContext)
        {
            _appContext = appContext;
        }

        public async Task<List<Doctor>> GetAll(Guid id)
        {
            return await _appContext.Doctors.Where(u => u.ConsultingRoomId == id).
                 Include(u => u.ConsultingRoom).ToListAsync();
        }

        public override async Task<Doctor> GetById(Guid id)
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

        public override async Task<Doctor> Save(Doctor entity)
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

        public override async Task<Doctor> Update(Doctor entity)
        {

            try
            {


                Doctor DoctorToBeUpdated = await GetById(entity.Id);

                DoctorToBeUpdated.EMailAddress = entity.EMailAddress;

                DoctorToBeUpdated.Name = entity.Name;

                DoctorToBeUpdated.LastName = entity.LastName;

                DoctorToBeUpdated.PhoneNumber = entity.PhoneNumber;

                DoctorToBeUpdated.Cedula = entity.Cedula;

                DoctorToBeUpdated.ImgPath = entity.ImgPath;


               return await base.Update(DoctorToBeUpdated);
            }
            catch 
            {
                throw;
            }
         
        }

        public override async Task Delete(Doctor entity)
        {
            try
            {

                Doctor DoctorToBeDeleted = await GetById(entity.Id);

                await base.Delete(DoctorToBeDeleted);
            }
            catch 
            {
                throw;
            }
           
        }


    }
}
