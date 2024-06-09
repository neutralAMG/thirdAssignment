
using Microsoft.EntityFrameworkCore;
using thirdAssignment.Aplication.Interfaces.Repository;
using thirdAssignment.Domain.Entities;
using thirdAssignment.Infrastructure.Persistence.Core;

namespace thirdAssignment.Infrastructure.Persistence.Repositories
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        private readonly Context.AppContext _appContext;

        public AppointmentRepository(Context.AppContext appContext) : base(appContext)
        {
            _appContext = appContext;
        }


        //public override async Task<List<Appointment>> GetAll()
        //{
        //    return await base.GetAll();
        //}

        public override async Task<Appointment> GetById(Guid id)
        {
            try
            {
                if (await Exits(d => d.Id != id)) return null;

                return await _appContext.Appointments.Where(u => u.ConsultingRoomId == id).
               Include(u => u.ConsultingRoom)
               .Include(a => a.Doctor)
               .Include(a => a.Patient)
               .Include(a => a.labTestAppointments).FirstOrDefaultAsync( a => a.Id == id);
            }
            catch 
            {
                throw;
            }
           
        }        
        
      public async Task<List<Appointment>> GetAll(Guid id)
        {
            return await _appContext.Appointments.Where(u => u.ConsultingRoomId == id).
               Include(u => u.ConsultingRoom)
               .Include(a => a.Doctor)
               .Include(a => a.Patient)
               .Include(a => a.labTestAppointments).ToListAsync();
            
        }
   

        public override async Task Save(Appointment entity)
        {
            try
            {
                await base.Save(entity);

            }
            catch 
            {
                throw;
            }
           

        }

        public override async Task Update(Appointment entity)
        {
            await base.Update(entity);
        }

        public override async Task Delete(Appointment entity)
        {
            try
            {
                if (await Exits(u => u.Id != entity.Id)) return;

                Appointment AppointmentToBeDeleted = await GetById(entity.Id);

                await base.Delete(AppointmentToBeDeleted);
            }
            catch 
            {
                throw;
            }
        }

    }
}
