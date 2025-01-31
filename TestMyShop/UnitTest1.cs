using System.Reflection.Metadata;
using Entities;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.EntityFrameworkCore;
using Reposetories;

namespace TestMyShop
{
    public class UnitTest1
    {
        private readonly ILogger<UserReposetory> _logger;
        [Fact]
        public async Task GetUser_ValidCredentials_ReturnUser()
        {
            //ILogger<UserReposetory> logger;
            var user = new User { Email = "111", Password = "1111" };
            var mockContext = new Mock<_214416448WebApiContext>();
            var users = new List<User>() { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);
            var userRepository = new UserReposetory(mockContext.Object);
            var result = await userRepository.getUserToLogin(user.Email, user.Password);
            Assert.Equal(user, result);
        }
    }
}