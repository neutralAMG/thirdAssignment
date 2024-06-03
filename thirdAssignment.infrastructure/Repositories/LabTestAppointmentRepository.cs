
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

        public override async Task<bool> Exits(Func<LabTestAppointment, bool> filter)
        {
            return await base.Exits(filter);
        }

        public override async Task<List<LabTestAppointment>> GetAll()
        {
            return await base.GetAll();
        }

        public override async Task<LabTestAppointment> GetById(Guid id)
        {
            return await base.GetById(id);
        }

        public override Task Save(LabTestAppointment entity)
        {
            return base.Save(entity);

        }

        public override Task Update(LabTestAppointment entity)
        {
            return base.Update(entity);
        }

        public override Task Delete(LabTestAppointment entity)
        {
            return base.Delete(entity);
        }
    }
}
