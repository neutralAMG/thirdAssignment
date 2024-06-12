
using Microsoft.EntityFrameworkCore;
using thirdAssignment.Aplication.Interfaces.Repository;
using thirdAssignment.Domain.Entities;
using thirdAssignment.Infrastructure.Persistence.Context;
using thirdAssignment.Infrastructure.Persistence.Core;

namespace thirdAssignment.Infrastructure.Persistence.Repositories
{
    public class LabTestRepository : BaseRepository<LabTest>, ILabTestRepository
    {
        private readonly thirdAssignmentAppContext _appContext;

        public LabTestRepository(thirdAssignmentAppContext appContext) : base(appContext)
        {
            _appContext = appContext;
        }

        public async Task<List<LabTest>> GetAll(Guid id)
        {
            return await _appContext.LabTests.Where(u => u.ConsultingRoomId == id).
                Include(lt => lt.ConsultingRoom).ToListAsync();
        }

        public override async Task<LabTest> GetById(Guid id)
        {
            try
            {

                return await base.GetById(id);
                    
            }
            catch (Exception ex)
            {
                throw;
            }

          
        }

        public override async Task<LabTest> Save(LabTest entity)
        {
            try
            {


              return  await base.Save(entity);

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public override async Task<LabTest> Update(LabTest entity)
        {
            try
            {


                LabTest LabTestToBeUpdated = await GetById(entity.Id);

                LabTestToBeUpdated.Name = entity.Name;

                LabTestToBeUpdated.Description = entity.Description;
                
              return await base.Update(LabTestToBeUpdated);
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }

        public override async Task Delete(LabTest entity)
        {
            try
            {

                LabTest LabTestToBeDeleted = await GetById(entity.Id);

                await base.Delete(LabTestToBeDeleted);
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }


    }
}
