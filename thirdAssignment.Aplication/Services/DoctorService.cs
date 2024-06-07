
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Interfaces.Contracts;
using thirdAssignment.Aplication.Models;

namespace thirdAssignment.Aplication.Services
{
    public class DoctorService : IDoctorService
    {


        public Task<Result<List<DoctorModel>>> GetAll(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<DoctorModel>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<DoctorModel>> Save(DoctorModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<Result<DoctorModel>> Update(DoctorModel entity)
        {
            throw new NotImplementedException();
        }        
        
        public Task<Result<DoctorModel>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
