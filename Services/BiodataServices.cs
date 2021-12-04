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
                var checkBiodata = await _appDbContext.bioData.FindAsync(biodata.StaffId);
                if (checkBiodata == null)
                {

                    //foreach (var stfCost in biodata.staffCost.ToList())
                    //{
                    //    var actualstaffcost = new StaffCost
                    //    {
                    //        StaffId = biodata.StaffId,
                    //        Cost = stfCost.Cost
                    //    };

                    //    biodata.staffCost.Add(actualstaffcost);

                    //}

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
                                .Where(x=> x.StaffId == Id)
                           .Join(
                                _appDbContext.dept,
                                biodata => biodata.DeptId,
                                department => department.DeptId,
                                (biodata, department) => new BioDataViewModel
                                {
                                    StaffId = biodata.StaffId,
                                  StaffNumber = biodata.StaffNumber,
                                    FirstName = biodata.FirstName,
                                    LastName = biodata.LastName,
                                    Address = biodata.Address,
                                    DOB = biodata.DOB,
                                    DeptId = biodata.DeptId,
                                    Department = department.DepartmentName,
                                    CvPath = biodata.CvPath
                                }
                            ).FirstOrDefaultAsync();
            return query;

        }
        public async Task<BioData> GetBiodataCost(int Id)
        {
            try
            {
                var query = await _appDbContext.bioData.Where(p => p.StaffId == Id).Include(c => c.staffCost).FirstOrDefaultAsync();//.Where(p => p.StaffId); ;

                //var query = await _appDbContext.bioData.Include(c => c.staffCost).Where(p => p.StaffId == Id).FirstOrDefaultAsync();
                return query;
            }
            catch (Exception ex)
            {

                throw;
            }
            //Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            //var query = await _appDbContext.bioData
            //                    .Where(x => x.StaffId == Id)
            //               .Join(
            //                    _appDbContext.dept,
            //                    biodata => biodata.DeptId,
            //                    department => department.DeptId,
            //                    (biodata, department) => new BioDataViewModel
            //                    {
            //                        StaffId = biodata.StaffId,
            //                        StaffNumber = biodata.StaffNumber,
            //                        FirstName = biodata.FirstName,
            //                        LastName = biodata.LastName,
            //                        Address = biodata.Address,
            //                        DOB = biodata.DOB,
            //                        DeptId = biodata.DeptId,
            //                        Department = department.DepartmentName
            //                    }
            //                ).FirstOrDefaultAsync();
            //return query;

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
                                   StaffId = biodata.StaffId,
                                   StaffNumber = biodata.StaffNumber,
                                   FirstName = biodata.FirstName,
                                   LastName = biodata.LastName,
                                   Address = biodata.Address,
                                   DOB = biodata.DOB,
                                   DeptId = biodata.DeptId,
                                   Department = department.DepartmentName,
                                   approved=biodata.approved,
                                   available=biodata.available,
                                   CvPath=biodata.CvPath
                                   
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
            var bio = await _appDbContext.bioData.FindAsync(biodata.StaffId);

            if (bio != null)
            {

                bio.StaffNumber = biodata.StaffNumber;
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

        //Task<BioDataViewModel> IBiodata.GetBiodataCost(int Id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
