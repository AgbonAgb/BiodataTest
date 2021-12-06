using BiodataTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiodataTest.Interfaces
{
   public interface ICategory
    {
        Task<bool> CreateCaterory(Category category);
        Task<bool> EditCategory(Category category);
        Task<bool> DeleteCategory(int categoryId);
        Task<IEnumerable<Category>> GetAllCategory();
        Task<Category> GetCategoryById(int categoryId);
        //Task<BioDataViewModel> GetBiodata(int Id);
    }
}
