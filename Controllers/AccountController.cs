using AutoMapper;
using BiodataTest.AccountsModels;
using BiodataTest.Data;
using BiodataTest.Interfaces;
using BiodataTest.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BiodataTest.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private IAccounts _iaccounts;
        //Auto mapper
        private IMapper _mapper;
        private readonly ILogger<RegisterUser> _logger;
        public AccountController(IAccounts account, IMapper mapper, ILogger<RegisterUser> logger)
        {
            _iaccounts = account;
            _mapper = mapper;
            _logger = logger;
            //_logger.LogInformation("User created a new account with password.");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            loginModel logindetails = new loginModel();


            //return View(logindetails);
            return View("login");
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(loginModel logindetails)
        {
            bool remb = logindetails.RememberMe;


            var resp = await _iaccounts.SignIn(logindetails);//this will retiurn SignInModel
            if (resp.UserExist != false)
            {
                bool isPersistent = false;// this is tru if the user chcked Remember me to allow the credential go through other browsers

                var claims = new List<Claim>();

                try
                {

                    // Setting  
                    claims.Add(new Claim(ClaimTypes.Name, resp.FullName));
                    claims.Add(new Claim(ClaimTypes.Email, resp.Email));
                    claims.Add(new Claim("Full Name", resp.FirstName + " " + resp.LastName));
                    foreach(string rol in resp.Role)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, rol));
                    }

                    
                   // claims.Add(new Claim("UserID", .FirstName + " " + resp.LastName));

                    //Claim Identity
                    var claimIdenties = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    //Claim Principal
                    var claimPrincipal = new ClaimsPrincipal(claimIdenties);

                    var authenticationManager = Request.HttpContext;

                    // Sign In.  
                    await authenticationManager.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, new AuthenticationProperties() { IsPersistent = isPersistent, ExpiresUtc = DateTime.UtcNow.AddMinutes(20) });
                }
                catch (Exception ex)
                {
                    // Info  
                    throw ex;
                }


                //add claims here
                //if exist and passwaord not ok, riderect to login

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



                //return RedirectToAction("Index", "Home");
                return RedirectToAction("existedCareers", "Career");
            }
            else
            {
                return View("RegisterUser");// View();
            }


        }
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser()
        {
            RegisterUser Ruser = new RegisterUser();


            return View(Ruser);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser(RegisterUser Ruser)
        {

            //(ModelState.IsValid) to ensure validation as required by object is coreect

            //[FromBody]
            string userpassw = Ruser.password;
            var mapped = _mapper.Map<ApplicationUser>(Ruser);
            //Note password cannot be mapped in identity user

            bool resp = await _iaccounts.CreateUser(mapped, userpassw);
            if (resp == true)
            {
                _logger.LogInformation("User created a new account with username " + Ruser.UserName);
                return RedirectToAction("getAllUsers");
            }
            else
            {
                return View("RegisterUser");

            }
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Logout1()
        {
            //var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View("Logout");
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            // var login =  HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);


            if (HttpContext.Request.Cookies.Count > 0)
            {
                var siteCookies = HttpContext.Request.Cookies.Where(c => c.Key.Contains(".AspNetCore.") || c.Key.Contains("Microsoft.Authentication"));
                foreach (var cookie in siteCookies)
                {
                    Response.Cookies.Delete(cookie.Key);
                }
            }

            ////            await HttpContext.SignOutAsync(
            ////CookieAuthenticationDefaults.AuthenticationScheme);



            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            //identity Signout

            bool IdentitySignout = await _iaccounts.SignOutUser();
            if (IdentitySignout == true)
            {
                return RedirectToAction("Login");
            }

            // HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        // [Authorize(Roles ="Admin")]

        [HttpPost]
        //public async Task<IActionResult> SearchList(string SearchString)
        //{
        //    var allusers = await _iaccounts.AllUsers();
        //    var srch = allusers.Where(s => s.UserName.Contains(SearchString) || s.Email.Contains(SearchString)).ToList();

        //    // return View(srch);
        //    return RedirectToAction("srch");
        //}
        [HttpGet]
        public async Task<IActionResult> getAllUsers(string SearchString, string sortOrder)
        {
            //List<UsersViewModels> users = new List<UsersViewModels>();//  liUsersViewModels();
            // var allusers = "{}";
           // students = students.OrderByDescending(s => s.LastName);
            if (string.IsNullOrEmpty(SearchString))
            {
                var allusers = await _iaccounts.AllUsers();

                switch (sortOrder)
                {
                    case "name_desc":
                        allusers = allusers.OrderByDescending(s => s.FirstName);
                        break;
                    case "Email":
                        allusers = allusers.OrderByDescending(s => s.Email);
                        break;

                    default:
                        allusers = allusers.OrderByDescending(s => s.UserName);
                        break;
                }


                return View(allusers);
            }
            else
            {
                var allusers1 = await _iaccounts.AllUsers();
                var allusers = allusers1.Where(s => s.UserName.Contains(SearchString) || s.Email.Contains(SearchString)).ToList();

                return View(allusers);
                
            }
            ////switch (sortOrder)
            ////{
            ////    case "name_desc":
            ////        students = students.OrderByDescending(s => s.LastName);
            ////        break;
            ////    case "Date":
            ////        students = students.OrderBy(s => s.EnrollmentDate);
            ////        break;
            ////    case "date_desc":
            ////        students = students.OrderByDescending(s => s.EnrollmentDate);
            ////        break;
            ////    default:
            ////        students = students.OrderBy(s => s.LastName);
            ////        break;
            ////}
        }
        [HttpGet]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditUsers(string Id)
        {
            UsersViewModels users = new UsersViewModels();


            users = await _iaccounts.getUser(Id);

            return View(users);

        }
        [HttpPost]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditUsers(UsersViewModels user, string Id)
        {
            //UsersViewModels users = new UsersViewModels();
            user.Id = Id;

            bool succ = await _iaccounts.UpdateUser(user);

            if (succ == true)
            {
                return RedirectToAction("getAllUsers");
            }
            else
            {
                return View(user);
            }
            //users = await _iaccounts.getUser(personId);



        }
        [HttpPost]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUsers(UsersViewModels user, string Id)
        {
            //UsersViewModels users = new UsersViewModels();
            user.Id = Id;

            bool succ = await _iaccounts.DeleteUser(user);

            if (succ == true)
            {
                return RedirectToAction("getAllUsers");
            }
            else
            {
                return View(user);
            }
            //users = await _iaccounts.getUser(personId);



        }
        [HttpGet]
        // [Authorize(Roles ="Admin")]
        public async Task<IActionResult> createRole()
        {
            ApplicationRole role = new ApplicationRole();
            return View(role);
            //users = await _iaccounts.getUser(personId);



        }

        [HttpPost]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> createRole(ApplicationRole role)
        {
            var urole = await _iaccounts.CreateRole(role);

            if (urole == true)
            {
                return RedirectToAction("getAllRoles");
            }
            else
            {
                return View(role);
            }

        }
        [HttpGet]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> getAllRoles()
        {

            //List<ApplicationRole> uroles = new List<ApplicationRole>();

            // uroles = await _iaccounts.ExistRoles();

            // IEnumerable<RoleViewModel> allRoles = new IEnumerable<RoleViewModel>();

            //RoleViewModel urole = new RoleViewModel();
            //SelectList

            var urole = await _iaccounts.ExistRoles();


            if (urole.Count() > 0)
            {
                return View(urole);
            }
            else
            {
                return View("createRole");
            }

        }
        //AddUserRole
        [HttpGet]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddUserRole(string Id)
        {
            UsersViewModels users = new UsersViewModels();

            users = await _iaccounts.getUser(Id);

            // users = await _iaccounts.getUser(Id);

            await allRoles();//THIS WILL LOAD THE VIEWBAG WHEN PAGE IS COMIMG UP

            return View(users);

        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddUserRole(UsersViewModels user, string RoleName)
        {

            //List<UserInfo> userList = _context.UserInfo.ToList();
            //ViewBag.ShowMembers = new SelectList(userList, "Id", "Email");

            var allRoless = await _iaccounts.ExistRoles();


            foreach (var Item in allRoless)
            {
                if (Item.Id.Trim() == user.RoleId.Trim())
                {
                    RoleName = Item.Name;
                    break;
                }

            }
            if (!string.IsNullOrEmpty(RoleName) && !string.IsNullOrEmpty(user.Id))
            {
                bool succ = await _iaccounts.AddUserRole(user.Id, RoleName);

                if (succ == true)
                {
                    ViewBag.Msg = "User added successfully ---" + RoleName;
                    ModelState.AddModelError("Add User to role", "User added successfully ---" + RoleName);
                    return RedirectToAction("getAllUsers");
                }
                else
                {
                    ViewBag.Msg = "User existed before for this role " + RoleName;
                    ModelState.AddModelError("Add User to role", "User existed before for this role " + RoleName);

                    await allRoles();

                    return View(user);
                }
            }
            else
            {
                ViewBag.Msg = "User existed before for this role " + RoleName;
                ModelState.AddModelError("Add User to role", "User existed before for this role " + RoleName);
                await allRoles();
                return View(user);
            }

            await allRoles();
            return View(user);

        }
        //
        //Remove user from rol
        [HttpGet]
        public async Task<IActionResult> RemoveUserRole(string Id)
        {
            UsersViewModels users = new UsersViewModels();

            users = await _iaccounts.getUser(Id);

            // users = await _iaccounts.getUser(Id);

            await allRoles();//THIS WILL LOAD THE VIEWBAG WHEN PAGE IS COMIMG UP

            return View(users);
        }
        [HttpPost]
        public async Task<IActionResult> RemoveUserRole(UsersViewModels user, string RoleName)
        {

            //List<UserInfo> userList = _context.UserInfo.ToList();
            //ViewBag.ShowMembers = new SelectList(userList, "Id", "Email");

            var allRoless = await _iaccounts.ExistRoles();


            foreach (var Item in allRoless)
            {
                if (Item.Id.Trim() == user.RoleId.Trim())
                {
                    RoleName = Item.Name;
                    break;
                }

            }
            if (!string.IsNullOrEmpty(RoleName) && !string.IsNullOrEmpty(user.Id))
            {
                bool succ = await _iaccounts.RemoveUserRole(user.Id, RoleName);

                if (succ == true)
                {
                    ViewBag.Msg = "Role removed successfully ---" + RoleName;
                    ModelState.AddModelError("User Role remover", "Role removed successfully ---" + RoleName);
                    return RedirectToAction("getAllUsers");
                }
                else
                {
                    ViewBag.Msg = "Check to confirm is user was in selected role " + RoleName;
                    ModelState.AddModelError("User Role remover", "Check to confirm is user was in selected role " + RoleName);

                    await allRoles();

                    return View(user);
                }
            }
            else
            {
                ViewBag.Msg = "User existed before for this role " + RoleName;
                ModelState.AddModelError("Add User to role", "User existed before for this role " + RoleName);
                await allRoles();
                return View(user);
            }

            await allRoles();
            return View(user);

        }


        //get list of roles
        //new SelectList(@ViewBag.listofRoles,"RoleId","RoletName"))
        // [Authorize(Roles = "Admin")]
        public async Task<List<RoleViewModel>> allRoles()
        {



            //ViewData  


            // var allRoles = await _iaccounts.ExistRoles();


            ////  var model = new RoleViewModel();
            ////  var ALLROLE = allRoles.Select(c => new SelectListItem()
            ////  {
            ////    Value = c.Id,
            ////    Text = c.Name
            ////  }).ToList();

            ////  // ViewBag.listofRoles = new MultiSelectList(categories, "CategoryID", "CategoryName");

            ////  ViewBag.listofRoles = ALLROLE;// new SelectListItem(ALLROLE, "Value", "Text");
            //////  model.RoleIdd = new[] { 1, 3, 7 };


            ////  return ViewBag.listofRoles;


            ////////List<RoleViewModel> dp = new List<RoleViewModel>();

            ////////dp = allRoles.Select(s => new RoleViewModel
            ////////{
            ////////    Id = s.Id.ToString(),
            ////////    Name = s.Name
            ////////}

            ////////).ToList();
            ////////ViewBag.listofRoles = new SelectList(dp, "Id", "Name");
            // ViewBag.listofRoles = dp;


            // ViewBag.listofRoles = allRoles;

            //var list = allRoles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            //ViewBag.listofRoles = list;

            //good
            var allRoles = await _iaccounts.ExistRoles();

            List<RoleViewModel> dp = new List<RoleViewModel>();

            dp = allRoles.Select(s => new RoleViewModel
            {
                Id = s.Id.ToString(),
                Name = s.Name
            }

            ).ToList();


            dp.Insert(0, new RoleViewModel { Id = "0", Name = "Select Role" });

            ViewBag.listofRoles = dp;

            return ViewBag.listofRoles;
        }
    }
}
