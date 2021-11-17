using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiodataTest.Interfaces;
using BiodataTest.Models;
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

        public async Task<BioData> GetBiodata(int Id)
        {
            BioData bio = new BioData();

            bio = await _appDbContext.bioData.FindAsync(Id);

            return bio;            

        }

        public async Task<IEnumerable<BioData>> GetexistingBiodata()
        {
            return await _appDbContext.bioData.ToListAsync();
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
