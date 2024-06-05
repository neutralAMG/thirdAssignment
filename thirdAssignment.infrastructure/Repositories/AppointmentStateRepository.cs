
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


        public override async Task<List<AppointmentState>> GetAll()
        {
            return await base.GetAll();
        }

        public override async Task<AppointmentState> GetById(Guid id)
        {
            try
            {
                if (await Exits(u => u.Id != id)) return null;

                return await base.GetById(id);

                //_appContext.AppointmentState.FirstOrDefaultAsync(u => u.Id == id);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public override async Task Save(AppointmentState entity)
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

        public override async Task Update(AppointmentState entity)
        {
            try
            {
                if (await Exits(d => d.Id != entity.Id)) return;

                AppointmentState AppointmentStateToBeUpdated = await GetById(entity.Id);

                AppointmentStateToBeUpdated.Name = entity.Name;

                await base.Update(AppointmentStateToBeUpdated);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override async Task Delete(AppointmentState entity)
        {
            try
            {
                if (await Exits(u => u.Id != entity.Id)) return;

                AppointmentState AppointmentStateToBeDeleted = await GetById(entity.Id);

                await base.Delete(AppointmentStateToBeDeleted);
            }
            catch (Exception ex)
            {
                throw;
            }
       
        }
    }
}
