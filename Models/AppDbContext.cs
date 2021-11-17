using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BiodataTest.ViewModels;
namespace BiodataTest.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<BioData> bioData { get; set; }

        public DbSet<BiodataTest.ViewModels.BioDataViewModel> BioDataViewModel { get; set; }

       // public DbSet<BiodataTest.ViewModels.BioDataViewModel> BioDataViewModel { get; set; }
    }
}
