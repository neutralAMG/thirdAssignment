﻿
namespace thirdAssignment.Aplication.Core
{
    public interface IBaseRepository<Tentity> where Tentity : class
    {
        Task<bool> Exits(Func<Tentity, bool> filter);
        //Task<List<Tentity>> GetAll(Func<Tentity, bool> GetEntty) ;
        Task<Tentity> GetById(Guid id);
        Task<Tentity> Save(Tentity entity);  
        Task<Tentity> Update(Tentity entity);
        Task Delete(Tentity entity);

    }
}
