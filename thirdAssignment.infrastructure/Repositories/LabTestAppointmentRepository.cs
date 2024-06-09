
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

        //public override async Task<List<LabTestAppointment>> GetAll()
        //{
        //    return await Task.FromResult( base.GetAll().Result.Where( l => l.IsNotPending == false).ToList());

        //     //   _appContext.LabtestAppointments.
        //     //Include(u => u.ConsultingRoom).ToListAsync();
        //}

        public async Task<List<LabTestAppointment>> GetAll(Guid id)
        {
            return await _appContext.LabtestAppointments
                .Where(u => u.ConsultingRoomId == id)
                .Include(l => l.LabTest)
                .Include(l => l.Doctor)
                .Include(l => l.appointment)
                .ToListAsync();
        }
        public async Task<List<LabTestAppointment>> GetAllPending(Guid id)
        {
            return await _appContext.LabtestAppointments
                .Where(u => u.ConsultingRoomId == id || u.IsNotPending == false)
                .Include(l => l.LabTest)
                .Include(l => l.Doctor)
                .Include(l => l.appointment)
                .ToListAsync();
        }
        public override async Task<LabTestAppointment> GetById(Guid id)
        {
            try
            {
                if (await Exits(u => u.Id != id)) return null;

                return await _appContext.LabtestAppointments
                        .Where(u => u.ConsultingRoomId == id)
                        .Include(l => l.LabTest)
                         .Include(l => l.Doctor)
                         .Include(l => l.appointment)
                         .FirstOrDefaultAsync(l => l.Id == id);
                //  return await base.GetById(id);

                //_appContext.LabtestAppointments.FirstOrDefaultAsync(u => u.Id == id);
            }
            catch 
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
            catch 
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
            catch 
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
            catch 
            {
                throw;
            }

        }

        public async Task<List<LabTestAppointment>> FilterByCedula(string cedulaa)
        {
            return await _appContext.LabtestAppointments.Where(l => l.Patient.Cedula == cedulaa || l.IsNotPending == false)
                          .Include(l => l.LabTest)
                         .Include(l => l.Doctor)
                         .Include(l => l.appointment).ToListAsync();
        }

    }
}
