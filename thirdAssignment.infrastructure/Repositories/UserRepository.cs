
using thirdAssignment.Aplication.Interfaces.Repository;
using thirdAssignment.Domain.Entities;
using thirdAssignment.Infrastructure.Persistence.Core;

namespace thirdAssignment.Infrastructure.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly Context.AppContext _appContext;

        public UserRepository(Context.AppContext appContext) : base(appContext)
        {
            _appContext = appContext;
        }
        public override async Task<bool> Exits(Func<User, bool> filter)
        {
            return await base.Exits(filter);
        }

        public override async Task<List<User>> GetAll()
        {
            return await base.GetAll();
        }

        public override async Task<User> GetById(Guid id)
        {
            return await base.GetById(id);
        }

        public override Task Save(User entity)
        {
            return base.Save(entity);

        }

        public override Task Update(User entity)
        {
            return base.Update(entity);
        }

        public override Task Delete(User entity)
        {
            return base.Delete(entity);
        }

    }
}
