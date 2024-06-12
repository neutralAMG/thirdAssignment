using Microsoft.EntityFrameworkCore;
using System.Linq;
using thirdAssignment.Aplication.Core;
using thirdAssignment.Infrastructure.Persistence.Context;

namespace thirdAssignment.Infrastructure.Persistence.Core
{
    public class BaseRepository<Tentity> : IBaseRepository<Tentity> where Tentity : class
    {
     
        private readonly thirdAssignmentAppContext _AppContext;

        private DbSet<Tentity> _Entities;
        public BaseRepository(thirdAssignmentAppContext AppContext)
        {
            _AppContext = AppContext;
            _Entities = _AppContext.Set<Tentity>();
        }
        public virtual async Task<bool> Exits(Func<Tentity, bool> filter)
        {
          return await Task.FromResult( _Entities.Any(filter));
        }
         

        public virtual async Task<Tentity> GetById(Guid id)
        {
            return await _Entities.FindAsync(id);
        }

        public virtual async Task<Tentity> Save(Tentity entity)
        {
            await _Entities.AddAsync(entity);
            await  _AppContext.SaveChangesAsync();
            return entity;
            
        }

        public virtual async Task<Tentity> Update(Tentity entity)
        {
            _AppContext.Attach(entity);
            _AppContext.Entry(entity).State = EntityState.Modified;
            await _AppContext.SaveChangesAsync();
            return entity;
        }        
        
        public virtual Task Delete(Tentity entity)
        {
            _Entities.Remove(entity);
            return _AppContext.SaveChangesAsync();
        }


    }
}
