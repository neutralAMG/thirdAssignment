
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Interfaces.Contracts;
using thirdAssignment.Aplication.Models;

namespace thirdAssignment.Aplication.Services
{
    public class LabTestAppointmentService : ILabTestAppointmentService
    {

        public Task<Result<List<LabTestAppointmentModel>>> FilterByCedula(string cedulaa)
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<LabTestAppointmentModel>>> GetAll(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<LabTestAppointmentModel>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<LabTestAppointmentModel>> Save(LabTestAppointmentModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<Result<LabTestAppointmentModel>> Update(LabTestAppointmentModel entity)
        {
            throw new NotImplementedException();
        }        
        
        public Task<Result<LabTestAppointmentModel>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
