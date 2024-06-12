
namespace thirdAssignment.Aplication.Core
{
    public interface IBaseService< TSaveDto, TViewModel, TEntity>
        where TSaveDto : class
        where TViewModel : class
        where TEntity : class
    {
       // Task<bool> Exits(Func<TEntity, bool> filter);
      //  Task<Result<List<TEntity>>> GetAll();
    //    Task<Result<List<TViewModel>>> GetAll(Guid id);
        Task<Result<TViewModel>> GetById(Guid id); 
        Task<Result<TSaveDto>> Save(TSaveDto saveDto);
        Task<Result<TSaveDto>> Update(TSaveDto saveDto);
        Task<Result<TViewModel>> Delete(Guid id);
      
    }
}
