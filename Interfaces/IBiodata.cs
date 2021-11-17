using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiodataTest.Models;

namespace BiodataTest.Interfaces
{
   public interface IBiodata
    {
        Task<bool> CreateBiodata(BioData biodata);
        Task<IEnumerable<BioData>> GetexistingBiodata();
        Task<BioData> GetBiodata(int Id);
        Task<bool> UpdateBiodata(BioData biodata);
        Task<bool> DeleteBiodata(int Id);
    }
}
