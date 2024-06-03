
using thirdAssignment.Aplication.Interfaces.Repository;
using thirdAssignment.Domain.Entities;
using thirdAssignment.Infrastructure.Persistence.Core;

namespace thirdAssignment.Infrastructure.Persistence.Repositories
{
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        private readonly Context.AppContext _appContext;

        public PatientRepository(Context.AppContext appContext) : base(appContext)
        {
            _appContext = appContext;
        }

        public override async Task<bool> Exits(Func<Patient, bool> filter)
        {
            return await base.Exits(filter);
        }

        public override async Task<List<Patient>> GetAll()
        {
            return await base.GetAll();
        }

        public override async Task<Patient> GetById(Guid id)
        {
            return await base.GetById(id);
        }

        public override Task Save(Patient entity)
        {
            return base.Save(entity);

        }

        public override Task Update(Patient entity)
        {
            return base.Update(entity);
        }

        public override Task Delete(Patient entity)
        {
            return base.Delete(entity);
        }
    }
}
