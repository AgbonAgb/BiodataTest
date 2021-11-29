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

namespace BiodataTest.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegisterUser>().HasKey(m => m.id);
            modelBuilder.Entity<ApplicationUser>().HasKey(m => m.Id);
            //modelBuilder.Entity<UsersViewModels>().HasKey(m => m.Id);
            //UsersViewModels
            //modelBuilder.Entity<Target>().HasKey(m => m.Guid);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<BioData> bioData { get; set; }
        public DbSet<Dept> dept { get; set; }
        public DbSet<PurchaseOrder> purchaseOrder { get; set; }
        public DbSet<PurchaseOrderDetails> purchaseOrderDetails { get; set; }
        public DbSet<loginModel> loginm { get; set; }
        public DbSet<BiodataTest.AccountsModels.RegisterUser> RegisterUser { get; set; }
        public DbSet<BiodataTest.ViewModels.UsersViewModels> UsersViewModels { get; set; }
        public DbSet<BiodataTest.ViewModels.RoleViewModel> RoleViewModel { get; set; }
        //  public DbSet<BiodataTest.ViewModels.BioDataViewModel> BioDataViewModel { get; set; }


        // public DbSet<BiodataTest.ViewModels.BioDataViewModel> BioDataViewModel { get; set; }


        // public DbSet<BiodataTest.ViewModels.BioDataViewModel> BioDataViewModel { get; set; }
        // public DbSet<BiodataTest.ViewModels.DeptViewModel> DeptViewModel { get; set; }

        //loginModel
    }
}
