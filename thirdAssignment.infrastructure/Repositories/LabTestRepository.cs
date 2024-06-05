
using Microsoft.EntityFrameworkCore;
using thirdAssignment.Aplication.Interfaces.Repository;
using thirdAssignment.Domain.Entities;
using thirdAssignment.Infrastructure.Persistence.Core;

namespace thirdAssignment.Infrastructure.Persistence.Repositories
{
    public class LabTestRepository : BaseRepository<LabTest>, ILabTestRepository
    {
        private readonly Context.AppContext _appContext;

        public LabTestRepository(Context.AppContext appContext) : base(appContext)
        {
            _appContext = appContext;
        }

        public override async Task<List<LabTest>> GetAll()
        {
            return await base.GetAll();
                
                //_appContext.LabTests.
                //Include(lt => lt.ConsultingRoom).ToListAsync();
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
                if (await Exits(lt => lt.Id != id)) return null;

                return await base.GetById(id);
                    
                    //_appContext.LabTests.FirstOrDefaultAsync(u => u.Id == id);
            }
            catch (Exception ex)
            {
                throw;
            }

          
        }

        public override async Task Save(LabTest entity)
        {
            try
            {
                if (await Exits(lt => lt.Name == entity.Name)) return;

                await base.Save(entity);

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public override async Task Update(LabTest entity)
        {
            try
            {
                if (await Exits(lt => lt.Id != entity.Id)) return;

                LabTest LabTestToBeUpdated = await GetById(entity.Id);

                LabTestToBeUpdated.Name = entity.Name;

                LabTestToBeUpdated.Description = entity.Description;
                

                await base.Update(LabTestToBeUpdated);
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
                if (await Exits(lt => lt.Id != entity.Id)) return;

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
