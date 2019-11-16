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
    public class UnitTest2
    {
        [Fact]
        public async Task CreateUserDataTest()
        {
            var fakeRepository = Mock.Of<IAllRepo>();
            var movieService = new UserDataService(fakeRepository);

            var user = new UserData() { name="kuka",surname="Altyn",birthDate=1998,city="Ala",country="USA",gender="MALE"};
            await movieService.AddUserData(user);

        }
        [Fact]
        public async Task UpdateUserDataTest()
        {
            var fake = Mock.Of<IAllRepo>();
            var roleService = new UserDataService(fake);

            var role = new UserData() { name = "update-admin" };
            await roleService.UpdateUserData(role);

        }

        [Fact]
        public async Task DeleteUserDataTest()
        {
            var fake = Mock.Of<IAllRepo>();
            var roleService = new UserDataService(fake);

            var role = new UserData() { name = "update-admin" };
            await roleService.DeleteUserData(role);

        }

        [Fact]
        public async Task DetailUserDataTest()
        {
            var fake = Mock.Of<IAllRepo>();
            var roleService = new UserDataService(fake);

            var user = new UserData() { name = "kuka", surname = "Altyn", birthDate = 1998, city = "Ala", country = "USA", gender = "MALE" };
            await roleService.DetailsUsers(user.UserDataId);
        }

        [Fact]
        public async Task GetAllUserData()
        {


            var surveys = new List<UserData>
            {
                new UserData() { name = "kuka", surname = "Altyn", birthDate = 1998, city = "Ala", country = "USA", gender = "MALE" },
                new UserData() { name = "kuka1", surname = "Altyn1", birthDate = 1999, city = "Ala", country = "USA", gender = "MALE" }
        };

            var fake = new Mock<IAllRepo>();
            fake.Setup(x => x.GetUserDatas()).ReturnsAsync(surveys);


            var service = new UserDataService(fake.Object);
            var users = await service.GetUserDatas();


            Assert.Collection(users, UserData
                =>
            {
                Assert.Equal("kuka", UserData.name);
                Assert.Equal("Altyn", UserData.surname);
                Assert.Equal(1998, UserData.birthDate);
                Assert.Equal("Ala", UserData.city);
                Assert.Equal("USA", UserData.country);
                Assert.Equal("MALE", UserData.gender);

            },
            user =>
            {
                Assert.Equal("kuka1", user.name);
                Assert.Equal("Altyn1", user.surname);
                Assert.Equal(1999, user.birthDate);
                Assert.Equal("Ala", user.city);
                Assert.Equal("USA", user.country);
                Assert.Equal("MALE", user.gender);
            });



        }
    }
}
