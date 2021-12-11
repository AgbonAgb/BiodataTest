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
        private readonly ICareer _icareer;
        public SkillsController(ISkills skills, ICategory category, ICareer icareer)
        {
            _skills = skills;
            _category = category;
            _icareer = icareer;
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
            ViewBag.Career = await loadCareer();

            return View(Sk);
        }
        public async Task<List<Career>> loadCareer()
        {
            //new SelectList(@ViewBag.listofDept,"CategoryID","CategoryName"))
            var careertExist = await _icareer.GetCareers();

            List<Career> list3 = careertExist.AsEnumerable()
                         .Select(o => new Career
                         {
                             CareerID = o.CareerID,
                             CareerName = o.CareerName


                         }).ToList();

            //  ViewBag.Category = list2;


            return list3;

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

           
            List<Category> list2 = existing.AsEnumerable()
                         .Select(o => new Category
                         {
                             CategoryID = o.CategoryID,
                             CategoryName = o.CategoryName


                         }).ToList();


            return (list2);

        }
        public async Task<JsonResult> FilterCategoryCareer(int Id)
        {

            var careertExist = await _icareer.GetCareers();

            var newc = careertExist.Where(x => x.CategoryID == Id).ToList();//.FirstOrDefaultAsync();

            return Json(newc);
            //return list3;

        }
        //public async Task<IActionResult> GetCategories()
        //{
        //   // ViewBag.listofDept = await loadDept();
        //}
    }
}
