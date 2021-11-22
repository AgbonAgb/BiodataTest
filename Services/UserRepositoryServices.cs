using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiodataTest.Interfaces;
using BiodataTest.Models;
using System.Security.Cryptography;

namespace BiodataTest.Services
{
    public class UserRepositoryServices : IUserRepository
    {
        private List<User> users = new List<User>
        {
            //new User { Id = 3522, Name = "roland", Password = "K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=",
            //    FavoriteColor = "blue", Role = "Admin", GoogleId = "101517359495305583936" }

             new User { Id = 3522, Name = "Godwin", Password = "Agbwin2021",
                FavoriteColor = "blue", Role = "Admin", GoogleId = "100076999455178316197" }
        };

        public User GetByUsernameAndPassword(string username, string password)
        {
            var user = users.SingleOrDefault(u => u.Name == username &&  u.Password == password);

           /// v u.Password == password.Sha256());
            return user;
        }

        public User GetByGoogleId(string googleId)
        {
            var user = users.SingleOrDefault(u => u.GoogleId == googleId);
            return user;
        }
    }
}
