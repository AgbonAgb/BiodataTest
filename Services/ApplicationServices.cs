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
            string role =  Roles[0].ToString();
            //var query = new object(); // string.Empty[];
            var query = (IEnumerable<ApplicationDetails>)null;



            try
            {


                if (role.Contains("Admin"))
                {
                    query = await (from application in _appDbContext.applications
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
                                       CareerName = career.CareerName,
                                       approved=application.approved,
                                       rejected=application.rejected

                                   }
                ).Where(application => application.approved == false && application.rejected == false).OrderByDescending(s => s.ApplicationId).ToListAsync();//.FirstOrDefaultAsync();



                }
                else if (role.Contains("Employer"))
                {
                    //only approved and available applications will be open t Employer to see
                    query = await (from application in _appDbContext.applications
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
                                       //CategoryName = category.CategoryName,
                                       CareerName = career.CareerName,
                                       approved = application.approved,
                                       rejected = application.rejected,
                                       available=application.available

                                   }
                          ).Where(application => application.approved == true && application.available == true).OrderByDescending(s => s.ApplicationId).ToListAsync();//.FirstOrDefaultAsync();



                }

            }
            catch (Exception ex)
            {

                throw;
            }
            return query;
        }

        public async Task<IEnumerable<ApplicationDetails>> GetAllApplications(List<string> Roles, string EndDate, string StartDate, int categoryid)
        {
            DateTime RealEndDate = DateTime.Now;
            DateTime RealStartDate = DateTime.Now;

            if (!string.IsNullOrEmpty(EndDate))
            {
                RealEndDate= Convert.ToDateTime(EndDate);
            }

            if (!string.IsNullOrEmpty(StartDate))
            {
                RealStartDate = Convert.ToDateTime(StartDate);
            }


            string role = Roles[0].ToString();
            //var query = new object(); // string.Empty[];
            var query = (IEnumerable<ApplicationDetails>)null;
            try
            {

                if (role.Contains("Admin"))
                {
                    query = await (from application in _appDbContext.applications
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
                                       CareerName = career.CareerName,
                                       approved = application.approved,
                                       rejected = application.rejected,
                                       TransDate=application.TransDate

                                   }
                ).Where(application => application.approved == false && application.rejected == false && (application.CategoryID == categoryid || (application.TransDate >= RealStartDate && application.TransDate <= RealEndDate))).OrderByDescending(s => s.ApplicationId).ToListAsync();
                    //|| application.TransDate <= RealEndDate)
                    //.Where(application => application.approved == false && application.rejected == false && application.CategoryID == categoryid).OrderByDescending(s => s.ApplicationId).ToListAsync();//.FirstOrDefaultAsync();

                    // query = query.Where(e => e.TransDate < RealStartDate );//&& e.TransDate < RealEndDate

                    //.Where(application => application.approved == false && application.rejected == false && (application.CategoryID == categoryid || application.TransDate >= RealStartDate || application.TransDate <= RealEndDate)).OrderByDescending(s => s.ApplicationId).ToListAsync();
                    //|| ((application.TransDate >= StartDate && application.TransDate <= EndDate))

                }
                else if (role.Contains("Employer"))
                {
                    //only approved and available applications will be open t Employer to see
                    query = await (from application in _appDbContext.applications
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
                                       CareerName = career.CareerName,
                                       approved = application.approved,
                                       rejected = application.rejected,
                                       available = application.available,
                                       TransDate = application.TransDate

                                   }
                          ).Where(application => application.approved == true && application.available == true && (application.CategoryID == categoryid || (application.TransDate >= RealStartDate && application.TransDate <= RealEndDate))).OrderByDescending(s => s.ApplicationId).ToListAsync();//.FirstOrDefaultAsync();


                    //query = query.Where(e => e.TransDate > RealStartDate || e.TransDate < RealEndDate);
                }
            }
            catch (Exception ex)
            {

            }

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
