using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiodataTest.Interfaces;
using BiodataTest.Models;
using BiodataTest.Data;
using Microsoft.EntityFrameworkCore;
using BiodataTest.ViewModels;

namespace BiodataTest.Services
{
    public class CareerServices : ICareer
    {
        private readonly AppDbContext _appDbContext;
        public CareerServices(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> CreateCareer(Career CR)
        {
            bool succ = false;


            var chk = await _appDbContext.careers.Where(x=> x.CareerName == CR.CareerName && x.CategoryID == CR.CategoryID).FirstOrDefaultAsync();
            if(chk ==null)
            {
                await _appDbContext.AddAsync(CR);
                await _appDbContext.SaveChangesAsync();
                succ = true;
            }

            return succ;
        }

        public async Task<bool> DeleteCareer(int Id)
        {
            bool succ = false;


            var chk = await _appDbContext.careers.FindAsync(Id);//.Where(x => x.CareerName == CR.CareerName || x.CategoryID == CR.CategoryID).FirstOrDefaultAsync();
            if (chk != null)
            {
                 _appDbContext.Remove(chk);
                await _appDbContext.SaveChangesAsync();
                succ = true;
            }

            return succ;
        }

        public async Task<CareerViewModel> GetCareer(int Id)
        {            ////var chk = await _appDbContext.careers.Where(x => x.CareerID == Id).FirstOrDefaultAsync();


            ////return chk;
            ///

            var query = await (from career in _appDbContext.careers.Where(x=> x.CareerID==Id)
                               join category in _appDbContext.categorys on career.CategoryID equals category.CategoryID
                               join skill in _appDbContext.skills on career.CareerID equals skill.CareerID
                               select new CareerViewModel
                               {    CareerID=career.CareerID,
                                   CareerName = career.CareerName,
                                   CareerImageUrl = career.CareerImageUrl,
                                   CategoryID = career.CategoryID,
                                   CareerDesc = career.CareerDesc,
                                   CategoryName = category.CategoryName,
                                   skills = skill.skillDescription
                               }
                         ).FirstOrDefaultAsync();

           


            return query;
        }

        public async Task<IEnumerable<CareerViewModel>> GetCareers()
        {
            
            var query = await (from career in _appDbContext.careers
                               join category in _appDbContext.categorys on career.CategoryID equals category.CategoryID
                               //join skill in _appDbContext.skills on career.CareerID equals skill.CareerID
                               select new CareerViewModel
                               {
                                   CareerID = career.CareerID,
                                   CareerName = career.CareerName,
                                   CareerImageUrl = career.CareerImageUrl,
                                   CategoryID = career.CategoryID,
                                   CareerDesc = career.CareerDesc,
                                   CategoryName = category.CategoryName
                                  // skills = skill.skillDescription
                               }
                         ).ToListAsync();




            return query;
        }

        public async Task<IEnumerable<CareerViewModel>> GetCareersWithSkills()
        {
            var query = await (from career in _appDbContext.careers
                               join category in _appDbContext.categorys on career.CategoryID equals category.CategoryID
                               join skill in _appDbContext.skills on career.CareerID equals skill.CareerID
                               select new CareerViewModel
                               {
                                   CareerID = career.CareerID,
                                   CareerName = career.CareerName,
                                   CareerImageUrl = career.CareerImageUrl,
                                   CategoryID = career.CategoryID,
                                   CareerDesc = career.CareerDesc,
                                   CategoryName = category.CategoryName,
                                   skills = skill.skillDescription
                               }
                        ).ToListAsync();




            return query;
        }

        public async Task<bool> UpdateCareer(Career CR)
        {
            bool succ = false;


            var chk = await _appDbContext.careers.FindAsync(CR.CareerID);//.Where(x => x.CareerID == Id).FirstOrDefaultAsync();
            if (chk != null)
            {

                chk.CareerName = CR.CareerName;
                chk.CareerImageUrl = CR.CareerImageUrl;
                chk.CategoryID = CR.CategoryID;
                chk.isActive = CR.isActive;
                chk.skillId = CR.skillId;
                chk.CareerDesc = CR.CareerDesc;


                //_appDbContext.Remove(chk);
                await _appDbContext.SaveChangesAsync();
                succ = true;
            }

            return succ;
        }
        //Approve CV
       
    }
}
