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
    public class SkillServices : ISkills
    {
        private readonly AppDbContext _appDbContext;
        public SkillServices(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> CreateSkills(Skills skill)
        {
            bool succ = false;
            var sk = await _appDbContext.skills.Where(a => a.skillCode == skill.skillCode || a.CategoryID == skill.CategoryID).FirstOrDefaultAsync();
            if(sk == null)
            {
                await _appDbContext.AddAsync(skill);
                await _appDbContext.SaveChangesAsync();
                succ = true;
            }

            return succ;
        }

        public async Task<bool> DeleteSkill(int Id)
        {
            bool succ = false;
            var skdel = await _appDbContext.skills.FindAsync(Id);
            if(skdel !=null)
            {
                _appDbContext.Remove(skdel);
                await _appDbContext.SaveChangesAsync();
                succ = true;
            }

            return succ;
        }

        public async Task<Skills> GetIndSkills(int Id)
        {
            return await _appDbContext.skills.Where(x => x.skillId == Id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Skills>> GetSkills()
        {
            return await _appDbContext.skills.ToListAsync();//
        }

        public async Task<bool> UpdateSkills(Skills skill)
        {
            bool succ = false;
            var sk = await _appDbContext.skills.FindAsync(skill.skillId);//.Where(a => a.skillCode == skill.skillCode || a.CategoryID == skill.CategoryID).FirstOrDefaultAsync();
            if (sk != null)
            {

                sk.CategoryID = skill.CategoryID;
                sk.skillCode = skill.skillCode;
                sk.skillDescription = skill.skillDescription;
                          


                await _appDbContext.SaveChangesAsync();
                succ = true;
            }

            return succ;
        }
    }
}
