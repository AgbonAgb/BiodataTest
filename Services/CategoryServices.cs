using BiodataTest.Interfaces;
using BiodataTest.Models;
using BiodataTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace BiodataTest.Services
{
    public class CategoryServices : ICategory
    {
        private readonly AppDbContext _appDbContext;
       // private readonly ILogger _logger;
        public CategoryServices(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            //_logger = logger;
        }
        public async Task<bool> CreateCaterory(Category category)
        {
            bool rtn = false;

            var CatCreat = await _appDbContext.categorys.Where(x=>x.CategoryName==category.CategoryName || x.CategoryCode==category.CategoryCode).FirstOrDefaultAsync();//.FindAsync(category.CategoryID);

            if (CatCreat == null)
            {
                await _appDbContext.AddAsync(category);
                await _appDbContext.SaveChangesAsync();
                rtn = true;

               // _logger.LogInformation("Category saved successfully for " + category.CategoryName, "");
            }

            return rtn;

        }

        public async Task<bool> DeleteCategory(int categoryId)
        {
            bool rtn = false;
            var CatCreat = await _appDbContext.categorys.FindAsync(categoryId);

            if (CatCreat != null)
            {
                _appDbContext.Remove(CatCreat);//.AddAsync(category);
                await _appDbContext.SaveChangesAsync();
                rtn = true;

                //_logger.LogInformation("Category successfully deleted for  " + CatCreat.CategoryName, "");
            }

            return rtn;

        }

        public async Task<bool> EditCategory(Category category)
        {
            bool rtn = false;
            var CatEdit = await _appDbContext.categorys.FindAsync(category.CategoryID);

            if (CatEdit == null)
            {
                CatEdit.CategoryName = category.CategoryName;
                CatEdit.CategoryCode = category.CategoryCode;


                await _appDbContext.SaveChangesAsync();
                rtn = true;

                //_logger.LogInformation("Category successfully edited for " + category.CategoryName, "");
            }

            return rtn;
        }

        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            var allCat = await _appDbContext.categorys.OrderByDescending(x=>x.CategoryID).ToListAsync();

            return allCat;
        }

        //public async Task<Category> GetCategoryById(int categoryId)
        public async Task<Category> GetCategoryById(int categoryId)
        {
            Category catgry = new Category();

            return await _appDbContext.categorys.Where(p => p.CategoryID == categoryId).FirstOrDefaultAsync();

            ////var SelectCat = await _appDbContext.categorys.Select(a => new Category
            ////{
            ////    CategoryCode= a.CategoryCode,
            ////    CategoryName=a.CategoryName

            ////}).Where(p => p.CategoryID == categoryId).FirstOrDefault();




            //var query = await _appDbContext.bioData.Where(p => p.StaffId == Id).Include(c => c.staffCost).FirstOrDefaultAsync();//.Where(p => p.StaffId); ;

            //if(SelectCat !=null)
            //{

            //}

            return catgry;
        }
    }
}
