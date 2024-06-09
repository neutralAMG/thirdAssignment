
namespace thirdAssignment.Aplication.Core
{
    public interface IBaseService< TSaveDto,TUpdateDto, TViewModel, TEntity>
        where TSaveDto : class
        where TUpdateDto : class
        where TViewModel : class
        where TEntity : class
    {
       // Task<bool> Exits(Func<TEntity, bool> filter);
      //  Task<Result<List<TEntity>>> GetAll();
    //    Task<Result<List<TViewModel>>> GetAll(Guid id);
   //     Task<Result<TViewModel>> GetById(Guid id); 
        Task<Result<TViewModel>> Save(TSaveDto saveDto);
        Task<Result<TViewModel>> Update(TUpdateDto saveDto);
        Task<Result<TViewModel>> Delete(Guid id);
      
    }
}
