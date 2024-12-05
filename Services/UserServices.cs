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

namespace Services
{
    public class UserServices : IUserServices
    {
        IUserReposetory userReposetory ;
        public UserServices(IUserReposetory _userReposetory)
        {
            userReposetory = _userReposetory;
        }
        public void addUser(User newUser)
        {
            //check password strength
            userReposetory.addUser(newUser);
        }
        public async Task<User> getUserToLogin(string Email, string Password)
        {
            return await userReposetory.getUserToLogin(Email, Password);
        }
        public async Task updateUser(int id, User updateUser)
        {
            //check password strength
            userReposetory.updateUser(id, updateUser);
        }
        public int checkPassword(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }
    }
}
