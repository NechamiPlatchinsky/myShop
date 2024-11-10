using Entities;

namespace Services
{
    public interface IUserServices
    {
        void addUser(User newUser);
        int checkPassword(string password);
        User getUserToLogin(string Email, string Password);
        void updateUser(int id, User updateUser);
    }
}