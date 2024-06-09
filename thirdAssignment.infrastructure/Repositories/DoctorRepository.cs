
using Microsoft.EntityFrameworkCore;
using thirdAssignment.Aplication.Interfaces.Repository;
using thirdAssignment.Domain.Entities;
using thirdAssignment.Infrastructure.Persistence.Core;

namespace thirdAssignment.Infrastructure.Persistence.Repositories
{
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {
        private readonly Context.AppContext _appContext;

        public DoctorRepository(Context.AppContext appContext) : base(appContext)
        {
            _appContext = appContext;
        }


        //public override async Task<List<Doctor>> GetAll()
        //{
        //   return await base.GetAll();
                
        //        //_appContext.Doctors.
        //        //Include(u => u.ConsultingRoom).ToListAsync();
        //}
        public async Task<List<Doctor>> GetAll(Guid id)
        {
            return await _appContext.Doctors.Where(u => u.ConsultingRoomId == id).
                 Include(u => u.ConsultingRoom).ToListAsync();
        }

        public override async Task<Doctor> GetById(Guid id)
        {
            try
            {
                if (await Exits(d => d.Id != id)) return null;

                return await base.GetById(id);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public override async Task Save(Doctor entity)
        {
            try
            {
                await base.Save(entity);

            }
            catch (Exception ex)
            {
                throw;
            }
          
        }

        public override async Task Update(Doctor entity)
        {

            try
            {
                if (await Exits(d => d.Id != entity.Id)) return;

                Doctor DoctorToBeUpdated = await GetById(entity.Id);

                DoctorToBeUpdated.EMailAddress = entity.EMailAddress;

                DoctorToBeUpdated.Name = entity.Name;

                DoctorToBeUpdated.LastName = entity.LastName;

                DoctorToBeUpdated.PhoneNumber = entity.PhoneNumber;

                DoctorToBeUpdated.Cedula = entity.Cedula;

                DoctorToBeUpdated.ImgPath = entity.ImgPath;


                await base.Update(DoctorToBeUpdated);
            }
            catch (Exception ex)
            {
                throw;
            }
         
        }

        public override async Task Delete(Doctor entity)
        {
            try
            {
                if (await Exits(u => u.Id != entity.Id)) return;

                Doctor DoctorToBeDeleted = await GetById(entity.Id);

                await base.Delete(DoctorToBeDeleted);
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }


    }
}
