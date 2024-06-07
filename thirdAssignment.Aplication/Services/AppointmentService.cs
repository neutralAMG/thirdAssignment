
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Interfaces.Contracts;
using thirdAssignment.Aplication.Models;

namespace thirdAssignment.Aplication.Services
{
    public class AppointmentService : IAppointmentService
    {

        public Task<Result<List<AppointmentModel>>> GetAll(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<AppointmentModel>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<AppointmentModel>> Save(AppointmentModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<Result<AppointmentModel>> Update(AppointmentModel entity)
        {
            throw new NotImplementedException();
        }        
        public Task<Result<AppointmentModel>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
