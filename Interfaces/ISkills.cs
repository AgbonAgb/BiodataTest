using BiodataTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiodataTest.Interfaces
{
   public interface ISkills
    {
        Task<bool> CreateSkills(Skills skill);
        Task<IEnumerable<Skills>> GetSkills();
        Task<Skills> GetIndSkills(int Id);
        Task<bool> UpdateSkills(Skills skill);
        Task<bool> DeleteSkill(int Id);
    }
}
