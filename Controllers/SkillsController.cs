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
        [HttpPost]
        public async Task<IActionResult> CreateSkills(Skills Sk)
        {
            var skill = await _skills.CreateSkills(Sk);

            if (skill)

            {
                return RedirectToAction("ExistingSkill");
            }
            else
            {
                return View(Sk);
            }

           
        }

        [HttpGet]
        public async Task<IActionResult> ExistingSkill()
        {
            var skill = await _skills.GetSkills();

            return View(skill);

            //if (skill)

            //{
            //    return RedirectToAction("ExistingSkill");
            //}
            //else
            //{
                
            //}


        }
        public async Task<List<Category>> loadCategories()
        {
            //new SelectList(@ViewBag.listofDept,"CategoryID","CategoryName"))
            var existing = await _category.GetAllCategory();

            ////List<Category> list2 = new List<Category>();

            ////list2 = existing.Select(o => new Category
            ////{

            ////    CategoryName=o.CategoryName,
            ////    CategoryID = o.CategoryID
            ////}

            ////).ToList();

            ////list2.Insert(0, new Category { CategoryID = 0, CategoryName = "Select Category" });
            ///
            List<Category> list2 = existing.AsEnumerable()
                         .Select(o => new Category
                         {
                             CategoryID = o.CategoryID,
                             CategoryName = o.CategoryName


                         }).ToList();


            return (list2);

        }
        //public async Task<IActionResult> GetCategories()
        //{
        //   // ViewBag.listofDept = await loadDept();
        //}
    }
}
