using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiodataTest.Interfaces;
using BiodataTest.Models;
using BiodataTest.Data;
using Microsoft.EntityFrameworkCore;

namespace BiodataTest.Services
{
    public class YearsExperienceCostService : IYearsExperienceCost
    {
        private readonly AppDbContext _appDbContext;
        public YearsExperienceCostService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }
        public async Task<bool> CreateCost(YearsExperienceCost costobj)
        {
            bool succ = false;

            try
            {
                var costCreate = await _appDbContext.yearsExperienceCost.Where(x => x.CategoryID == costobj.CategoryID && x.CareerID == costobj.CareerID
                    && x.YearsLowerBound == costobj.YearsLowerBound && x.YearsHigherBound == costobj.YearsHigherBound).FirstOrDefaultAsync();
                if (costCreate == null)
                {
                    await _appDbContext.AddAsync(costobj);
                    await _appDbContext.SaveChangesAsync();
                    succ = true;

                }
            }
            catch (Exception ex)
            {

            }


            return succ;

        }

        public async Task<bool> DeleteCost(YearsExperienceCost costobj)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<YearsExperienceCost>> GetAllCost()
        {
            //var allcost = await _appDbContext.yearsExperienceCost.ToListAsync();

            var allcost = await (from yex in _appDbContext.yearsExperienceCost
                                 join cat in _appDbContext.categorys on yex.CategoryID equals cat.CategoryID
                                 join career in _appDbContext.careers on yex.CareerID equals career.CareerID
                                 select new YearsExperienceCost
                                 {
                                     YearsHigherBound = yex.YearsLowerBound,
                                     YearsLowerBound = yex.YearsLowerBound,
                                     CareerID = yex.CareerID,
                                     CareerName = career.CareerName,
                                     amount = yex.amount,
                                     CategoryName = cat.CategoryName,
                                     CostId = yex.CostId,
                                     CategoryID = yex.CategoryID

                                 }
                                ).ToListAsync();


            return allcost;
        }

        public async Task<IEnumerable<YearsExperienceCost>> GetAllCostCareer(int CareerId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<YearsExperienceCost>> GetAllCostCareer(int categoryId, int CareerId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<YearsExperienceCost>> GetAllCostCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateCost(YearsExperienceCost costobj)
        {
            throw new NotImplementedException();
        }
    }
}
