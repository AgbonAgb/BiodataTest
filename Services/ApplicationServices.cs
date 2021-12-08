using BiodataTest.Data;
using BiodataTest.Interfaces;
using BiodataTest.Models;
using BiodataTest.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiodataTest.Services
{
    public class ApplicationServices : IApplication
    {
        private readonly AppDbContext _appDbContext;
        public ApplicationServices(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> CreateApplication(ApplicationDetails Ap)
        {
            bool succ = false;
            try
            {
                var chk = await _appDbContext.applications.Where(x => x.CareerID == Ap.CareerID && x.Email == Ap.Email).FirstOrDefaultAsync();

                if (chk == null)
                {
                    await _appDbContext.AddAsync(Ap);
                    await _appDbContext.SaveChangesAsync();
                    succ = true;

                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return succ;
        }

        public async Task<bool> DeleteApplication(int Id)
        {
            bool succ = false;
            try
            {
                var chk = await _appDbContext.applications.FindAsync(Id);//.Where(x => x.CareerID == Ap.CareerID && x.Email == Ap.Email).FirstOrDefaultAsync();

                if (chk != null)
                {
                   _appDbContext.Remove(chk);
                    await _appDbContext.SaveChangesAsync();
                    succ = true;

                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return succ;
        }

        public async Task<IEnumerable<ApplicationDetails>> GetAllApplications()
        {
            var chk = await _appDbContext.applications.ToListAsync();
           // ApplicationViewModel appmodel = (ApplicationViewModel)chk;
            return chk;
        }

        public async Task<IEnumerable<ApplicationDetails>> GetAllApplications(List<string> Roles)
        {
            //User.IsInRole("Administrator")

            string role = "";//= Roles[0];

            foreach (string rl in Roles)
            { 
                
                
                role = role + "," + rl;
            }


            ////var query = await (from career in _appDbContext.careers.Where(x => x.CareerID == Id)
            ////                   join category in _appDbContext.categorys on career.CategoryID equals category.CategoryID
            ////                   join skill in _appDbContext.skills on career.CategoryID equals skill.CategoryID
            ////                   select new CareerViewModel
            ////                   {
            ////                       CareerID = career.CareerID,
            ////                       CareerName = career.CareerName,
            ////                       CareerImageUrl = career.CareerImageUrl,
            ////                       CategoryID = career.CategoryID,
            ////                       CareerDesc = career.CareerDesc,
            ////                       CategoryName = category.CategoryName,
            ////                       skills = skill.skillDescription
            ////                   }
            ////             ).FirstOrDefaultAsync();

            var query = await (from application in _appDbContext.applications
                               join category in _appDbContext.categorys on application.CategoryID equals category.CategoryID
                               join career in _appDbContext.careers on application.CategoryID equals career.CategoryID
                               select new ApplicationDetails
                               {
                                   ApplicationId = application.ApplicationId,
                                   EmployerId = application.EmployerId,
                                   CareerID = application.CareerID,
                                   CategoryID = application.CategoryID,
                                   FirstName = application.FirstName,
                                   LastName = application.LastName,
                                   Email = application.Email,
                                   PhoneNumber = application.PhoneNumber,
                                   yearsExpe = application.yearsExpe,
                                   CvPath = application.CvPath,
                                   Address = application.Address,
                                   CategoryName = category.CategoryName,
                                   CareerName = career.CareerName

                               }
                        ).ToListAsync();//.FirstOrDefaultAsync();



            //var chk = await _appDbContext.applications.ToListAsync();
            // ApplicationViewModel appmodel = (ApplicationViewModel)chk;
            return query;
        }

        

        public async Task<ApplicationDetails> GetApplication(int Id)
        {
            var chk = await _appDbContext.applications.Where(x => x.ApplicationId == Id).FirstOrDefaultAsync();
            // ApplicationViewModel appmodel = (ApplicationViewModel)chk;
            return chk;
        }

        public async Task<bool> UpdateApplication(ApplicationDetails Ap)
        {
            bool succ = false;
            try
            {
                var chk = await _appDbContext.applications.Where(x => x.ApplicationId == Ap.ApplicationId && x.approved == false && x.rejected==false).FirstOrDefaultAsync();

                if (chk != null)
                {
                    chk.Email = Ap.Email;
                    chk.CareerID = Ap.CareerID;
                    chk.CategoryID = Ap.CategoryID;
                    chk.Address = Ap.Address;
                    chk.FirstName = Ap.FirstName;
                    chk.LastName = Ap.LastName;
                    chk.PhoneNumber = Ap.PhoneNumber;
                    chk.CvPath = Ap.CvPath;



                   // _appDbContext.Remove(chk);
                    await _appDbContext.SaveChangesAsync();
                    succ = true;

                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return succ;
        }
    }
}
