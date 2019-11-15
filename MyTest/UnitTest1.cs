using System;
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
        public async void Test1()
        {
            var fakeRepository = Mock.Of<IAllRepo>();
            var movieService = new UserDataService(fakeRepository);

            var user = new User() {login="login",password="password"};
            await movieService.AddUser(user);

        }
    }
}
