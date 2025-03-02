using Entities;
using Reposetories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMyShop
{
    public class IntegrationTest:IClassFixture<DatabaseFixture>
    {
        _214416448WebApiContext _context;
        public IntegrationTest(DatabaseFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public async Task Get_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var user = new User { Email = "test1@example.com", Password = "password123",FirstName="pppp",LastName="vgfcgfc"};
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Act
            var retrievedUser = await _context.Users.FindAsync(user.UserId);

            // Assert
            Assert.NotNull(retrievedUser);
            Assert.Equal(user.Email, retrievedUser.Email);
            Assert.Equal(user.Password, retrievedUser.Password);
        }
    }
}
