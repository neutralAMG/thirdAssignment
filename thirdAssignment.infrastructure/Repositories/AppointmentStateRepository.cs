
using thirdAssignment.Aplication.Interfaces.Repository;
using thirdAssignment.Domain.Entities;
using thirdAssignment.Infrastructure.Persistence.Core;

namespace thirdAssignment.Infrastructure.Persistence.Repositories
{
    public class AppointmentStateRepository : BaseRepository<AppointmentState>, IAppointmentStateRepository
    {
        private readonly Context.AppContext _appContext;

        public AppointmentStateRepository(Context.AppContext appContext) : base(appContext)
        {
            _appContext = appContext;
        }
        public override async Task<bool> Exits(Func<AppointmentState, bool> filter)
        {
            return await base.Exits(filter);
        }

        public override async Task<List<AppointmentState>> GetAll()
        {
            return await base.GetAll();
        }

        public override async Task<AppointmentState> GetById(Guid id)
        {
            return await base.GetById(id);
        }

        public override Task Save(AppointmentState entity)
        {
            return base.Save(entity);

        }

        public override Task Update(AppointmentState entity)
        {
            return base.Update(entity);
        }

        public override Task Delete(AppointmentState entity)
        {
            return base.Delete(entity);
        }
    }
}
