using System;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace Reposetories
{
    public class UserReposetory : IUserReposetory
    {
        public void addUser(User newUser)
        {
            int numberOfUsers = System.IO.File.ReadLines("M:/web api/myShop/myShop/FileUser.txt").Count();
            newUser.UserId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(newUser);
            System.IO.File.AppendAllText("M:/web api/myShop/myShop/FileUser.txt", userJson + Environment.NewLine);
        }
        public User getUserToLogin(string Email, string Password)
        {
            using (StreamReader reader = System.IO.File.OpenText("M:/web api/myShop/myShop/FileUser.txt"))
            {

                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Email == Email && user.Password == Password)
                        return user;
                }
            }
            return null;
        }
        public void updateUser(int id, User updateUser)
        {
            updateUser.UserId = id;
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText("M:/web api/myShop/myShop/FileUser.txt"))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserId == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText("M:/web api/myShop/myShop/FileUser.txt");
                text = text.Replace(textToReplace, JsonSerializer.Serialize(updateUser));
                System.IO.File.WriteAllText("M:/web api/myShop/myShop/FileUser.txt", text);
            }
        }
    }
}
