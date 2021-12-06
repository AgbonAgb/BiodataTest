using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiodataTest.Interfaces;
using BiodataTest.Models;

namespace BiodataTest.Controllers
{
    public class SkillsController : Controller
    {
        private readonly ISkills _skills;
        private readonly ICategory _category;
        public SkillsController(ISkills skills, ICategory category)
        {
            _skills = skills;
            _category = category;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateSkills()
        {
            Skills Sk = new Skills();


            ViewBag.listofCategory = await loadCategories();

            return View(Sk);
        }
        public async Task<JsonResult> loadCategories()
        {
            //new SelectList(@ViewBag.listofDept,"CategoryID","CategoryName"))
            var existing = await _category.GetAllCategory();          
            List<Category> list2 = existing.AsEnumerable()
                         .Select(o => new Category
                         {
                             CategoryID= o.CategoryID,
                             CategoryName=o.CategoryName
                             

                         }).ToList();


            return Json(list2);

        }
        //public async Task<IActionResult> GetCategories()
        //{
        //   // ViewBag.listofDept = await loadDept();
        //}
    }
}
