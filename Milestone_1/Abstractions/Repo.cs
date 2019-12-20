using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Milestone_1.Areas.Identity.Data;
using Milestone_1.Data;
using Milestone_1.models;

namespace Milestone_1.Abstractions
{
    public class Repo : IAllRepo
    {
        readonly Milestone_1IdentityDbContext _context;

        public Repo(Milestone_1IdentityDbContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Add(user);
        }

        public void AddUserData(UserData user)
        {
            _context.Add(user);
        }

        public void DeleteUser(User userId)
        {
            _context.Remove(userId);
        }

        public void DeleteUserData(UserData userDataId)
        {
            _context.Remove(userDataId);
        }

        
        public Task<User> GetUserById(int? userId)
        {
            return _context.users.FirstOrDefaultAsync(m => m.id == userId);
        }

        public Task<UserData> GetUserDataById(int? userDataId)
        {
            return _context.userDatas.FirstOrDefaultAsync(m => m.UserDataId == userDataId);
        }

        public Task<UserData> GetUserDataDetail(int? id)
        {
            return _context.userDatas.FirstOrDefaultAsync(m => m.UserDataId == id);
        }

        public Task<List<UserData>> GetUserDatas()
        {
            return _context.userDatas.ToListAsync();
        }


        public Task<User> GetUserDetail(int? id)
        {
            return _context.users.FirstOrDefaultAsync(m => m.id == id);
        }

        public Task<List<User>> GetUsers()
        {
            return _context.users.ToListAsync();
        }

        public Task<List<IdentityUser>> GetIdentityUsers()
        {
            return  _context.Users.ToListAsync();
        }


        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public void UpdateUser(int? id)
        {
            _context.Update(id);
        }

        public void UpdateUserData(UserData user)
        {
            _context.Update(user);

        }
    }
}
