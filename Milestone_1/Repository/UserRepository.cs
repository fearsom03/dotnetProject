using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Milestone_1.Data;
using Milestone_1.models;

namespace Milestone_1.Repository
{
    public class UserRepository :IUserRepository
    {
        TwitterContext db;

        public UserRepository(TwitterContext mcontext)
        {
            db = mcontext;
        }

        public async Task<int> ADDUser(User user)
        {
            if (db != null)
            {
                await db.users.AddAsync(user);
                await db.SaveChangesAsync();

                return user.id;
            }

            return 0;
        }

        public async Task<int> ADDUserData(UserData userData)
        {
            if (db != null)
            {
                await db.userDatas.AddAsync(userData);
                await db.SaveChangesAsync();

                return userData.UserDataId;
            }

            return 0;
        }

        public async Task<int> DeleteUser(int? userId)
        {
            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var user = await db.users.FirstOrDefaultAsync(x => x.id == userId);

                if (user != null)
                {
                    //Delete that post
                    db.users.Remove(user);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<int> DeleteUserData(int? uDataId)
        {
            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var userdata = await db.userDatas.FirstOrDefaultAsync(x => x.UserDataId == uDataId);

                if (userdata != null)
                {
                    //Delete that post
                    db.userDatas.Remove(userdata);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public Task<UserData> GetUser(int? userId)
        {
            //todo need realize
            throw new NotImplementedException();
        }

        public Task<UserData> GetUserData(int? userDataId)
        {
            //todo need realize
            throw new NotImplementedException();
        }

        public async Task<List<UserData>> GetUserDatas()
        {
            if (db != null)
            {
                return await db.userDatas.ToListAsync();
            }

            return null;
        }

        public async Task<List<User>> GetUsers()
        {
            if (db != null)
            {
                return await db.users.ToListAsync();
            }

            return null;
        }

        public async Task UpdateUser(User user)
        {
            if (db != null)
            {
                //Delete that post
                db.users.Update(user);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }

        public async Task UpdateUserData(UserData userData)
        {
            if (db != null)
            {
                //Delete that post
                db.userDatas.Update(userData);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}
