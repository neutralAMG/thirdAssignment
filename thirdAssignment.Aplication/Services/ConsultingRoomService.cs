
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Interfaces.Contracts;
using thirdAssignment.Aplication.Models;

namespace thirdAssignment.Aplication.Services
{
    public class ConsultingRoomService : IConsultingRoomService
    {


        public Task<Result<List<ConsultingRoomModel>>> GetAll(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<ConsultingRoomModel>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<ConsultingRoomModel>> Save(ConsultingRoomModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<Result<ConsultingRoomModel>> Update(ConsultingRoomModel entity)
        {
            throw new NotImplementedException();
        }        
        
        public Task<Result<ConsultingRoomModel>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
