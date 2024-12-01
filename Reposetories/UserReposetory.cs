using System;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;



namespace Reposetories
{
    public class UserReposetory : IUserReposetory
    {
        _214416448WebApiContext myShopDBContext;

        public UserReposetory(_214416448WebApiContext _myShopDBContext)
        {
            myShopDBContext = _myShopDBContext;
        }

        public async Task addUser(User newUser)
        {

            await myShopDBContext.Users.AddAsync(newUser);
            await myShopDBContext.SaveChangesAsync();
        }
        public async Task<User> getUserToLogin(string Email, string Password)
        {
            //using (StreamReader reader = System.IO.File.OpenText("M:/web api/myShop/myShop/FileUser.txt"))
            //{//

            //    string? currentUserInFile;
            //    while ((currentUserInFile = reader.ReadLine()) != null)
            //    {
            //        User user = JsonSerializer.Deserialize<User>(currentUserInFile);
            //        if (user.Email == Email && user.Password == Password)
            //            return user;
            //    }
            //}
            //return null;
            //return await myShopDBContext.Users.FirstOrDefaultAsync(user => user.Email == Email && user.Password == Password);


           return await myShopDBContext.Users.FirstOrDefaultAsync(user => user.Email == Email && user.Password == Password);
            
            //return user;
        }

        public async Task updateUser(int id, User updateUser)
        {
            updateUser.UserId = id;
            //string textToReplace = string.Empty;
            //using (StreamReader reader = System.IO.File.OpenText("M:/web api/myShop/myShop/FileUser.txt"))
            //{
            //    string currentUserInFile;
            //    while ((currentUserInFile = reader.ReadLine()) != null)
            //    {

            //        User user = JsonSerializer.Deserialize<User>(currentUserInFile);
            //        if (user.UserId == id)
            //            textToReplace = currentUserInFile;
            //    }
            //}

            //if (textToReplace != string.Empty)
            //{
            //    string text = System.IO.File.ReadAllText("M:/web api/myShop/myShop/FileUser.txt");
            //    text = text.Replace(textToReplace, JsonSerializer.Serialize(updateUser));
            //    System.IO.File.WriteAllText("M:/web api/myShop/myShop/FileUser.txt", text);
            //}
            myShopDBContext.Users.Update(updateUser);
            await myShopDBContext.SaveChangesAsync();
            //return updateUser;
        }
    }
}
