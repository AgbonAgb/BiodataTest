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
            try
            {
                var sk = await _appDbContext.skills.Where(a => a.CareerID == skill.CareerID || a.CategoryID == skill.CategoryID).FirstOrDefaultAsync();
                if (sk == null)
                {
                    await _appDbContext.AddAsync(skill);
                    await _appDbContext.SaveChangesAsync();
                    succ = true;
                }
            }
            catch (Exception ex)
            {

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
            //return await _appDbContext.skills.Where(x => x.skillId == Id).FirstOrDefaultAsync();
            var skk = await (from skil in _appDbContext.skills
                             join cat in _appDbContext.categorys on skil.CategoryID equals cat.CategoryID
                             join carr in _appDbContext.careers on skil.CareerID equals carr.CareerID
                             select new Skills
                             {
                                 skillId = skil.skillId,
                                 skillCode = skil.skillCode,
                                 skillDescription = skil.skillDescription,
                                 CategoryID = skil.CategoryID,
                                 CareerID = skil.CareerID,
                                 CareerName = carr.CareerName,
                                 CategoryName = cat.CategoryName

                             }
                          ).Where(x => x.skillId == Id).SingleOrDefaultAsync();//.ToListAsync();

            return skk;
        }

        public async Task<IEnumerable<Skills>> GetSkills()
        {
            // return await _appDbContext.skills.ToListAsync();//

           // return await _appDbContext.skills.ToListAsync();//


            var skk = await (from skil in _appDbContext.skills
                             join cat in _appDbContext.categorys on skil.CategoryID equals cat.CategoryID
                             join carr in _appDbContext.careers on skil.CareerID equals carr.CareerID
                             select new Skills
                             {
                                 skillId = skil.skillId,
                                 skillCode = skil.skillCode,
                                 skillDescription = skil.skillDescription,
                                 CategoryID=skil.CategoryID,
                                 CareerID=skil.CareerID,
                                 CareerName=carr.CareerName,
                                 CategoryName=cat.CategoryName

                             }
                            ).OrderByDescending(x=>x.skillId).ToListAsync();

            return skk;
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
                sk.CareerID = skill.CareerID;          


                await _appDbContext.SaveChangesAsync();
                succ = true;
            }

            return succ;
        }
    }
}
