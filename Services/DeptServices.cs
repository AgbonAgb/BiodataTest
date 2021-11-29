using BiodataTest.Data;
using BiodataTest.Interfaces;
using BiodataTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiodataTest.Services
{
    public class DeptServices : IDept
    {
        private readonly AppDbContext _appDbContext;

        public DeptServices(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> CreateDept(Dept dept)
        {
            bool succ = false;
            var crtt1 = await _appDbContext.dept.FindAsync(dept.DeptId);

            if(crtt1 == null)
            {
                await _appDbContext.AddAsync(dept);
                await _appDbContext.SaveChangesAsync();
                succ = true;
            }
           

            return succ;
        }

        public async Task<IEnumerable<Dept>> GetDepts()
        {          

              return await _appDbContext.dept.ToListAsync();            
        }
    }
}
