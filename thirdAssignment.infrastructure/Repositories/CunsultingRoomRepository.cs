
using thirdAssignment.Aplication.Interfaces.Repository;
using thirdAssignment.Domain.Entities;
using thirdAssignment.Infrastructure.Persistence.Core;

namespace thirdAssignment.Infrastructure.Persistence.Repositories
{
    public class CunsultingRoomRepository : BaseRepository<ConsultingRoom>, IConsultingRoomRepository
    {
        private readonly Context.AppContext _appContext;

        public CunsultingRoomRepository(Context.AppContext appContext) : base(appContext)
        {
            _appContext = appContext;
        }

        public override async Task<List<ConsultingRoom>> GetAll()
        {
            return await base.GetAll();
        }

        public override async Task<ConsultingRoom> GetById(Guid id)
        {
            try
            {
                if (await Exits(u => u.Id != id)) return null;

                return await base.GetById(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override async Task Save(ConsultingRoom entity)
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

        public override async Task Update(ConsultingRoom entity)
        {
            try
            {
                if (await Exits(u => u.Id != entity.Id)) return;

                ConsultingRoom ConsultingRoomToBeUpdated = await GetById(entity.Id);

                ConsultingRoomToBeUpdated.Name = entity.Name;

                await base.Update(ConsultingRoomToBeUpdated);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override async Task Delete(ConsultingRoom entity)
        {
            try
            {
                if (await Exits(u => u.Id != entity.Id)) return;

                ConsultingRoom ConsultingRoomToBeDeleted = await GetById(entity.Id);

                await base.Delete(ConsultingRoomToBeDeleted);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
