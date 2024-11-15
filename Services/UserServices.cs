﻿using System;
using Reposetories;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Zxcvbn;

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
            userReposetory.addUser(newUser);
        }
        public User getUserToLogin(string Email, string Password)
        {
            return userReposetory.getUserToLogin(Email, Password);
        }
        public void updateUser(int id, User updateUser)
        {
            userReposetory.updateUser(id, updateUser);
        }
        public int checkPassword(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }
    }
}
