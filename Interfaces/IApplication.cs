using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiodataTest.Models;
using BiodataTest.ViewModels;

namespace BiodataTest.Interfaces
{
    public interface IApplication
    {
        Task<bool> CreateApplication(ApplicationDetails Ap);
        Task<bool> DeleteApplication(int Id);
        Task<bool> UpdateApplication(ApplicationDetails Ap);
        Task<ApplicationDetails> GetApplication(int Id);
        Task<IEnumerable<ApplicationDetails>> GetAllApplications();
        Task<IEnumerable<ApplicationDetails>> GetAllApplications(List<string> Roles);
    }
}
