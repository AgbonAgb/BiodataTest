using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiodataTest.Models;

namespace BiodataTest.Interfaces
{
    public interface IUserRepository
    {
        User GetByUsernameAndPassword(string username, string password);
        User GetByGoogleId(string googleId);
    }
}
