using Entities;

namespace Services
{
    public interface IUserServices
    {
        Task<User> addUser(User newUser);
        int checkPassword(string password);
        Task<User> getUserToLogin(string Email, string Password);
        Task updateUser(int id, User updateUser);
        Task<User> getUserById(int id);
    }
}