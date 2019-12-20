using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Milestone_1.models;

namespace Milestone_1.Abstractions
{
    public interface IAllRepo
    {
        //getAll
        Task<List<User>> GetUsers();
        Task<List<UserData>> GetUserDatas();

        Task<List<IdentityUser>> GetIdentityUsers();

        //getByID
        Task<User> GetUserById(int? userId);
        Task<UserData> GetUserDataById(int? userDataId);
        //add
        void AddUser(User user);
        void AddUserData(UserData user);
        //delete
        void DeleteUser(User user);
        void DeleteUserData(UserData user);
        //update
        void UpdateUser(int? user);
        void UpdateUserData(UserData user);
        //detail
        Task<User> GetUserDetail(int? id);
        Task<UserData> GetUserDataDetail(int? id);
        Task Save();
    }
}
