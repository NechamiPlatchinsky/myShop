using System;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;



namespace Reposetories
{
    public class UserReposetory : IUserReposetory
    {
        _214416448WebApiContext myShopDBContext;

        public UserReposetory(_214416448WebApiContext _myShopDBContext)
        {
            myShopDBContext = _myShopDBContext;
        }

        public async Task<User> addUser(User newUser)
        {

            var user =await myShopDBContext.Users.AddAsync(newUser);
            await myShopDBContext.SaveChangesAsync();
            return user;
        }
        public async Task<User> getUserToLogin(string Email, string Password)
        {
           return await myShopDBContext.Users.FirstOrDefaultAsync(user => user.Email == Email && user.Password == Password);
        }
        public async Task<User> getUserById(int id)
        {
            return await myShopDBContext.Users.FirstOrDefaultAsync(user=>user.UserId==id);
        }
        public async Task updateUser(int id, User updateUser)
        {
            updateUser.UserId = id;
            myShopDBContext.Users.Update(updateUser);
            await myShopDBContext.SaveChangesAsync();
        }
    }
}
