using Entities;

namespace Reposetories
{
    public interface IUserReposetory
    {
        Task<User> addUser(User newUser);
        Task<User> getUserToLogin(string Email, string Password);
        Task<User> updateUser(int id, User updateUser);
        Task<User> getUserById(int id);
        Task<User> ValidateUniqueEmail(string email);
    }
}