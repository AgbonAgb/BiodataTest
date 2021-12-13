using AutoMapper;
using BiodataTest.Interfaces;
using BiodataTest.Models;
using BiodataTest.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiodataTest.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory _iCategory;
        private IMapper _mapper;
        //private readonly ILogger<RegisterUser> _logger;
        public CategoryController(ICategory iCategory, IMapper mapper)
        {
            _iCategory = iCategory;
            _mapper = mapper;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateCategory()
        {
            CategoryViewModel Cat = new CategoryViewModel();

            if (TempData["EditedCategory"] != null)
            {
               //var Category = (new Category)TempData["EditedCategory"];//as BiodataTest.Models.Category;

                ViewData["EditedCategory"] = JsonConvert.DeserializeObject<Category>((string)TempData["EditedCategory"]);

                var category = ViewData["EditedCategory"]  as BiodataTest.Models.Category;
                string sname = category.CategoryName;
                Cat.CategoryName = category.CategoryName;
                Cat.CategoryCode = category.CategoryCode;
                Cat.CategoryID = category.CategoryID;
               
            }
           else
            {
                var createdC = await _iCategory.GetAllCategory();

                Cat.AllCategories = createdC;
            }

            //// CategoryViewModel Cat = new CategoryViewModel();

            //var createdC = await _iCategory.GetAllCategory();

            //Cat.AllCategories = createdC;







            return View(Cat);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryViewModel Cat)
        {

            

            var mapped = _mapper.Map<Category>(Cat);

            var createdC = await _iCategory.CreateCaterory(mapped);
            if (createdC)
            {
                ModelState.Clear();
                //CategoryViewModel Cat2 = new CategoryViewModel();

                var existedCat = await _iCategory.GetAllCategory();

                Cat.CategoryName = string.Empty;// "";
                Cat.CategoryCode = string.Empty;

                Cat.AllCategories = existedCat;


                //return RedirectToAction("existedCategories");

                return View(Cat);
            }
            else
            {
                return View(Cat);
            }

        }
        public async Task<IActionResult> existedCategories()
        {


            var createdC = await _iCategory.GetAllCategory();

            return View(createdC);
            //if (createdC)
            //{
            //    return RedirectToAction("existedCategories");
            //}
            //else
            //{
            //    return View(createdC);
            //}

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {

            Category Cat = new Category();
            var existedCat = await _iCategory.GetCategoryById(Id);
            Cat = existedCat;

            TempData["EditedCategory"] = JsonConvert.SerializeObject(Cat); ;
           
            return RedirectToAction("CreateCategory");
            //return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditCategory(CategoryViewModel Cat)
        {
            var mapped = _mapper.Map<Category>(Cat);

            var createdC = await _iCategory.EditCategory(mapped);
            if (createdC)
            {
                ////ModelState.Clear();                
                ////var existedCat = await _iCategory.GetAllCategory();

                ////Cat.CategoryName = string.Empty;// "";
                ////Cat.CategoryCode = string.Empty;

                ////Cat.AllCategories = existedCat;

                TempData["EditedCategory"] = null;
                return RedirectToAction("CreateCategory");

                //return View(Cat);
            }
            else
            {
                //return View(Cat);
                return RedirectToAction("CreateCategory");
            }
        }
    }
}
