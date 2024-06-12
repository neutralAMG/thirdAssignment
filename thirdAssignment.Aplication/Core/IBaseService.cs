
namespace thirdAssignment.Aplication.Core
{
    public interface IBaseService< TSaveDto, TViewModel, TEntity>
        where TSaveDto : class
        where TViewModel : class
        where TEntity : class
    {

        Task<Result<TViewModel>> GetById(Guid id); 
        Task<Result<TSaveDto>> Save(TSaveDto saveDto);
        Task<Result<TSaveDto>> Update(TSaveDto saveDto);
        Task<Result<TViewModel>> Delete(Guid id);
      
    }
}
