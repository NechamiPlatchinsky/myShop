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
        private readonly Mock<DbSet<User>> _mockSet;
        private readonly Mock<_214416448WebApiContext> _mockContext;
        private readonly UserReposetory _userRepository;
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
            var mockContext = new Mock<_214416448WebApiContext>(); // Mock של הקונטקסט
            var userToReturn = new User { UserId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" };

            var users = new List<User>() { userToReturn };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);
            // המוק של ה-DbSet מחזיר את המשתמש הרצוי כשה-id הוא 1
            mockContext.Setup(m => m.Users.FindAsync(It.IsAny<int>())).ReturnsAsync(userToReturn);

            var Reposetory = new UserReposetory(mockContext.Object);

            // Act
            var result = await Reposetory.getUserById(1); // קוראים לפונקציה עם id 1

            // Assert
            Assert.NotNull(result);  // תוודא שהמשתמש לא null
            Assert.Equal(1, result.UserId); // תוודא שה-id הוא 1
            Assert.Equal("John", result.FirstName); // תוודא שהשם הפרטי הוא "John"
            Assert.Equal("Doe", result.LastName); // תוודא שהשם משפחה הוא "Doe"
            Assert.Equal("john.doe@example.com", result.Email); // תוודא שהדוא"ל נכון
            }
        [Fact]
        public async Task Get_UserDoesNotExist_ReturnsNull()
        {
            // Arrange
            var mockContext = new Mock<_214416448WebApiContext>();
            var users = new List<User>();
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);
            // המוק של ה-DbSet מחזיר null כאשר לא נמצא משתמש עם ה-id המבוקש
            mockContext.Setup(m => m.Users.FindAsync(It.IsAny<int>())).ReturnsAsync((User)null);

            var Reposetory = new UserReposetory(mockContext.Object);

            // Act
            var result = await Reposetory.getUserById(999); // קוראים לפונקציה עם id שלא קיים

            // Assert
            Assert.Null(result); // תוודא שהתוצאה היא null במקרה של id שלא קיים
        }
        [Fact]
        public async Task Post_FailedToAddUser_ThrowsException()
        {
            // Arrange
            var mockContext = new Mock<_214416448WebApiContext>();
            var userToAdd = new User
            {
                UserId = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = "securepassword"
            };
            var users = new List<User>() { userToAdd };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);
            // Setup של AddAsync כך שיזרוק Exception
            mockContext.Setup(m => m.Users.AddAsync(It.IsAny<User>(), default)).ThrowsAsync(new System.Exception("Failed to add user"));

            var Reposetory = new UserReposetory(mockContext.Object);

            // Act & Assert
            await Assert.ThrowsAsync<System.Exception>(async () => await Reposetory.addUser(userToAdd)); // תוודא שהשגיאה נזרקת
        }
        [Fact]
        public async Task Put_UserDoesNotExist_ThrowsException()
        {
            // Arrange
            var mockContext = new Mock<_214416448WebApiContext>();
            var userToUpdate = new User
            {
                UserId = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = "securepassword"
            };
            var users = new List<User>() { userToUpdate};
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);
            // Setup של Update כך שהיא לא תשפיע, רק תחזיר את המשתמש החדש
            mockContext.Setup(m => m.Users.Update(It.IsAny<User>()));

            // Setup של SaveChangesAsync כך שיזרוק Exception
            mockContext.Setup(m => m.SaveChangesAsync(default)).ThrowsAsync(new System.Exception("Failed to save changes"));

            var Reposetory = new UserReposetory(mockContext.Object);

            // Act & Assert
            await Assert.ThrowsAsync<System.Exception>(async () => await Reposetory.updateUser(1, userToUpdate)); // תוודא שהשגיאה נזרקת
        }
    }
}