
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

        public override async Task<bool> Exits(Func<ConsultingRoom, bool> filter)
        {
            return await base.Exits(filter);
        }

        public override async Task<List<ConsultingRoom>> GetAll()
        {
            return await base.GetAll();
        }

        public override async Task<ConsultingRoom> GetById(Guid id)
        {
            return await base.GetById(id);
        }

        public override Task Save(ConsultingRoom entity)
        {
            return base.Save(entity);

        }

        public override Task Update(ConsultingRoom entity)
        {
            return base.Update(entity);
        }

        public override Task Delete(ConsultingRoom entity)
        {
            return base.Delete(entity);
        }
    }
}
