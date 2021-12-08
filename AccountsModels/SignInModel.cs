using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiodataTest.AccountsModels
{
    public class SignInModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        //public string Token { get; set; }
        //public string Expires { get; set; }
        public List<string> Role { get; set; }
        public bool UserExist { get; set; }
    }
}
