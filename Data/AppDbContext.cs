using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BiodataTest.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BiodataTest.Data;
using BiodataTest.Models;
using BiodataTest.AccountsModels;
using Microsoft.AspNetCore.Http;

namespace BiodataTest.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor contextAccessor) : base(options)
        {
            _contextAccessor = contextAccessor;
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegisterUser>().HasKey(m => m.id);
            modelBuilder.Entity<ApplicationUser>().HasKey(m => m.Id);
            modelBuilder.Entity<StaffCost>().Property(o => o.Cost)
            .HasColumnType("decimal(18,4)");

            //PurchaseOrderDetails
            modelBuilder.Entity<PurchaseOrderDetails>()
                .Property(o => o.unitPrice)

            .HasColumnType("decimal(18,4)");


            modelBuilder.Entity<PurchaseOrderDetails>().Property(o => o.totalPrice)
            .HasColumnType("decimal(18,4)");

            //modelBuilder.Entity<CategoryViewModel>().HasKey(m => m.CategoryID);


            //modelBuilder.Entity<ShoppingCartItemViewModel>().HasNoKey();
            //UsersViewModels
            //modelBuilder.Entity<Target>().HasKey(m => m.Guid);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {


                //UserName = "Agbon",
                //Email = "agbonwinn@yahoo.com",
                //FirstName = "Agbon",
                //LastName = "Godwin",
                //PasswordHash = "AQAAAAEAACcQAAAAEDeN6XPtWjB/59XyTXCdDACLuvRzqVCFvgkRF8CzJ0Cl3HEKB+d94afT2mksWCNMsQ=="


            });
            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole
            {
                Name = "Admin"

            });
        }
        public DbSet<StaffCost> staffcost { get; set; }
        public DbSet<BioData> bioData { get; set; }
        public DbSet<Dept> dept { get; set; }
        public DbSet<PurchaseOrder> purchaseOrder { get; set; }
        public DbSet<PurchaseOrderDetails> purchaseOrderDetails { get; set; }
        public DbSet<loginModel> loginm { get; set; }
        public DbSet<Career> careers { get; set; }
        public DbSet<Category> categorys { get; set; }
        public DbSet<Skills> skills { get; set; }
        //ApplicationDetails
        public DbSet<ApplicationDetails> applications { get; set; }
        public DbSet<YearsExperienceCost> yearsExperienceCost { get; set; }
        public DbSet<ShoppingCartItem> shoppingCartItem { get; set; }
        public DbSet<Payments> payments { get; set; }

        public DbSet<BiodataTest.AccountsModels.RegisterUser> RegisterUser { get; set; }
        public DbSet<BiodataTest.ViewModels.UsersViewModels> UsersViewModels { get; set; }
        public DbSet<BiodataTest.ViewModels.RoleViewModel> RoleViewModel { get; set; }
        public DbSet<BiodataTest.ViewModels.BioDataViewModel> BioDataViewModel { get; set; }
        public DbSet<BiodataTest.ViewModels.CategoryViewModel> CategoryViewModel { get; set; }
        public DbSet<BiodataTest.ViewModels.CareerViewModel> CareerViewModel { get; set; }
        public DbSet<BiodataTest.ViewModels.ApplicationViewModel> ApplicationViewModel { get; set; }
        public DbSet<BiodataTest.ViewModels.YearsExperienceCostViewModel> YearsExperienceCostViewModel { get; set; }
        public DbSet<BiodataTest.ViewModels.ShoppingCartItemViewModel> ShoppingCartItemViewModel { get; set; }

    }
}
