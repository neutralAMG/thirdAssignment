
using Microsoft.EntityFrameworkCore;
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



        public override async Task<List<UserRol>> GetAll()
        {
            return await base.GetAll();
        }

        public override async Task<UserRol> GetById(Guid id)
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

        public override async Task Save(UserRol entity)
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

        public override async Task Update(UserRol entity)
        {
            try
            {
                if (await Exits(u => u.Id != entity.Id)) return;

                UserRol UserRolToBeUpdated = await GetById(entity.Id);

                UserRolToBeUpdated.Name = entity.Name;

                await base.Update(UserRolToBeUpdated);

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public override async Task Delete(UserRol entity)
        {
            try
            {

                if (await Exits(u => u.Id != entity.Id)) return;

                UserRol UserRolToBeDeleted = await GetById(entity.Id);

                await base.Delete(UserRolToBeDeleted);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
