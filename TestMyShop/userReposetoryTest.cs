using System.Reflection.Metadata;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.EntityFrameworkCore;
using Reposetories;
using System.Threading.Tasks;
using Xunit;
using System.Threading.Tasks;
using Xunit;

namespace TestMyShop
{
    public class userReposetoryTest
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
        [Fact]
        public async Task Get_UserExists_ReturnsUser()
        {
            // Arrange
            var mockContext = new Mock<_214416448WebApiContext>(); // Mock �� ��������
            var userToReturn = new User { UserId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" };

            // ���� �� �-DbSet ����� �� ������ ����� ���-id ��� 1
            mockContext.Setup(m => m.Users.FindAsync(It.IsAny<int>())).ReturnsAsync(userToReturn);

            var Reposetory = new UserReposetory(mockContext.Object);

            // Act
            var result = await Reposetory.getUserById(1); // ������ �������� �� id 1

            // Assert
            Assert.NotNull(result);  // ����� ������� �� null
            Assert.Equal(1, result.UserId); // ����� ��-id ��� 1
            Assert.Equal("John", result.FirstName); // ����� ���� ����� ��� "John"
            Assert.Equal("Doe", result.LastName); // ����� ���� ����� ��� "Doe"
            Assert.Equal("john.doe@example.com", result.Email); // ����� �����"� ����
        }
        [Fact]
        public async Task Get_UserExists_ReturnsUser1()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<_214416448WebApiContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new _214416448WebApiContext(options))
            {
                context.Users.Add(new User
                {
                    UserId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    Password = "password123"
                });
                context.SaveChanges();
            }

            using (var context = new _214416448WebApiContext(options))
            {
                var repository = new UserReposetory(context);

                // Act
                var result = await repository.getUserById(1);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(1, result.UserId);
                Assert.Equal("John", result.FirstName);
                Assert.Equal("Doe", result.LastName);
                Assert.Equal("john.doe@example.com", result.Email);
            }
        }
        [Fact]
        public async Task Get_UserDoesNotExist_ReturnsNull()
        {
            // Arrange
            var mockContext = new Mock<_214416448WebApiContext>();

            // ���� �� �-DbSet ����� null ���� �� ���� ����� �� �-id ������
            mockContext.Setup(m => m.Users.FindAsync(It.IsAny<int>())).ReturnsAsync((User)null);

            var Reposetory = new UserReposetory(mockContext.Object);

            // Act
            var result = await Reposetory.getUserById(999); // ������ �������� �� id ��� ����

            // Assert
            Assert.Null(result); // ����� ������� ��� null ����� �� id ��� ����
        }
    }
}