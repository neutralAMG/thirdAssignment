
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Interfaces.Contracts;
using thirdAssignment.Aplication.Models;

namespace thirdAssignment.Aplication.Services
{
    public class LabTestService : ILabTestService
    {


        public Task<Result<List<LabTestModel>>> GetAll(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<LabTestModel>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<LabTestModel>> Save(LabTestModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<Result<LabTestModel>> Update(LabTestModel entity)
        {
            throw new NotImplementedException();
        }        
        
        public Task<Result<LabTestModel>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
