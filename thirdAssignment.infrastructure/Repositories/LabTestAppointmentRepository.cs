
using Microsoft.EntityFrameworkCore;
using thirdAssignment.Aplication.Interfaces.Repository;
using thirdAssignment.Domain.Entities;
using thirdAssignment.Infrastructure.Persistence.Core;

namespace thirdAssignment.Infrastructure.Persistence.Repositories
{
    public class LabTestAppointmentRepository : BaseRepository<LabTestAppointment>, ILabTestAppointmentRepository
    {
        private readonly Context.AppContext _appContext;

        public LabTestAppointmentRepository(Context.AppContext appContext) : base(appContext)
        {
            _appContext = appContext;
        }

        public override async Task<List<LabTestAppointment>> GetAll()
        {
            return await Task.FromResult( base.GetAll().Result.Where( l => l.IsNotPending == false).ToList());
                
             //   _appContext.LabtestAppointments.
             //Include(u => u.ConsultingRoom).ToListAsync();
        }

        public override async Task<LabTestAppointment> GetById(Guid id)
        {
            try
            {
                if (await Exits(u => u.Id != id)) return null;

                return await base.GetById(id);
                    
                    //_appContext.LabtestAppointments.FirstOrDefaultAsync(u => u.Id == id);
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }

        public override async Task Save(LabTestAppointment entity)
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

        public override async Task Update(LabTestAppointment entity)
        {
            try
            {
                if (await Exits(u => u.Id != entity.Id)) return;

                LabTestAppointment LabTestAppointmentToBeUpdated = await GetById(entity.Id);

                LabTestAppointmentToBeUpdated.Name = entity.Name;

                LabTestAppointmentToBeUpdated.TestResult = entity.TestResult;

                LabTestAppointmentToBeUpdated.IsNotPending = entity.IsNotPending;

                await base.Update(LabTestAppointmentToBeUpdated);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public override async Task Delete(LabTestAppointment entity)
        {
            try
            {
                if (await Exits(u => u.Id != entity.Id)) return;

                LabTestAppointment LabTestAppointmentToBeDeleted = await GetById(entity.Id);

                await base.Delete(LabTestAppointmentToBeDeleted);
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }

        public async Task<List<LabTestAppointment>> FilteryCedula(string cedulaa)
        {
            return await _appContext.LabtestAppointments.Where(l => l.patient.Cedula ==  cedulaa || l.IsNotPending == false).ToListAsync();
        }
    }
}
