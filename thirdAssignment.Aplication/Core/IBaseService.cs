
namespace thirdAssignment.Aplication.Core
{
    public interface IBaseService<TEntity> where TEntity : class
    {
       // Task<bool> Exits(Func<TEntity, bool> filter);
      //  Task<Result<List<TEntity>>> GetAll();
        Task<Result<List<TEntity>>> GetAll(Guid id);
        Task<Result<TEntity>> GetById(Guid id);
        Task<Result<TEntity>> Save(TEntity entity);
        Task<Result<TEntity>> Update(TEntity entity);
        Task<Result<TEntity>> Delete(Guid id);
    }
}
