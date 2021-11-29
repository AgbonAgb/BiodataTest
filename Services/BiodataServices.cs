using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiodataTest.Data;
using BiodataTest.Interfaces;
using BiodataTest.Models;
using BiodataTest.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BiodataTest.Services
{
    public class BiodataServices : IBiodata
    {
        private readonly AppDbContext _appDbContext;
        public BiodataServices(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> CreateBiodata(BioData biodata)
        {
            bool rtn = false;
            try
            {
                var checkBiodata = await _appDbContext.bioData.FindAsync(biodata.Id);
                if (checkBiodata == null)
                {
                    await _appDbContext.AddAsync(biodata);
                    await _appDbContext.SaveChangesAsync();

                    rtn = true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return rtn;
        }

        public async Task<bool> DeleteBiodata(int Id)
        {
           var bio = await _appDbContext.bioData.FindAsync(Id);

            if(bio != null)
            {
                _appDbContext.Remove(bio);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return true;
            }
            
        }

        //public async Task<BioData> GetBiodata(int Id)
        //{
        //    BioData bio = new BioData();

        //    bio = await _appDbContext.bioData.FindAsync(Id);

        //    return bio;            

        //}
        public async Task<BioDataViewModel> GetBiodata(int Id)
        {
            //BioData bio = new BioData();

            //bio = await _appDbContext.bioData.FindAsync(Id);


            var query = await  _appDbContext.bioData
                                .Where(x=> x.Id == Id)
                           .Join(
                                _appDbContext.dept,
                                biodata => biodata.DeptId,
                                department => department.DeptId,
                                (biodata, department) => new BioDataViewModel
                                {
                                    Id = biodata.Id,
                                    StaffId = biodata.StaffId,
                                    FirstName = biodata.FirstName,
                                    LastName = biodata.LastName,
                                    Address = biodata.Address,
                                    DOB = biodata.DOB,
                                    DeptId = biodata.DeptId,
                                    Department = department.DepartmentName
                                }
                            ).FirstOrDefaultAsync();
            return query;

        }

        public async Task<IEnumerable<BioDataViewModel>> GetexistingBiodata()
        {
            try
            {

                //  return await _appDbContext.bioData.ToListAsync();

                var query = await _appDbContext.bioData
                          .Join(
                               _appDbContext.dept,
                               biodata => biodata.DeptId,
                               department => department.DeptId,
                               (biodata, department) => new BioDataViewModel
                               {
                                   Id = biodata.Id,
                                   StaffId = biodata.StaffId,
                                   FirstName = biodata.FirstName,
                                   LastName = biodata.LastName,
                                   Address = biodata.Address,
                                   DOB = biodata.DOB,
                                   DeptId = biodata.DeptId,
                                   Department = department.DepartmentName
                               }
                           ).ToListAsync();
                return query;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<bool> UpdateBiodata(BioData biodata)
        {
            var bio = await _appDbContext.bioData.FindAsync(biodata.Id);

            if (bio != null)
            {

                bio.StaffId = biodata.StaffId;
                bio.FirstName = biodata.FirstName;
                bio.LastName = biodata.LastName;
                bio.Address = biodata.Address;
                bio.DOB = biodata.DOB;
                bio.DeptId = biodata.DeptId;



                await _appDbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
