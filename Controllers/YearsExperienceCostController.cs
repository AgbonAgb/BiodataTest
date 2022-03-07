using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiodataTest.Interfaces;
using AutoMapper;
using BiodataTest.Models;
using BiodataTest.ViewModels;

namespace BiodataTest.Controllers
{
    public class YearsExperienceCostController : Controller
    {
        private readonly IYearsExperienceCost _iyearsExperienceCost;
        private readonly ICategory _icategory;
        private readonly ICareer _icareer;
        private readonly IMapper _mapper;
        public YearsExperienceCostController(IYearsExperienceCost iyearsExperienceCost, ICategory icategory, ICareer icareer, IMapper mapper)
        {
            _iyearsExperienceCost = iyearsExperienceCost;
            _icategory = icategory;
            _icareer = icareer;
            _mapper = mapper;
        }
        [HttpGet]

        public async Task<List<Category>> loadCategories()
        {
            //new SelectList(@ViewBag.listofDept,"CategoryID","CategoryName"))
            var existing = await _icategory.GetAllCategory();


            List<Category> list2 = existing.AsEnumerable()
                         .Select(o => new Category
                         {
                             CategoryID = o.CategoryID,
                             CategoryName = o.CategoryName


                         }).ToList();


            return (list2);

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
        public async Task<IActionResult> CreateCost()
        {

            // YearsExperienceCostViewModel YSC = new YearsExperienceCostViewModel();

            // Category


            ViewBag.Category = await loadCategories();// list2;
             
            ViewBag.Career = await loadCareer();
            //Load career

            var allcost = await _iyearsExperienceCost.GetAllCost();
           
            ViewBag.Category = await loadCategories();
            ViewBag.Career = await loadCareer();

            return View(allcost);
            //return View(YSC, li);
        }

        [HttpPost]
        //public async Task<IActionResult> CreateCost(YearsExperienceCostViewModel costOj, int CategoryID, int CareerID, int YearsLowerBound, int YearsHigherBound, int amount)
        public async Task<IActionResult> CreateCost(int CategoryID, int CareerID, int YearsLowerBound, int YearsHigherBound, int amount)
        {

            //var mapped = _mapper.Map<YearsExperienceCost>(costOj);

            YearsExperienceCost yex = new YearsExperienceCost();
            yex.CareerID = CareerID;
            yex.CategoryID = CategoryID;
            yex.amount = amount;
            yex.YearsHigherBound = YearsHigherBound;
            yex.YearsLowerBound = YearsLowerBound;

            var succ = await _iyearsExperienceCost.CreateCost(yex);
            List<YearsExperienceCost> li = null;
            if (succ == true)
            {
                var allcost = await _iyearsExperienceCost.GetAllCost();
                 ////li = allcost.AsEnumerable()
                 ////   .Select(o => new YearsExperienceCost
                 ////   {
                 ////      YearsHigherBound = o.YearsLowerBound,
                 ////      YearsLowerBound = o.YearsLowerBound,
                 ////      CareerID=o.CareerID,
                 ////      CareerName=o.CareerName,
                 ////      amount = o.amount,
                 ////      CategoryName=o.CategoryName,
                 ////      CostId=o.CostId,
                 ////      CategoryID=o.CategoryID


                 ////   }).ToList();

                ViewBag.Category = await loadCategories();
                ViewBag.Career = await loadCareer();

                return View(allcost);
               // return RedirectToAction("AllCost");
            }
            else
            {

                return View(li);
            }
          

        }
        [HttpGet]
        public async Task<IActionResult> AllCost()
        {

            var allcost = await _iyearsExperienceCost.GetAllCost();
            
            
            return View(allcost);
        }

        public async Task<JsonResult> FilterCategoryCareer(int Id)
        {



            //List<Dept> departmentlist = new List<Dept>();



            

            //var data = dbContext.Departments.Where(x => x.DivId == DivId).ToList();
            //return Json(data);


            var careertExist = await _icareer.GetCareers();

            var newc = careertExist.Where(x => x.CategoryID == Id).ToList();//.FirstOrDefaultAsync();

            //List<Career> list3 = careertExist.AsEnumerable()
            //             .Select(o => new Career
            //             {
            //                 CareerID = o.CareerID,
            //                 CareerName = o.CareerName


            //             }).Where(x=>x.CategoryID==Id).ToList();

            //  ViewBag.Category = list2;

            return Json(newc);
            //return list3;

        }
    }
}
