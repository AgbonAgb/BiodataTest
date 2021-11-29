using BiodataTest.AccountsModels;
using BiodataTest.Data;
using BiodataTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiodataTest.Interfaces
{
   public interface IAccounts
    {
        Task<bool> CreateUser(ApplicationUser user,string password);
        Task<bool> UpdateUser(UsersViewModels user);
        Task<bool>DeleteUser(UsersViewModels user);       
        Task<IEnumerable<RoleViewModel>> ExistRoles();
        Task<ApplicationRole> PersonalRoles(string Id);
        Task<bool> CreateRole(ApplicationRole role);
        Task<bool> AddUserRole(string userId, string role);
        Task<SignInModel> SignIn(loginModel logindetails);
        Task<IEnumerable<UsersViewModels>> AllUsers();
        Task<UsersViewModels> getUser(string Id);
        Task<bool> SignOutUser();
        //Task<bool> SignOutUser()
    }
}
