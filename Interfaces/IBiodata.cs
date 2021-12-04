using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiodataTest.Models;
using BiodataTest.ViewModels;

namespace BiodataTest.Interfaces
{
   public interface IBiodata
    {
        Task<bool> CreateBiodata(BioData biodata);
        Task<IEnumerable<BioDataViewModel>> GetexistingBiodata();
        Task<BioDataViewModel> GetBiodata(int Id);
        //
        Task<BioData> GetBiodataCost(int Id);
        Task<bool> UpdateBiodata(BioData biodata);
        Task<bool> DeleteBiodata(int Id);
    }
}
