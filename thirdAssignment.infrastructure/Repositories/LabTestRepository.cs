
using thirdAssignment.Aplication.Interfaces.Repository;
using thirdAssignment.Domain.Entities;
using thirdAssignment.Infrastructure.Persistence.Core;

namespace thirdAssignment.Infrastructure.Persistence.Repositories
{
    public class LabTestRepository : BaseRepository<LabTest>, ILabTestRepository
    {
        private readonly Context.AppContext _appContext;

        public LabTestRepository(Context.AppContext appContext) : base(appContext)
        {
            _appContext = appContext;
        }
        public override async Task<bool> Exits(Func<LabTest, bool> filter)
        {
            return await base.Exits(filter);
        }

        public override async Task<List<LabTest>> GetAll()
        {
            return await base.GetAll();
        }

        public override async Task<LabTest> GetById(Guid id)
        {
            return await base.GetById(id);
        }

        public override Task Save(LabTest entity)
        {
            return base.Save(entity);

        }

        public override Task Update(LabTest entity)
        {
            return base.Update(entity);
        }

        public override Task Delete(LabTest entity)
        {
            return base.Delete(entity);
        }
    }
}
