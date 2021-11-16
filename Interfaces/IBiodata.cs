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
    }
}
