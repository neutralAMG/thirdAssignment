
using thirdAssignment.Aplication.Interfaces.Repository;
using thirdAssignment.Domain.Entities;
using thirdAssignment.Infrastructure.Persistence.Core;

namespace thirdAssignment.Infrastructure.Persistence.Repositories
{
    public class UserRolRepository : BaseRepository<UserRol>, IUserRolRepository
    {
        private readonly Context.AppContext _appContext;

        public UserRolRepository(Context.AppContext appContext) : base(appContext)
        {
            _appContext = appContext;
        }

        public override async Task<bool> Exits(Func<UserRol, bool> filter)
        {
            return await base.Exits(filter);
        }

        public  override async Task<List<UserRol>> GetAll()
        {
            return await base.GetAll();
        }

        public override async Task<UserRol> GetById(Guid id)
        {
            return await base.GetById(id);
        }

        public override Task Save(UserRol entity)
        {
            return base.Save(entity);

        }

        public override Task Update(UserRol entity)
        {
            return base.Update(entity);
        }

        public override Task Delete(UserRol entity)
        {
          return base.Delete(entity);
        }


    }
}
