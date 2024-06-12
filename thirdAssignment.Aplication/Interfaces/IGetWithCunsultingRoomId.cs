

using thirdAssignment.Aplication.Core;

namespace thirdAssignment.Aplication.Interfaces
{
    public interface IGetWithCunsultingRoomId<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll(Guid id);
    }
    public interface IGetWithCunsultingRoomIdInService<TViewModel> where TViewModel : class
    {
        Task<Result<List<TViewModel>>> GetAll();
    }
}
