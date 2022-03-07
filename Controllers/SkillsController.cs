using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiodataTest.Interfaces;
using BiodataTest.Models;
using Newtonsoft.Json;
using static BiodataTest.Controllers.Common.Enum;
using Microsoft.Extensions.Logging;
//using System.Dynamic;

namespace BiodataTest.Controllers
{
    public class SkillsController : BaseController
    {
        private readonly ISkills _skills;
        private readonly ICategory _category;
        private readonly ICareer _icareer;
        private readonly ILogger<SkillsController> _logger;
        public SkillsController(ISkills skills, ICategory category, ICareer icareer, ILogger<SkillsController> logger)
        {
            _skills = skills;
            _category = category;
            _icareer = icareer;
            _logger= logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateSkills()
        {
            Skills Sk = new Skills();


           


            if (TempData["EditSkills"] != null)
            {
                ViewData["EditSkills"] = JsonConvert.DeserializeObject<Skills>((string)TempData["EditSkills"]);

                var skills = ViewData["EditSkills"] as BiodataTest.Models.Skills;
                // string sname = category.CategoryName;

                Sk.skillId = skills.skillId;
                Sk.skillCode = skills.skillCode;
                Sk.skillDescription = skills.skillDescription;
                Sk.CategoryID = skills.CategoryID;
                Sk.CareerName = skills.CareerName;
                Sk.CategoryName = skills.CategoryName;
                Sk.CareerID = skills.CareerID;

                ViewBag.listofCategory = await loadCategories();
                // ViewBag.listofCategory = await loadCategories();
                ViewBag.listofCategory.Insert(0, new Category {CategoryID = Sk.CategoryID, CategoryName = Sk.CategoryName });
                ////////// ViewBag.listofreferers = list2;
                ViewBag.Career = await loadCareer();

                ViewBag.Career.Insert(0, new Career { CareerID = Sk.CareerID, CareerName = Sk.CareerName });


                ////Cat.CategoryName = category.CategoryName;
                ////Cat.CategoryCode = category.CategoryCode;
                ////Cat.CategoryID = category.CategoryID;
            }
            else
            {
                ViewBag.listofCategory = await loadCategories();
                ViewBag.Career = await loadCareer();
                Sk.AllSkills = await _skills.GetSkills();
            }


                //get all existing skills
               


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

           // dynamic mymodel = new ExpandoObject();

            var skill = await _skills.CreateSkills(Sk);

            if (skill)
            {
                Skills Sk2 = new Skills();
                ModelState.Clear();
                ViewBag.listofCategory = await loadCategories();
                ViewBag.Career = await loadCareer();

                Sk2.AllSkills = await _skills.GetSkills();
                return View(Sk2);

                //return RedirectToAction("ExistingSkill");
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
        [HttpGet]
        public async Task<IActionResult> EditSkills(int Id)
        {
            Skills sk = new Skills();
            Category Cat = new Category();
            //var existedCat = await _iCategory.GetCategoryById(Id);

            var skill = await _skills.GetIndSkills(Id);
            if(skill != null)
            {
                sk = skill;
                TempData["EditSkills"] = JsonConvert.SerializeObject(sk); ;
            }
           else
            {
                TempData["EditSkills"] = null;
                return NotFound();//
                
            }

            //return skill;
            return RedirectToAction("CreateSkills");

        }

        public async Task<IActionResult> DeleteSkills(int Id)
        {

            //var existedCat = await _iCategory.GetCategoryById(Id);
           // bool resp = false;
            bool skill = await _skills.DeleteSkill(Id);
            if (skill)
            {
                return View();
            }
            else
            {

                return NotFound();  
            }

           // return resp;// RedirectToAction("CreateSkills");
            //return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditSkills(Skills Sk)
        {
            var skill = await _skills.UpdateSkills(Sk);

            if (skill)
            {
                //Skills Sk2 = new Skills();
                //ModelState.Clear();
                //ViewBag.listofCategory = await loadCategories();
                //ViewBag.Career = await loadCareer();

                //Sk2.AllSkills = await _skills.GetSkills();


                Alert("Update successful", NotificationType.success);


                TempData["EditSkills"] = null;
                return RedirectToAction("CreateSkills");
                //return RedirectToAction("ExistingSkill");
            }
            else
            {
                return RedirectToAction("CreateSkills");
            }

        }
    }
}
