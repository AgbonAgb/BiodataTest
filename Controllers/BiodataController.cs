using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiodataTest.Interfaces;
using BiodataTest.ViewModels;
using BiodataTest.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;//.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Rendering;
//using System.Web.MVC;

namespace BiodataTest.Controllers
{
    [Authorize]
    public class BiodataController : Controller
    {
        private IBiodata _bioData;
        private IMapper _mapper;
        private IDept _idept;
        public BiodataController(IBiodata bioData, IMapper mapper, IDept idept)
        {
            _bioData = bioData;
            _mapper = mapper;
            _idept = idept;
        }

        public async Task<IActionResult> existedBiodata()
        {

            var existing = await _bioData.GetexistingBiodata();

            return View(existing);
        }
       public async Task<JsonResult> populatereferers()
        {
            var existing = await _bioData.GetexistingBiodata();


            //return Json(existing.Select(x => new
            //    {
            //        id = x.Id,
            //        FirstName = x.FirstName
            //    }
            //    )); 

            List<BioDataViewModel> list2 = existing.AsEnumerable()
                          .Select(o => new BioDataViewModel
                          {
                              RefererId = o.Id,
                              Referer = o.FirstName

                          }).ToList();
            //$('#refererId').append('<option value="' + item.refererId + '">' + item.Referer + '</option>')

            //////// list2.Insert(0, new BioData { Id = 0, FirstName = "Select" });
            ////////// ViewBag.listofreferers = list2;

            //////// return Json(list2);
            ///

            ////List<BioData> list2 = new List<BioData>();

            ////var data = existing.Where(x => x.Id == 1).ToList();


            return Json(list2);


            //List<BioData> list2 = existing.AsEnumerable()
            //             .Select(o => new BioData
            //             {
            //                 Id = o.Id,
            //                 FirstName = o.FirstName

            //             }).ToList();

            //list2.Insert(0, new BioData { Id = 0, FirstName = "Select" });
            // ViewBag.listofreferers = list2;

            //return Json(list2);

        }
        public async Task<List<Dept>> loadDept()
        {
            //ViewData  
                
                
            var alldept    = await _idept.GetDepts();

            List<Dept> dp = new List<Dept>();

            dp = alldept.Select(a => new Dept
            {
                DeptId = a.DeptId,
                DepartmentName = a.DepartmentName
            }

            ).ToList();


            dp.Insert(0, new Dept { DeptId = 0, DepartmentName = "Select Dept" });
            


            return dp;
            //return View();
        }
        public async Task<List<Dept>> loadDept2()
        {
            //ViewData  


            var alldept = await _idept.GetDepts();

            List<Dept> dp = new List<Dept>();

            dp = alldept.Select(a => new Dept
            {
                DeptId = a.DeptId,
                DepartmentName = a.DepartmentName
            }

            ).ToList();


           // dp.Insert(0, new Dept { DeptId = 0, DepartmentName = "Select Dept" });



            return dp;
            //return View();
        }
        public async Task<IActionResult> CreateBiodata()
        {
            BioDataViewModel Bid = new BioDataViewModel();


            //var existing = await _bioData.GetexistingBiodata();



            //var list2 = existing.AsEnumerable()
            //               .Select(o => new SelectListItem()
            //               {
            //                   Text = o.FirstName,
            //                   Value = o.Id.ToString(),

            //               }).ToList();

            //list2.Insert(0, new SelectListItem()
            //{
            //    Text = "----Select----",
            //    Value = string.Empty
            //});


            //Bid.Referer = list2;
            ViewBag.listofDept = await loadDept();

            return View(Bid);
        }

        //[FromBody] 
        //("CreateBiodata")
        //Biodata/CreateBiodata
      
        [HttpPost]
        public async Task<IActionResult> CreateBiodata(BioDataViewModel bioDataViewModel)
        {

          
            var mmapper = _mapper.Map<BioData>(bioDataViewModel);

            var newbio = await _bioData.CreateBiodata(mmapper);
            if (newbio)
            {
                //if sucess go to list page of existing
                //return View(bioDataViewModel);

                return RedirectToAction("existedBiodata");
            }
            else
            {
                return View(bioDataViewModel);
            }

        }
        //Delete
        public async Task<IActionResult> Delete(int Id)
        {
            var bio = await _bioData.DeleteBiodata(Id);

            if (bio)
            {
               

                return RedirectToAction("existedBiodata");
            }
            else
            {
                return RedirectToAction("existedBiodata");
            }
        }

        //Get specific Biodata
        [HttpGet]
        public async Task<IActionResult> EditBiodata(int Id)
        {
            // var bio = await _bioData.GetBiodata(Id);
            //BioData bio2 = new BioData();
            var bio2 = await _bioData.GetBiodata(Id);
            ViewBag.listofDept2 = await loadDept2();

            //BioDataViewModel bio = new BioDataViewModel();
            //bio.Id = bio2.Id;
            //bio.StaffId = bio2.StaffId;
            //bio.FirstName = bio2.FirstName;
            //bio.LastName = bio2.LastName;
            //bio.Address = bio2.Address;
            //bio.DOB = bio2.DOB;
            //bio.DeptId = bio2.DeptId;
           // bio.Department = await getDept(bio2.DeptId);
           
            //loadExisting dept and set select to above deptid

            return View(bio2);


            //BioData bio2 = new BioData();
            ////var bio = await _bioData.GetBiodata(Id);

            ////var mmapper = _mapper.Map<BioDataViewModel>(bio);


            ////return View(bio);
        }
        [HttpPost]
        public async Task<IActionResult> EditBiodata(BioDataViewModel bioDataViewModel)
        {

            ////BioData bio = new BioData();
            ////bio.Id = bioDataViewModel.Id;
            ////bio.StaffId = bioDataViewModel.StaffId;
            ////bio.FirstName = bioDataViewModel.FirstName;
            ////bio.LastName = bioDataViewModel.LastName;
            ////bio.Address = bioDataViewModel.Address;
            ////bio.DOB = bioDataViewModel.DOB;


            var mmapper = _mapper.Map<BioData>(bioDataViewModel);

            var newbio = await _bioData.UpdateBiodata(mmapper);
            //var newbio = await _bioData.UpdateBiodata(bio);
            if (newbio)
            {
                //if sucess go to list page of existing
                //return View(bioDataViewModel);

                return RedirectToAction("existedBiodata");
            }
            else
            {
                return View(bioDataViewModel);
            }


        }
    }
}
