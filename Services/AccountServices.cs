using BiodataTest.AccountsModels;
using BiodataTest.Data;
using BiodataTest.Interfaces;
using BiodataTest.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiodataTest.Services
{
    public class AccountServices : IAccounts
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        //Add SignInmanager for Token/authentication
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountServices(AppDbContext appDbContext, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,SignInManager<ApplicationUser> signInManager)
        {
            _appDbContext = appDbContext;
                 _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;


        }
        public async Task<bool> RemoveUserRole(string userId, string role)
        {
            bool suc = false;
            try
            {
                //Find user
                //var user = await _userManager.FindByIdAsync(userId);
                var user = await _userManager.FindByIdAsync(userId);//find create snapshop of that user
                if (user != null)
                {
                    await _userManager.RemoveFromRoleAsync(user, role);
                    suc = true;
                   // return suc;
                }

               
            }
            catch (Exception ex)
            {
                return false;

            }

            return suc;

        }
        public async Task<bool> AddUserRole(string userId, string role)
        {
            bool suc = false;
            try
            {
                //Find user
                //var user = await _userManager.FindByIdAsync(userId);
                var user = await _userManager.FindByIdAsync(userId);//find create snapshop of that user
                if (user == null)
                {
                    return suc;
                }

                var roleExist = await _roleManager.RoleExistsAsync(role);
                //var roleExist = await _roleManager.FindByIdAsync(role);
                if (!roleExist)
                {
                    return suc;
                }
                //does user already in the role

                var userinRole = await _userManager.IsInRoleAsync(user, role);
                if (userinRole)
                {
                    return suc;
                }
                //Add user to role

                var addroleresult = await _userManager.AddToRoleAsync(user, role);
                if (addroleresult.Succeeded)
                {
                    suc = true;

                }
                else
                {
                    return suc;
                }
            }
            catch (Exception ex)
            {
                return false;

            }

            return suc;

        }

        public async Task<IEnumerable<UsersViewModels>> AllUsers()
        {
            // var users = await _userManager.Users;

            


            var users = await _userManager.Users.Select(s => new UsersViewModels
            {

                Email = s.Email,
                UserName = s.UserName,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Id = s.Id


            }).ToListAsync();//.FirstOrDefaultAsync();//.ToListAsync();

            //map UsersViewModels

            List<UsersViewModels> urols = new List<UsersViewModels>();

            var userRoleIds = _appDbContext.Roles.Select(r => r.Id);
            var roleks = _appDbContext.Roles.Where(r => userRoleIds.Contains(r.Id));
            //Array rolesssk = new Array();

            List<string> list2 = new List<string>();

            foreach(var rok in roleks)
            {

                list2.Add(rok.Name);
            }

            //list.Add(2);
            //list.Add(3);


            var roles = new List<string>();


            List<ApplicationUser> list3 = new List<ApplicationUser>();
            foreach (var user in _userManager.Users)
            {
                list3.AddRange(new List<ApplicationUser>
            {
                 new ApplicationUser {UserName = user.UserName, Email = user.Email, Id=user.Id, FirstName=user.FirstName,LastName=user.LastName},
                 //new ApplicationUser {Name = "Bhanu", Email = "bhanu@gmail.com" }
             });
            }

            //list3 = _userManager.Users;
            //foreach (var user in users)
            foreach (var user in list3)
            {
                string str = "";

                foreach(string item in list2)
                { // Loop through List with foreach
                    if (await _userManager.IsInRoleAsync(user, item))
                    {

                        //foreach (var role in roless)
                        //{
                            str = (str == "") ? item.ToString() : str + " ; " + item.ToString();
                        //}
                    }
                }
               
               

                urols.Add(new UsersViewModels {Email= user.Email, UserName= user.UserName, FirstName= user.FirstName, LastName= user.LastName, Id= user.Id, RoleName= str });

            }


            //List<Student> studentList = new List<Student>();

            //studentList.AddRange(new List<Student>
            //{
            //     new Student { Name = "Vikram", Email = "vikram@gmail.com" },
            //     new Student {Name = "Bhanu", Email = "bhanu@gmail.com" }
            // });





            //var model = new ListUserViewModel()
            //{
            //    users = users.ToList(),
            //    roles = roles.ToList()
            //};
            //return View(model);

            return urols;

            ////var users = await _userManager.Users.Select(s => new UsersViewModels
            ////{

            ////    Email = s.Email,
            ////    UserName = s.UserName,
            ////    FirstName = s.FirstName,
            ////    LastName = s.LastName,
            ////    Id = s.Id


            ////}).ToListAsync();//.FirstOrDefaultAsync();//.ToListAsync();




            //    var users = await _userManager.Users.Include(ur => ur.Role).ToListAsync();

            //var userList = await (from user in _userManager.Users
            //                      select new UsersViewModels
            //                      {
            //                          Email = user.Email,
            //                          UserName = user.UserName,
            //                          FirstName = user.FirstName,
            //                          LastName = user.LastName,
            //                          Id = user.Id,
            //                          RoleName = (from userRole in _roleManager.Roles                                                  
            //                                      on user.Id
            //                                      equals userRole.Id
            //                                      select userRole.Name).ToList()
            //                      }).ToListAsync();


            //var UsersViewModels = userList.Select(p => new UsersViewModels
            //{
            //    Email = p.Email,
            //    UserName = p.UserName,
            //    FirstName = p.FirstName,
            //    LastName = p.LastName,
            //    Id = p.Id,
            //    RoleName = string.Join(",", p.RoleNames),

            //});

            //return UsersViewModels;


            // return users;
            ///

            // var users = string.Empty;
            //string y = null;
            //var users = y;

            ////try
            ////{
            ////    var users = await _userManager.Users
            ////           .Join(_roleManager.Roles,
            ////            umanager => umanager.Id,
            ////            dermanager => dermanager.Id,
            ////             (umanager, dermanager) => new UsersViewModels
            ////             {
            ////                 Email = umanager.Email,
            ////                 UserName = umanager.UserName,
            ////                 FirstName = umanager.FirstName,
            ////                 LastName = umanager.LastName,
            ////                 Id = umanager.Id,
            ////                 RoleName = dermanager.Name
            ////             }).FirstOrDefault();//.ToListAsync();


            ////    return users;
            ////}
            ////catch (Exception ex)
            ////{

            ////    throw;
            ////}


        }

    public async Task<bool> CreateRole(ApplicationRole role)
        {
            try
            {
                //Inject identity role
                //Checking if role exist
                var roleCheck = await _roleManager.RoleExistsAsync(role.Name);
                if (!roleCheck)
                {
                    //Creating Role
                    var roleResult = await _roleManager.CreateAsync(role);

                    if (roleResult.Succeeded)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public async Task<string> CreateUser(ApplicationUser user, string password)
        {
            string userid = "";
            

            try
            {
               
                //Inject identity role
                //Checking if role exist
                var userCheck = await _userManager.FindByEmailAsync(user.Email);
                if (userCheck == null)
                {
                    user.Id = Guid.NewGuid().ToString();
                    
                    //Creating user
                    var userResult = await _userManager.CreateAsync(user, password);

                    if (userResult.Succeeded)
                    {
                        userid = user.Id;
                        //i will try to create role when successful
                        return userid;
                    }
                }

                return userid;
            }
            catch (Exception ex)
            {
                return userid;

            }
        }

        public async Task<bool> DeleteUser(UsersViewModels users)
        {
            bool succ = false;

            var user = await _userManager.FindByIdAsync(users.Id);

            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    succ = true;
                }
                else
                {
                    succ = false;
                }
            }
            else
            {
                //ModelState.AddModelError("", "This user can't be found");
                succ = false;
            }
            return succ;
        }

        public async Task<UsersViewModels> getUser(string Id)
        {
            ////UsersViewModels UVm = new UsersViewModels();

            //////set focus to the user by finding
            ////var user = await _userManager.FindByIdAsync(Id);
            ////if (user == null)
            ////{
            ////    UVm = user;

            ////}

            ////////var editeduser= user..Select(s => new UsersViewModels
            ////////{

            ////////    Email = s.Email,
            ////////    UserName = s.UserName,
            ////////    FirstName = s.FirstName,
            ////////    LastName = s.LastName,
            ////////    Id = s.Id
            ////////}).FirstOrDefaultAsync();

            var user = await _userManager.Users.Where(k => k.Id == Id).Select(s => new UsersViewModels
            {

                Email = s.Email,
                UserName = s.UserName,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Id = s.Id
            }).FirstOrDefaultAsync();//.ToListAsync();

            return user;
        }

        public async Task<SignInModel> SignIn(loginModel logindetails)
        {
            SignInModel signInDetails = new SignInModel();
            try
            {

            //Alternative Approch

           // isPersistent: false
                //Check if user exist
                var user = await _userManager.FindByEmailAsync(logindetails.Email);
                //get the user roll
                var userRole = await _userManager.GetRolesAsync(user);
                //Check value
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, logindetails.password, false, false);
                    //Check id signin is successful
                    if (result.Succeeded)
                    {
                        signInDetails.FirstName = user.FirstName;
                        signInDetails.LastName = user.LastName;
                        signInDetails.FullName = user.FullName;
                        signInDetails.Email = user.Email;
                        //signInDetails.Expires = tokenDescriptor.Expires.ToString();
                        //signInDetails.Token = tokenHandler.WriteToken(token);
                        signInDetails.Role = userRole.ToList();//.FirstOrDefault();


                        ////var tokenHandler = new JwtSecurityTokenHandler();
                        //////Get the secrete key from appsettings class
                        ////var key = Encoding.ASCII.GetBytes(_appSettings.Secrete.ToString());
                        //////Describe token and its contents
                        ////var tokenDescriptor = new SecurityTokenDescriptor
                        ////{
                        ////    Subject = new ClaimsIdentity(new Claim[]
                        ////{
                        ////    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        ////    new Claim(ClaimTypes.Name, user.UserName),
                        ////    new Claim(ClaimTypes.GivenName, user.FullName),
                        ////    //this returns the role for activities
                        ////   new Claim(ClaimTypes.Role, userRole.First())
                        ////}),
                        ////    Expires = DateTime.UtcNow.AddHours(5),
                        ////    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                        ////};
                        ////var token = tokenHandler.CreateToken(tokenDescriptor);

                        //Assign Value to signin Model instead of automapper

                        signInDetails.UserExist = true;
                        return signInDetails;

                    }
                    else
                    {
                        return signInDetails;
                    }

                }
                else
                {
                    signInDetails.UserExist = false;
                    return signInDetails;
                }
               
            }
            catch (Exception ex)
            {
                return signInDetails;
            }

        }

        public async Task<bool> UpdateUser(UsersViewModels user)
        {
            bool succ = false;
            //create snapshot
            var usersdetails = await _userManager.FindByIdAsync(user.Id);

            if (usersdetails != null)
            {
                usersdetails.Email = user.Email;
                usersdetails.UserName = user.UserName;
                usersdetails.FirstName = user.FirstName;
                usersdetails.LastName = user.LastName;



                var result = await _userManager.UpdateAsync(usersdetails);

                if (result.Succeeded)
                {
                    succ = true;
                }
                else
                {
                    succ = false;
                }                   

            }

            //return RedirectToAction("UserManagement", _userManager.Users);

            return succ;
        }
        public async Task<bool> SignOutUser()
        {
            bool succ = false;
            //create snapshot
             await _signInManager.SignOutAsync();

            //return RedirectToAction("UserManagement", _userManager.Users);

            return succ;
        }

        public async Task<IEnumerable<RoleViewModel>> ExistRoles()
        {
            // ApplicationRole role = new ApplicationRole();

            // var roles = roleManager.Roles.ToList();
            //var  role = await _roleManager.Roles.ToListAsync();

            // var role = await _roleManager.Roles.OrderBy(s => s.Name).ToListAsync();


            var role = await _roleManager.Roles.Select(s => new RoleViewModel
            {
                Id = s.Id,
                Name = s.Name

            }).ToListAsync();//.FirstOrDefaultAsync();//.ToListAsync();

            return role;
        }

        public Task<ApplicationRole> PersonalRoles(string Id)
        {
            throw new NotImplementedException();
        }
    }
}
