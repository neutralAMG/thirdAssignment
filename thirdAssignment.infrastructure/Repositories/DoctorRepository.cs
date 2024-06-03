
using thirdAssignment.Aplication.Interfaces.Repository;
using thirdAssignment.Domain.Entities;
using thirdAssignment.Infrastructure.Persistence.Core;

namespace thirdAssignment.Infrastructure.Persistence.Repositories
{
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {
        private readonly Context.AppContext _appContext;

        public DoctorRepository(Context.AppContext appContext) : base(appContext)
        {
            _appContext = appContext;
        }

        public override async Task<bool> Exits(Func<Doctor, bool> filter)
        {
            return await base.Exits(filter);
        }

        public override async Task<List<Doctor>> GetAll()
        {
            return await base.GetAll();
        }

        public override async Task<Doctor> GetById(Guid id)
        {
            return await base.GetById(id);
        }

        public override Task Save(Doctor entity)
        {
            return base.Save(entity);

        }

        public override Task Update(Doctor entity)
        {
            return base.Update(entity);
        }

        public override Task Delete(Doctor entity)
        {
            return base.Delete(entity);
        }
    }
}
