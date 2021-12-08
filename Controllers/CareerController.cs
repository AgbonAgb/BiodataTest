﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiodataTest.Interfaces;
using AutoMapper;
using BiodataTest.Models;
using BiodataTest.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace BiodataTest.Controllers
{
    public class CareerController : Controller
    {
        private readonly ICareer _career;
        private IMapper _mapper;
        private readonly ICategory _category;
        private readonly ISkills _skills;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private string[] permittedExtensions = { ".jpg", ".png" };
        private readonly IApplication _application;
        private string[] permittedExtensions2 = { ".doc", ".pdf", ".docx" };
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CareerController(ICareer career, IMapper mapper, ICategory category, ISkills skills, IWebHostEnvironment webHostEnvironment, IApplication application, IHttpContextAccessor httpContextAccessor)
        {
            _career = career;
            _mapper = mapper;
            _category = category;
            _skills = skills;
            _webHostEnvironment = webHostEnvironment;
            _application = application;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public async Task<IActionResult> CreateCareer()
        {
            CareerViewModel CVM = new CareerViewModel();
            //load Career category
            ViewBag.listofCategory = await loadCategories();

            return View(CVM);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCareer(CareerViewModel CVM)
        {
            if (CVM.CareerImgfile == null)
            {
                return View(CVM);
            }
            long size = CVM.CareerImgfile.Length;//.Sum(f => f.Length);



            var ext = Path.GetExtension(CVM.CareerImgfile.FileName).ToLowerInvariant();

            if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
            {
                //Add to model state, not permited ext
                ViewBag.listofCategory = await loadCategories();
                return View(CVM);
            }
            //Try to upload file and get the URL for DB 
            //get the mimetype only pdf or word is ALLOWED
            string uniqueFileName = await UploadedFile(CVM);


            var mmapper = _mapper.Map<Career>(CVM);
            mmapper.CareerImageUrl = uniqueFileName;//add the cv path for DB
            var newCr= await _career.CreateCareer(mmapper);

            if (newCr)
            {
                //if sucess go to list page of existing
                //return View(bioDataViewModel);

                return RedirectToAction("existedCareers");
            }
            else
            {
                ViewBag.listofCategory = await loadCategories();
                return View(CVM);
            }

            //return View(CVM);
        }
        private async Task<string> UploadedFile(CareerViewModel model)
        {
            string uniqueFileName = null;

            if (model.CareerImgfile != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "CareerIMG");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.CareerImgfile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    // model.CVfile.CopyTo(fileStream);
                    await model.CareerImgfile.CopyToAsync(fileStream);
                }
            }
            return uniqueFileName;
        }
        private async Task<string> UploadedFileCv(ApplicationViewModel model)
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
        public async Task<List<Category>> loadCategories()
        {            
            var existing = await _category.GetAllCategory();

            
            ///
            List<Category> list2 = existing.AsEnumerable()
                         .Select(o => new Category
                         {
                             CategoryID = o.CategoryID,
                             CategoryName = o.CategoryName


                         }).ToList();


            return list2;

        }

        public async Task<IActionResult> existedCareers()
        {

            var existed =await _career.GetCareers();


            return View(existed);


        }

        //Application
        [HttpGet]
        public async Task<IActionResult> Application(int Id)
        {
            //get career along with Kills
            var existed = await _career.GetCareer(Id);


           //ViewBag.Imagerul = existed.CareerImageUrl;

            return View(existed);


        }

        [HttpGet]
        //ApplicationViewModel
        public async Task<IActionResult> ApplicationForm(CareerViewModel CRw)
        {
            ApplicationViewModel APpVm = new ApplicationViewModel();
            APpVm.CareerID = CRw.CareerID;
            APpVm.CategoryID = CRw.CategoryID;

            return View(APpVm);
        }

            [HttpPost]
        //public async Task<IActionResult> ApplicationForm(CareerViewModel CRw)
        public async Task<IActionResult> ApplicationForm(ApplicationViewModel ApVM)
        {

            if (ApVM.CVfile == null)
            {
                return View(ApVM);
            }
                long size = ApVM.CVfile.Length;//.Sum(f => f.Length);



            var ext = Path.GetExtension(ApVM.CVfile.FileName).ToLowerInvariant();

            if (string.IsNullOrEmpty(ext) || !permittedExtensions2.Contains(ext))
            {
                //Add to model state, not permited ext
                //ViewBag.listofCategory = await loadCategories();
                return View(ApVM);
            }
            //Try to upload file and get the URL for DB 
            //get the mimetype only pdf or word is ALLOWED
            string uniqueFileName = await UploadedFileCv(ApVM);


            var mmapper = _mapper.Map<ApplicationDetails>(ApVM);
            mmapper.CvPath = uniqueFileName;//add the cv path for DB
            mmapper.iSActive = true;
            mmapper.TransDate = DateTime.Now;//.ToString("yyyy-mm-dd");

            var newCr = await _application.CreateApplication(mmapper);

            if (newCr)
            {
                //if sucess go to list page of existing
                //return View(bioDataViewModel);

                return RedirectToAction("existedCareers");
            }
            else
            {
                //ViewBag.listofCategory = await loadCategories();
                return View(ApVM);
            }

            return View(ApVM);


        }
        //existedApplications


        [HttpGet]
        public async Task<IActionResult> existedApplications(string SearchString)
        {
            //ApplicationViewModel ApVM = new ApplicationViewModel();
            //  ApplicationDetails APD = new ApplicationDetails();

            ////var roles = ((ClaimsIdentity)User.Identity).Claims
            ////     .Where(c => c.Type == ClaimTypes.Role)
            ////     .Select(c => c.Value).ToList();
            ///
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);          

            var username = HttpContext.User.Identity.Name;



            List<string> Roles = ((ClaimsIdentity)User.Identity).Claims
                
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value).ToList();

            string role = "";//= Roles[0];

            foreach (string rl in Roles)
            {
                role = role + ","+ rl;
            }

            /* var Retactualdata = string.Empty;// */

            //List<BioDataViewModel> list2 = existing.AsEnumerable()
            //              .Select(o => new BioDataViewModel
            //              {
            //                  RefererId = o.StaffId,
            //                  Referer = o.FirstName

            //              }).ToList();



            var allapp = await _application.GetAllApplications(Roles);
            var Retactualdata = allapp;

            if (User.IsInRole("Admin"))
            {
                if (string.IsNullOrEmpty(SearchString))
                {
                    var actualdata = allapp.AsEnumerable().Select(x => new ApplicationDetails
                    {
                        ApplicationId = x.ApplicationId,
                        EmployerId = x.EmployerId,
                        CareerID = x.CareerID,
                        CategoryID = x.CategoryID,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Email = x.Email,
                        PhoneNumber = x.PhoneNumber,
                        yearsExpe = x.yearsExpe,
                        CvPath = x.CvPath,
                        Address = x.Address,
                        CategoryName=x.CategoryName,
                        CareerName=x.CareerName
                        



                    }).Where(k => k.approved == false && k.rejected == false).OrderByDescending(s => s.ApplicationId).ToList();//.FirstOrDefaultAsync();

                    Retactualdata = actualdata;
                }
                else
                {
                    var actualdata = allapp.AsEnumerable().Select(x => new ApplicationDetails
                    {
                        ApplicationId = x.ApplicationId,
                        EmployerId = x.EmployerId,
                        CareerID = x.CareerID,
                        CategoryID = x.CategoryID,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Email = x.Email,
                        PhoneNumber = x.PhoneNumber,
                        yearsExpe = x.yearsExpe,
                        CvPath = x.CvPath,
                        Address = x.Address,
                        CategoryName = x.CategoryName,
                        CareerName = x.CareerName



                    }).Where(k => k.approved == false && k.rejected == false && (k.FirstName.Contains(SearchString) || k.Email.Contains(SearchString) || k.LastName.Contains(SearchString) || k.Address.Contains(SearchString))).OrderByDescending(s => s.ApplicationId).ToList();//.FirstOrDefaultAsync();

                    Retactualdata = actualdata;
                }
                //return View(Retactualdata);
            }

            
            if (User.IsInRole("Employer"))
            {
                if (string.IsNullOrEmpty(SearchString))
                {
                    var actualdata = allapp.AsEnumerable().Select(x => new ApplicationDetails
                    {
                        ApplicationId = x.ApplicationId,
                        EmployerId = x.EmployerId,
                        CareerID = x.CareerID,
                        CategoryID = x.CategoryID,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        yearsExpe = x.yearsExpe,
                        CategoryName = x.CategoryName,
                        CareerName = x.CareerName


                    }).Where(k => k.approved == true && k.rejected == false && k.iSActive == true && (k.FirstName.Contains(SearchString) || k.Email.Contains(SearchString) || k.LastName.Contains(SearchString) || k.Address.Contains(SearchString))).OrderByDescending(s => s.ApplicationId).ToList();//.FirstOrDefaultAsync();


                    Retactualdata = actualdata;
                }
                else
                    {
                    var actualdata = allapp.AsEnumerable().Select(x => new ApplicationDetails
                    {
                        ApplicationId = x.ApplicationId,
                        EmployerId = x.EmployerId,
                        CareerID = x.CareerID,
                        CategoryID = x.CategoryID,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        yearsExpe = x.yearsExpe,
                        CategoryName = x.CategoryName,
                        CareerName = x.CareerName


                    }).Where(k => k.approved == true && k.rejected == false && k.iSActive == true).OrderByDescending(s => s.ApplicationId).ToList();//.FirstOrDefaultAsync();


                    Retactualdata = actualdata;

                }
                
               // return View(Retactualdata);
            }
            // var userEmail = User.FindFirstValue(ClaimTypes.Email);



            return View(Retactualdata);




            //return View(allapp);


            //var claims = from ur in _context.UserRoles
            //             where ur.UserId == "user_id"
            //             join r in _context.Roles on ur.RoleId equals r.Id
            //             join rc in _context.RoleClaims on r.Id equals rc.RoleId
            //             select rc;

        }
        //OnGetDownloadCV
        //ApproveCV
        public async Task<IActionResult> ApproveCV(int Id)
        {
            //get approved staff along with their cost
            //var Application = await _application.getCost();//
                      //Update Application table for approval
                      //set available to true, isactive to true//
                                                           //_bioData.GetBiodataCost(Id);

            //step2: Add to Cart-Table <userId, staffname,DOB,Desc,Amount>
            //step3: update Staff Biodata, set available to false. hired will be set to true when PO is sorted out


            return RedirectToAction("approvedstaffCatalog");// View(approvedstaff);


        }

        public async Task<IActionResult> OnGetDownloadCV(string Id)
        {

            if (string.IsNullOrEmpty(Id))
            {
                return RedirectToAction("approvedstaffCatalog");
            }
            string fileName = Id;
            //Build the File Path.
            string path = Path.Combine(this._webHostEnvironment.WebRootPath, "CVFiles/") + fileName;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }
        public async Task<IActionResult> AddUserCartlog(int Id)
        {
            //get approved staff along with their cost
            //var approvedstaff = await _bioData.GetBiodataCost(Id);

            //step2: Add to Cart-Table <userId, staffname,DOB,Desc,Amount>
            //step3: update Staff Biodata, set available to false. hired will be set to true when PO is sorted out


            return RedirectToAction("approvedstaffCatalog");// View(approvedstaff);


        }
        public async Task<IActionResult> MyApplication()
        {
            ApplicationViewModel ApVM = new ApplicationViewModel();
            
            //ApVM.CareerID = CRw.CareerID;
            //ApVM.CategoryID = CRw.CategoryID;


            //get career along with Kills
            //var existed = await _career.GetCareer(Id);


            //ViewBag.Imagerul = existed.CareerImageUrl;

            return Redirect("Application");


        }
        //MyApplication
    }
}
