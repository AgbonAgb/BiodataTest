using BiodataTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiodataTest.Interfaces
{
    public interface IYearsExperienceCost
    {
        Task<bool> CreateCost(YearsExperienceCost costobj);
        Task<bool> DeleteCost(YearsExperienceCost costobj);
        Task<bool> UpdateCost(YearsExperienceCost costobj);
        Task<IEnumerable<YearsExperienceCost>> GetAllCost();
        Task<IEnumerable<YearsExperienceCost>> GetAllCostCategory(int categoryId);
        Task<IEnumerable<YearsExperienceCost>> GetAllCostCareer(int CareerId);
        Task<IEnumerable<YearsExperienceCost>> GetAllCostCareer(int categoryId,int CareerId);

    }
}
