using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiodataTest.Models;
using BiodataTest.ViewModels;

namespace BiodataTest.Interfaces
{
   public interface ICareer
    {
        Task<bool> CreateCareer(Career CR);
        Task<bool> DeleteCareer(int Id);
        Task<bool> UpdateCareer(Career CR);
        //ApproveCV
       
        Task<CareerViewModel> GetCareer(int Id);
        //
        Task<CareerViewModel> GetCareeredit(int Id);
        Task<IEnumerable<CareerViewModel>> GetCareers();
        Task<IEnumerable<CareerViewModel>> GetCareersWithSkills();
    }
}
