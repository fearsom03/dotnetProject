using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Milestone_1.Abstractions;
using Milestone_1.models;

namespace Milestone_1.Services
{
    public class UserDataService
    {
        private readonly IAllRepo _userRepo;

        public UserDataService(IAllRepo userRepo)
        {
            _userRepo = userRepo;
        }

        //startOfUser
        public async Task<List<User>> GetUsers()
        {
            return await _userRepo.GetUsers();
        }
        public async Task<User> DetailsUsers(int? id)
        {
            return await _userRepo.GetUserDetail(id);
        }
        public async Task AddUser(User user)
        {
            _userRepo.AddUser(user);
            await _userRepo.Save();
        }
        public async Task UpdateUser(int user)
        {
            _userRepo.UpdateUser(user);
            await _userRepo.Save();
        }
        public async Task DeleteUser(User user)
        {
            _userRepo.DeleteUser(user);
            await _userRepo.Save();

        }
        //EndOfUser


        //Start UserData
        public async Task<List<UserData>> GetUserDatas()
        {
            return await _userRepo.GetUserDatas();
        }
        public async Task<UserData> DetailsUserDatas(int? id)
        {
            return await _userRepo.GetUserDataDetail(id);
        }
        public async Task AddUserData(UserData user)
        {
            _userRepo.AddUserData(user);
            await _userRepo.Save();
        }
        public async Task UpdateUserData(UserData user)
        {
            _userRepo.UpdateUserData(user);
            await _userRepo.Save();
        }
        public async Task DeleteUserData(UserData user)
        {
            _userRepo.DeleteUserData(user);
            await _userRepo.Save();
        }
        //endOfUserData






    }
}
