using Entities;

namespace Reposetories
{
    public interface IUserReposetory
    {
        void addUser(User newUser);
        User getUserToLogin(string Email, string Password);
        void updateUser(int id, User updateUser);
    }
}