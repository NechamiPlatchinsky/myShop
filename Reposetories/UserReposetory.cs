﻿using System;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;



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
            return user.Entity;
        }
        public async Task<User> getUserToLogin(string Email, string Password)
        {
           var u= await myShopDBContext.Users.FirstOrDefaultAsync(user => user.Email == Email && user.Password == Password);
            return u;
        }
        public async Task<User> getUserById(int id)
        {
            User u = await myShopDBContext.Users.FirstOrDefaultAsync(user=>user.UserId==id);
            return u;
        }
        public async Task<User> updateUser(int id, User updateUser)
        {
            updateUser.UserId = id;
            myShopDBContext.Users.Update(updateUser);
            await myShopDBContext.SaveChangesAsync();
            return updateUser;
        }
        public async Task<User> ValidateUniqueEmail(string email)
        {
            User user = await myShopDBContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }
        public async Task<User> ValidateUniqueEmailOnUpdate(string email,int id)
        {
            User user = await myShopDBContext.Users.FirstOrDefaultAsync(u => u.Email == email && u.UserId !=id);
            return user;
        }
    }
}
