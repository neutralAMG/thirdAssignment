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
         
        //public virtual async Task<List<Tentity>> GetAll(Func<Tentity, bool> GetEntty)
        //{
        //    return await Task.FromResult(_Entities.Where(GetEntty).ToList());
        //}
        //public virtual async Task<List<Tentity>> GetAll()
        //{
        //    return await _Entities.ToListAsync();
        //}

        public virtual async Task<Tentity> GetById(Guid id)
        {
            return await _Entities.FindAsync(id);
        }

        public virtual Task Save(Tentity entity)
        {
            _Entities.AddAsync(entity);
            return  _AppContext.SaveChangesAsync();
            
        }

        public virtual Task Update(Tentity entity)
        {
            _Entities.Update(entity);
            return _AppContext.SaveChangesAsync();
        }        
        
        public virtual Task Delete(Tentity entity)
        {
            _Entities.Remove(entity);
            return _AppContext.SaveChangesAsync();
        }


    }
}
