using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Milestone_1.models;

namespace Milestone_1.Repository
{
   
    public interface IUserRepository
    {
        //USER
        Task<List<User>> GetUsers();

        Task<UserData> GetUser(int? userId);

        Task<int> ADDUser(User user);

        Task<int> DeleteUser(int? userId);

        Task UpdateUser(User userData);


        //USERDATA
        Task<List<UserData>> GetUserDatas();

        Task<UserData> GetUserData(int? userDataId);

        Task<int> ADDUserData(UserData userData);

        Task<int> DeleteUserData(int? uDataId);

        Task UpdateUserData(UserData userData);
    }
}
