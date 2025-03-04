using Entities;
using NuGet.Protocol.Core.Types;
using Reposetories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using TestNyShop.Reposetories;
using Xunit;
//using Tests;

namespace TestMyShop
{
    public class IntegrationTest:IClassFixture<DataBaseFixture>
    {
        private readonly _214416448WebApiContext _context;
        private readonly UserReposetory _reposetory;

        public IntegrationTest(DataBaseFixture fixture)
        {
            _context = fixture.Context; // שימוש ב-DbContext מהפיקסצ'ר
            _reposetory = new UserReposetory(_context);
        }

        [Fact]
        public async Task Get_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var user = new User { Email = "test1@example.com", Password = "password123", FirstName = "pppp", LastName = "vgfcgfc" };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Act
            var retrievedUser = await _context.Users.FindAsync(user.UserId);

            // Assert
            Assert.NotNull(retrievedUser);
            Assert.Equal(user.Email, retrievedUser.Email);
            Assert.Equal(user.Password, retrievedUser.Password);
        }
        [Fact]
        public async Task Get_ShouldReturnNull_WhenUserDoesNotExist()
        {
            // Act
            var retrievedUser = await _reposetory.getUserById(-1); // מזהה לא קיים

            // Assert
            Assert.Null(retrievedUser);
        }
        [Fact]
        public async Task Post_ShouldAddUser_WhenUserIsValid()
        {
            // Arrange
            var user = new User { Email = "newuser@example.com", Password = "55555fFFFF@2aaaa", FirstName = "pppp", LastName = "vgfcgfc" };


            // Act
            var addedUser = await _reposetory.addUser(user);


            // Assert
            Assert.NotNull(addedUser);
            Assert.Equal(user.Email, addedUser.Email);
            Assert.True(addedUser.UserId > 0); // נניח שהמזהה יוקצה אוטומטית
        }


        [Fact]
        public async Task Login_ShouldReturnUser_WhenCredentialsAreValid()
        {
            // Arrange
            var user = new User { Email = "testuser@example.com", Password = "securepassword", FirstName = "pppp", LastName = "vgfcgfc" };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Act
            var loggedInUser = await _reposetory.getUserToLogin(user.Email, user.Password);


            // Assert
            Assert.NotNull(loggedInUser);
            Assert.Equal(user.Email, loggedInUser.Email);
        }

        [Fact]
        public async Task Login_ShouldReturnNull_WhenCredentialsAreInvalid()
        {
            // Act
            var loggedInUser = await _reposetory.getUserToLogin("unknown@example.com", "wrongpasswo");


            // Assert
            Assert.Null(loggedInUser);
        }

    }
}
