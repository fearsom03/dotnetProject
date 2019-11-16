using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Milestone_1.Abstractions;
using Milestone_1.models;
using Milestone_1.Services;
using Moq;
using Xunit;

namespace MyTest
{
    public class UnitTest1
    {
        [Fact]
        public async Task CreateUserTest()
        {
            var fakeRepository = Mock.Of<IAllRepo>();
            var movieService = new UserDataService(fakeRepository);

            var user = new User() {login="login",password="password"};
            await movieService.AddUser(user);

        }
        [Fact]
        public async Task UpdateUserTest()
        {
            var fake = Mock.Of<IAllRepo>();
            var roleService = new UserDataService(fake);

            var role = new User() { login = "update-admin" };
            await roleService.UpdateUser(role.id);

        }

        [Fact]
        public async Task DeleteUserTest()
        {
            var fake = Mock.Of<IAllRepo>();
            var roleService = new UserDataService(fake);

            var role = new User() { login = "update-admin" };
            await roleService.DeleteUser(role);

        }

        [Fact]
        public async Task DetailUserTest()
        {
            var fake = Mock.Of<IAllRepo>();
            var roleService = new UserDataService(fake);

            var role = new User() { login = "update-admin" , password = "password" };
            await roleService.DetailsUsers(role.id);
        }

        [Fact]
        public async Task GetAllUser()
        {


            var surveys = new List<User>
            {
                new User() { login="login", password="pasword" },
                new User() { login="login11",password="pasword11"}
            };

            var fake = new Mock<IAllRepo>();
            fake.Setup(x => x.GetUsers()).ReturnsAsync(surveys);


            var service = new UserDataService(fake.Object);
            var users = await service.GetUsers();


            Assert.Collection(users, user
                =>
            {
                Assert.Equal("login", user.login);
                Assert.Equal("pasword", user.password);
            },
            user =>
            {
                Assert.Equal("login11", user.login);
                Assert.Equal("pasword11", user.password);
            });


            
        }




    }
}
