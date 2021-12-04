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
using Microsoft.AspNetCore.Hosting;
using System.IO;
//using System.Web.MVC;

namespace BiodataTest.Controllers
{
    [Authorize]
    public class BiodataController : Controller
    {
        private IBiodata _bioData;
        private IMapper _mapper;
        private IDept _idept;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private string[] permittedExtensions = { ".doc", ".pdf", ".docx" };
        public BiodataController(IBiodata bioData, IMapper mapper, IDept idept, IWebHostEnvironment webHostEnvironment)
        {
            _bioData = bioData;
            _mapper = mapper;
            _idept = idept;
            _webHostEnvironment = webHostEnvironment;
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
                              RefererId = o.StaffId,
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


            var alldept = await _idept.GetDepts();

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
            long size = bioDataViewModel.CVfile.Length;//.Sum(f => f.Length);



            var ext = Path.GetExtension(bioDataViewModel.CVfile.FileName).ToLowerInvariant();

            if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
            {
                //Add to model state, not permited ext
                return View(bioDataViewModel);
            }
            //Try to upload file and get the URL for DB 
            //get the mimetype only pdf or word is ALLOWED
            string uniqueFileName = await UploadedFile(bioDataViewModel);

            //if (string.IsNullOrEmpty(uniqueFileName))
            //{
            //    return View(bioDataViewModel);
            //}
            //List<Student> studentList = new List<Student>();

            //studentList.AddRange(new List<Student>
            //{
            //     new Student { Name = "Vikram", Email = "vikram@gmail.com" },
            //     new Student {Name = "Bhanu", Email = "bhanu@gmail.com" }
            // });

            List<StaffCost> stc = new List<StaffCost>();

            stc.AddRange(new List<StaffCost>
            {
                //new StaffCost{StaffId = bioDataViewModel.StaffId,Cost = 45000 }
                 new StaffCost{Cost = 45000 }
            });

            bioDataViewModel.staffCost = stc;

            var mmapper = _mapper.Map<BioData>(bioDataViewModel);
            mmapper.CvPath = uniqueFileName;//add the cv path for DB
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

        private async Task<string> UploadedFile(BioDataViewModel model)
        {
            string uniqueFileName = null;

            if (model.CVfile != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "CVFiles");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.CVfile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    // model.CVfile.CopyTo(fileStream);
                    await model.CVfile.CopyToAsync(fileStream);
                }
            }
            return uniqueFileName;
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

        //Get all approved staff to add to catlog
        [HttpGet]
        public async Task<IActionResult> approvedstaffCatalog()
        {
            // var bio = await _bioData.GetBiodata(Id);
            //BioData bio2 = new BioData();

            //Pull only approved employees for selection to cart
            var approvedstaff = await _bioData.GetexistingBiodata();
            var realapproved = approvedstaff.Where(r => r.approved == true && r.available == true);


            return View(realapproved);


        }

        //AddUserCartlog
        [HttpPost]
        public async Task<IActionResult> AddUserCartlog(int Id)
        {
            //get approved staff along with their cost
            var approvedstaff = await _bioData.GetBiodataCost(Id);

            //step2: Add to Cart-Table <userId, staffname,DOB,Desc,Amount>
            //step3: update Staff Biodata, set available to false. hired will be set to true when PO is sorted out


            return RedirectToAction("approvedstaffCatalog");// View(approvedstaff);


        }
        //ApproveCV
        public async Task<IActionResult> ApproveCV(int Id)
        {
            //get approved staff along with their cost
            var approvedstaff = await _bioData.GetBiodataCost(Id);

            //step2: Add to Cart-Table <userId, staffname,DOB,Desc,Amount>
            //step3: update Staff Biodata, set available to false. hired will be set to true when PO is sorted out


            return RedirectToAction("approvedstaffCatalog");// View(approvedstaff);


        }
        //DownLoad File
        [HttpGet]
        public async Task<IActionResult> OnGetDownloadCV(string Id)
        {

            if(string.IsNullOrEmpty(Id))
            {
                return RedirectToAction ("approvedstaffCatalog");
            }
            string fileName = Id;
            //Build the File Path.
            string path = Path.Combine(this._webHostEnvironment.WebRootPath, "CVFiles/") + fileName;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }
        //Edit
        //public async Task<IActionResult> Edit(int Id)
        //{
        //    // var bio = await _bioData.GetBiodata(Id);
        //    //BioData bio2 = new BioData();

        //    //Pull only approved employees for selection to cart
        //    var approvedstaff = await _bioData.GetBiodata(Id);

        //    // var realapproved = approvedstaff.Where(r => r.Department == "Software");


        //    return RedirectToAction("approvedstaffCatalog");// View(approvedstaff);


        //}
        //ViewCv
    }
}
