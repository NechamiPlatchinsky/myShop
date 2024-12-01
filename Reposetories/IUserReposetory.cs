using Entities;

namespace Reposetories
{
    public interface IUserReposetory
    {
        Task addUser(User newUser);
        Task<User> getUserToLogin(string Email, string Password);
        Task updateUser(int id, User updateUser);
    }
}