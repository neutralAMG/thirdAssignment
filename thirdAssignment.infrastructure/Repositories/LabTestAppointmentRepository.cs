
using Microsoft.EntityFrameworkCore;
using thirdAssignment.Aplication.Interfaces.Repository;
using thirdAssignment.Domain.Entities;
using thirdAssignment.Infrastructure.Persistence.Context;
using thirdAssignment.Infrastructure.Persistence.Core;

namespace thirdAssignment.Infrastructure.Persistence.Repositories
{
    public class LabTestAppointmentRepository : BaseRepository<LabTestAppointment>, ILabTestAppointmentRepository
    {
        private readonly thirdAssignmentAppContext _appContext;

        public LabTestAppointmentRepository(thirdAssignmentAppContext appContext) : base(appContext)
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
                    .Include(l => l.Appointment)
        .ThenInclude(a => a.Doctor)
    .Include(l => l.Appointment)
        .ThenInclude(a => a.Patient)
                .Include(l => l.LabTest)
                .ToListAsync();
        }
        public async Task<List<LabTestAppointment>> GetAllPending(Guid id)
        {
         var labtestAppointment =   await _appContext.LabtestAppointments
                .Where(u => u.ConsultingRoomId == id && u.IsNotPending == false)
                           .Include(l => l.Appointment)
        .ThenInclude(a => a.Doctor)
    .Include(l => l.Appointment)
        .ThenInclude(a => a.Patient)
                .Include(l => l.LabTest)
                .ToListAsync();

            return labtestAppointment;
        }
        public override async Task<LabTestAppointment> GetById(Guid id)
        {
            try
            {
       //         if (await Exits(u => u.Id != id)) return null;

                return await _appContext.LabtestAppointments
                               .Include(l => l.Appointment)
        .ThenInclude(a => a.Doctor)
    .Include(l => l.Appointment)
        .ThenInclude(a => a.Patient)
                        .Include(l => l.LabTest)
                         .FirstOrDefaultAsync(l => l.Id == id);
                //  return await base.GetById(id);

                //_appContext.LabtestAppointments.FirstOrDefaultAsync(u => u.Id == id);
            }
            catch 
            {
                throw;
            }

        }

        public override async Task<LabTestAppointment> Save(LabTestAppointment entity)
        {
            try
            {
                
                entity.Name = $" test's for the appointment {entity.AppointmetId}";
                entity.IsNotPending = false;
                entity.TestResult = "";
                entity.AppointmetId = new Guid(entity.AppointmetId.ToString().ToUpperInvariant());
                _appContext.LabtestAppointments.AddAsync(entity);
                _appContext.SaveChanges();
                return entity;

            }
            catch 
            {
                throw;
            }
        }

        public override async Task<LabTestAppointment> Update(LabTestAppointment entity)
        {
            try
            {
              //  if (await Exits(u => u.Id != entity.Id)) return;

                LabTestAppointment LabTestAppointmentToBeUpdated = await GetById(entity.Id);

                LabTestAppointmentToBeUpdated.TestResult = entity.TestResult;

                LabTestAppointmentToBeUpdated.IsNotPending = entity.IsNotPending;

               return await base.Update(LabTestAppointmentToBeUpdated);
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
             //   if (await Exits(u => u.Id != entity.Id)) return;

                LabTestAppointment LabTestAppointmentToBeDeleted = await GetById(entity.Id);

                await base.Delete(LabTestAppointmentToBeDeleted);
            }
            catch 
            {
                throw;
            }

        }

        public async Task<List<LabTestAppointment>> FilterByCedula(string cedulaa, Guid id)
        {
            return await _appContext.LabtestAppointments.Where(l => l.Appointment.Patient.Cedula == cedulaa && l.IsNotPending == false && l.ConsultingRoomId == id)
                          .Include(l => l.LabTest)
                                    .Include(l => l.Appointment)
        .ThenInclude(a => a.Doctor)
    .Include(l => l.Appointment)
        .ThenInclude(a => a.Patient)
                         .ToListAsync();
        }

    }
}
