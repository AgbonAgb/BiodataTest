using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiodataTest.Interfaces;
using BiodataTest.Models;

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
            var checkBiodata = _appDbContext.bioData.FindAsync(biodata.Id);
            if(checkBiodata == null)
            {
                await _appDbContext.AddAsync(biodata);
                await _appDbContext.SaveChangesAsync();

                rtn = true;
            }

            return rtn;
        }
    }
}
