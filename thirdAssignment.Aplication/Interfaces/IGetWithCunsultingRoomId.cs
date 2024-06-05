
namespace thirdAssignment.Aplication.Interfaces
{
    public interface IGetWithCunsultingRoomId<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll(Guid id);
    }
}
