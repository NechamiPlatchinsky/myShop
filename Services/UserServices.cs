using System;
using Reposetories;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Zxcvbn;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Services
{
    public class UserServices : IUserServices
    {
        IUserReposetory userReposetory ;
        public UserServices(IUserReposetory _userReposetory)
        {
            userReposetory = _userReposetory;
        }
        public async Task<User> addUser(User newUser)
        {
            int num = checkPassword(newUser.Password);
            if (num >= 2)
            {
               return await userReposetory.addUser(newUser);
            }
            else {
                return null;
            }
        }
        public async Task<User> getUserToLogin(string Email, string Password)
        {
            return await userReposetory.getUserToLogin(Email, Password);
        }
        public async Task<User> updateUser(int id, User updateUser)
        {
            int num = checkPassword(updateUser.Password);
            if (num >= 2)
            {
                return await userReposetory.updateUser(id, updateUser);
            }
            else
            {
                return null;
            }
            //userReposetory.updateUser(id, updateUser);
        }
        public int checkPassword(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }
        public async Task<User> getUserById(int id)
        {
            return await userReposetory.getUserById(id);
        }
    }
}
