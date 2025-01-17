﻿
using Microsoft.EntityFrameworkCore;
using thirdAssignment.Aplication.Interfaces.Repository;
using thirdAssignment.Domain.Entities;
using thirdAssignment.Infrastructure.Persistence.Context;
using thirdAssignment.Infrastructure.Persistence.Core;

namespace thirdAssignment.Infrastructure.Persistence.Repositories
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        private readonly thirdAssignmentAppContext _appContext;

        public AppointmentRepository(thirdAssignmentAppContext appContext) : base(appContext)
        {
            _appContext = appContext;
        }



        public override async Task<Appointment> GetById(Guid id)
        {
            try
            {


                return await _appContext.Appointments.
               Include(u => u.ConsultingRoom)
               .Include(a => a.Doctor)
               .Include(a => a.Patient)
               .Include(a => a.labTestAppointments).ThenInclude(l => l.LabTest)
               .Include(a => a.AppointmentState)
               .FirstOrDefaultAsync( a => a.Id == id);
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
               .Include(a => a.labTestAppointments).ThenInclude(l => l.LabTest)
                .Include(a => a.AppointmentState).ToListAsync();
            
        }
   

        public override async Task<Appointment> Save(Appointment entity)
        {
            try
            {
                entity.Name = $"Apointment for {entity.AppointmentDate} on {entity.AppointmentTime} ";
              return  await base.Save(entity);

            }
            catch 
            {
                throw;
            }
           

        }

        public override async Task<Appointment> Update(Appointment entity)
        {
            try
            {

                Appointment AppointmentToBeUpdated = await GetById(entity.Id);

                AppointmentToBeUpdated.AppointmentStateId = entity.AppointmentStateId;

               return await base.Update(AppointmentToBeUpdated);

            }
            catch
            {
                throw;
            }
            
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
