﻿
using Microsoft.EntityFrameworkCore;
using thirdAssignment.Aplication.Interfaces.Repository;
using thirdAssignment.Domain.Entities;
using thirdAssignment.Infrastructure.Persistence.Context;
using thirdAssignment.Infrastructure.Persistence.Core;

namespace thirdAssignment.Infrastructure.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly thirdAssignmentAppContext _appContext;

        public UserRepository(thirdAssignmentAppContext appContext) : base(appContext)
        {
            _appContext = appContext;
        }

        public override async Task<User> GetById(Guid id)
        {
            try
            {


                return await _appContext.Users.Include(u => u.ConsultingRoom)
                    .Include(u => u.UserRol).FirstOrDefaultAsync(u => u.Id == id);
            }
            catch 
            {
                throw;
            }

        }

        public override async Task<User> Save(User entity)
        {
            try
            {
                if (await Exits(u => u.UserName == entity.UserName)) return null;

               return  await base.Save(entity);
            }
            catch 
            {
                throw;
            }


        }

        public async Task<bool> Register(User entity)
        {
            try
            {
                if (await Exits(u => u.UserName == entity.UserName)) return false;

                ConsultingRoom consultingRoom = new ConsultingRoom { Name = entity.ConsultingRoomName };

                _appContext.ConsultingRooms.Add(consultingRoom);

                await _appContext.SaveChangesAsync();

                entity.ConsultingRoomId = consultingRoom.Id;

                await base.Save(entity);

                await _appContext.SaveChangesAsync();

                return true;
            }
            catch 
            {
                throw;
            }


        }

        public override async Task<User> Update(User entity)
        {

            try
            {


                User UserToBeUpdated = await GetById(entity.Id);

                UserToBeUpdated.EMailAddress = entity.EMailAddress;

                UserToBeUpdated.Name = entity.Name;

                UserToBeUpdated.LastName = entity.LastName;

                UserToBeUpdated.Password = entity.Password is null ? UserToBeUpdated.Password : entity.Password;

                UserToBeUpdated.UserName = entity.UserName;

                return await base.Update(UserToBeUpdated);
            }
            catch 
            {
                throw;
            }

        }

        public override async Task Delete(User entity)
        {
            try
            {

                User UserToBeDeleted = await GetById(entity.Id);

                await base.Delete(UserToBeDeleted);
            }
            catch 
            {
                throw;
            }

        }

        public async Task<User> Login(string username)
        {
            try
            {

                return await _appContext.Users.Include(u => u.ConsultingRoom)
                    .Include(u => u.UserRol)
                    .Where(u => u.UserName == username)
                    .FirstOrDefaultAsync();

            }
            catch 
            {
                throw;
            }


        }

        public async Task<List<User>> GetAll(Guid id)
        {
            return await _appContext.Users.Where(u => u.ConsultingRoomId == id)
                .Include(u => u.ConsultingRoom).Include(u => u.UserRol).ToListAsync();
        }
    }
}
