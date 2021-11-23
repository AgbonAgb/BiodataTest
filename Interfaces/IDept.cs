using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiodataTest.Models;

namespace BiodataTest.Interfaces
{
   public interface IDept
    {
        Task<bool> CreateDept(Dept dept);
        Task <IEnumerable<Dept>> GetDepts();
    }
}
