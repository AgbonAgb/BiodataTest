using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BiodataTest.Data
{
    public class SampleData
    { 
        private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    
        public static async void Initialize(IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            //IServiceProvider serviceProvider, 
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                //}





                // var context = serviceProvider.GetService<AppDbContext>();

                //string[] roles = new string[] { "Owner", "Administrator", "Manager", "Editor", "Buyer", "Business", "Seller", "Subscriber" };
                string[] roles = new string[] { "Admin" };//, "Employer"

                foreach (string role in roles)
                {
                    var roleStore = new RoleStore<IdentityRole>(context);

                    if (!context.Roles.Any(r => r.Name == role))
                    {
                        await roleStore.CreateAsync(new IdentityRole(role));
                    }
                }

                //string[] roles1 = new string[] { "Admin"};
                //foreach (string role in roles1)
                //{
                //    if (!context.Roles.Any(r => r.Name == role))
                //    {
                //        context.Roles.Add(new IdentityRole(role));
                //    }
                //}













                var user = new ApplicationUser
                {
                    FirstName = "Godwin",
                    LastName = "Agbon",
                    Email = "agbonwinn1@yahoo.com",
                    NormalizedEmail = "AGBONWINN1@YAHOO.COM",
                    UserName = "Godwin",
                    NormalizedUserName = "GODWIN",
                    PhoneNumber = "",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };

                //var result = (userStore) null;
                if (!context.Users.Any(u => u.UserName == user.UserName))
                {
                    var password = new PasswordHasher<ApplicationUser>();
                    var hashed = password.HashPassword(user, "secret");
                    user.PasswordHash = hashed;

                    var userStore = new UserStore<ApplicationUser>(context);
                    var result2 = userStore.CreateAsync(user);

                    //UserManager<ApplicationUser> _userManager = UserManager<ApplicationUser>();
                    UserManager<ApplicationUser> _userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

                    ApplicationUser user2 = await _userManager.FindByEmailAsync(user.Email);


                    var result =  _userManager.AddToRolesAsync(user, roles);

                }

                //
                // _ = AssignRoles(serviceProvider, user.Email, roles);

               context.SaveChangesAsync();
            }
        }

        public static async Task<IdentityResult> AssignRoles(IServiceProvider services, string email, string[] roles)
        {
            UserManager<ApplicationUser> _userManager = services.GetService<UserManager<ApplicationUser>>();
            //ApplicationUser user = await _userManager.FindByNameAsync.FindByEmailAsync(email);
            ApplicationUser user = await _userManager.FindByIdAsync(email);


            var result = await _userManager.AddToRolesAsync(user, roles);
            //context.SaveChangesAsync();
            return result;
        }
    }
}
