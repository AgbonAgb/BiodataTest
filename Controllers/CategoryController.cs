using AutoMapper;
using BiodataTest.Interfaces;
using BiodataTest.Models;
using BiodataTest.ViewModels;
using Microsoft.AspNetCore.Mvc;
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


           
            var createdC = await _iCategory.GetAllCategory();

            Cat.AllCategories = createdC;

            



            return View(Cat);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryViewModel Cat)
        {
            var mapped = _mapper.Map<Category>(Cat);

            var createdC = await _iCategory.CreateCaterory(mapped);
            if(createdC)
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
    }
}
