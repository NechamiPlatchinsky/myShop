using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Services
{
    public interface IUserServices
    {
        Task<User> addUser(User newUser);
        int checkPassword(string password);
        Task<User> getUserToLogin(string Email, string Password);
        Task<User> updateUser(int id, User updateUser);
        Task<User> getUserById(int id);
        Task<User> ValidateUniqueEmail(string email);
    }
}