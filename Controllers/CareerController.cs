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
using static BiodataTest.Controllers.Common.Enum;
using BiodataTest.Utility;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace BiodataTest.Controllers
{
    public class CareerController : BaseController// Controller
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
        private readonly IShoppingCartItem _shoppingCartItem;

        //private const string alertify = "Alertify";
        public CareerController(ICareer career, IMapper mapper, ICategory category, ISkills skills, IWebHostEnvironment webHostEnvironment, IApplication application, IHttpContextAccessor httpContextAccessor, IShoppingCartItem shoppingCartItem)
        {
            _career = career;
            _mapper = mapper;
            _category = category;
            _skills = skills;
            _webHostEnvironment = webHostEnvironment;
            _application = application;
            _httpContextAccessor = httpContextAccessor;
            _shoppingCartItem = shoppingCartItem;
        }
        [HttpGet]
        public async Task<IActionResult> CreateCareer()
        {
            HttpContext context = _httpContextAccessor.HttpContext;


            CareerViewModel CVM = new CareerViewModel();
            //load Career category
            ViewBag.listofCategory = await loadCategories();
            //get aLL Careers
            CVM.AllCareers = await _career.GetCareers();

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
            var newCr = await _career.CreateCareer(mmapper);

            if (newCr)
            {
                //if sucess go to list page of existing
                //return View(bioDataViewModel);
                ModelState.Clear();
                CareerViewModel CVM2 = new CareerViewModel();
                ViewBag.listofCategory = await loadCategories();
                CVM2.CareerName = string.Empty;
                CVM2.CareerDesc = string.Empty;

                CVM2.AllCareers = await _career.GetCareers();
                // return RedirectToAction("existedCareers");
                return View(CVM2);
            }
            else
            {
                ViewBag.listofCategory = await loadCategories();
                return View(CVM);
            }

            //return View(CVM);
        }
        [HttpGet]
        public async Task<IActionResult> listCareers()
        {
            CareerViewModel CVM2 = new CareerViewModel();
            ViewBag.listofCategory = await loadCategories();
            CVM2.CareerName = string.Empty;
            CVM2.CareerDesc = string.Empty;

            CVM2.AllCareers = await _career.GetCareers();
            // return RedirectToAction("existedCareers");
            return View(CVM2);
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

        public async Task<IActionResult> existedCareers(int pg = 1)
        {
            //add pagination
            var existed = await _career.GetCareersWithSkills();

            const int pageSize = 3;
            if (pg < 1)
            {
                pg = 1;
            }

            int rescount = existed.Count();
            var pager = new Pager(rescount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;

            var data = existed.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;
            return View(data);

            //return View(existed);


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
            APpVm.CategoryName = CRw.CategoryName;
            APpVm.CareerName = CRw.CareerName;
            APpVm.ApplicationByind = (IEnumerable<ApplicationDetails>)null;
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

                ModelState.Clear();
                ApplicationViewModel APpVm2 = new ApplicationViewModel();
                APpVm2.CareerID = ApVM.CareerID;
                APpVm2.CategoryID = ApVM.CategoryID;
                APpVm2.ApplicationByind = await _application.GetApplicationind(ApVM.CareerID, ApVM.Email);
                //if sucess go to list page of existing
                //return View(bioDataViewModel);

                //return RedirectToAction("existedCareers");

                return View(APpVm2);
            }
            else
            {
                //ViewBag.listofCategory = await loadCategories();
                return View(ApVM);
            }

            return View(ApVM);


        }
        //existedApplications
        [HttpPost]
        // [HttpGet]
        //public JsonResult FilterApplications(int CategoryId)
        ////public async Task<IActionResult> FilterApplications(int  Id)
        ///
        //[AcceptVerbs("GET")]//[FromBody]
        public async Task<IActionResult> FilterApplications(string EndDate, string StartDate, int categoryid, int Id)
        {
            // string done = "";



            // // await existedApplications(Id);


            // //var Carr = await _category.GetAllCategory();
            // //ViewBag.listofCategory = Carr;//

            // List<Dept> departmentlist = new List<Dept>();
            List<string> Roles = new List<string>();
            var allapp = await _application.GetAllApplications(Roles);
            var Retactualdata = allapp;

            if (string.IsNullOrEmpty(StartDate) && string.IsNullOrEmpty(EndDate) && categoryid == 0)
            {
                return View(allapp);
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




                }).Where(k => k.approved == false && k.rejected == false && (k.CategoryID == Id)).OrderByDescending(s => s.ApplicationId).ToList();//.FirstOrDefaultAsync();

                return View(actualdata);
            }



            //Retactualdata = actualdata;



            //return Json (actualdata);// View(actualdata);

            // return RedirectToAction("existedApplications", new { @id = Id });
            ////return View(actualdata);
            //return done;
        }
        //

        [HttpGet]
        public async Task<IActionResult> existedApplications(string EndDate, string StartDate, int categoryid, int Id)
        {



            int SearchString2 = Id;

            //Load Category for the page dropdown
            var Carr = await _category.GetAllCategory();
            List<Category> dp = new List<Category>();
            dp = Carr.Select(a => new Category
            {
                CategoryID = a.CategoryID,
                CategoryName = a.CategoryName
            }

            ).ToList();

            dp.Insert(0, new Category { CategoryID = 0, CategoryName = "Select All" });
            ViewBag.listofCategory = dp;

            // var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var query = (IEnumerable<ApplicationDetails>)null;
            var username = HttpContext.User.Identity.Name;
            string role = "";
            //if (!string.IsNullOrEmpty(username))
            //{
            //Get User Roles to determine what he can see
            List<string> Roles = ((ClaimsIdentity)User.Identity).Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value).ToList();

            //= Roles[0];

            foreach (string rl in Roles)
            {
                role = role + "," + rl;
            }

            //}


            //get all applications 

            //var Retactualdata = allapp;



            if (string.IsNullOrEmpty(StartDate) && string.IsNullOrEmpty(EndDate) && categoryid == 0)
            {


                query = await _application.GetAllApplications(Roles);
                // return View(allapp);
            }
            else
            {

                query = await _application.GetAllApplications(Roles, EndDate, StartDate, categoryid);



            }
            //}






            return View(query);


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
            var k = await _application.ApproveCV(Id);
            if (k == true)
            {
                //alert
                //return RedirectToAction("existedApplications");
            }
            //else
            //{
            //    return RedirectToAction("existedApplications");
            //}
            // View(approvedstaff);

            return RedirectToAction("existedApplications");
        }
        public async Task<IActionResult> RejectCV(int Id)
        {

            var k = await _application.RejectCV(Id);
            if (k == true)
            {
                //alert
                //return RedirectToAction("existedApplications");
            }
            //else
            //{
            //    return RedirectToAction("existedApplications");
            //}
            // View(approvedstaff);

            return RedirectToAction("existedApplications");


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
        [Authorize]
        public async Task<IActionResult> AddUserCartlog(int Id)
        {
            //details for ind application id
            var appdetails = await _application.GetApplication(Id);
            ApplicationDetails ap = new ApplicationDetails();
            ap = appdetails;

            // HttpContext context = _httpContextAccessor.HttpContext;
            string empid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;//.
            ap.EmployerId = empid;//add user id

            if (string.IsNullOrEmpty(empid))
            {
                TempData["Message"] = "Please, kindly register and login to be able to perform this function";

                dynamic transRef = TempData["Message"];

                Alert("success", transRef, NotificationType.success);
                return RedirectToAction("RegisterUser");
            }

            var ammped = _mapper.Map<ShoppingCartItem>(ap);


            var addtocart = await _shoppingCartItem.AddToCart(ammped);
            if (addtocart == true)
            {

                TempData["Message"] = ap.FirstName + " " + " added to cart Successfull";

                dynamic transRef = TempData["Message"];

                Alert("success", transRef, NotificationType.success);/*as AlertMessage;*/




                return RedirectToAction("MyCart");
            }
            else
            {

                TempData["Message"] = ap.FirstName + " " + " not added to cart Successfull";

                dynamic transRef = TempData["Message"];

                Alert("success", transRef, NotificationType.error);
                return RedirectToAction("existedApplications");
            }

            //userid=8f60f1cf-ea64-4527-ac86-5f409aac0cdf;


            //get approved staff along with their cost
            //var approvedstaff = await _bioData.GetBiodataCost(Id);

            //step2: Add to Cart-Table <userId, staffname,DOB,Desc,Amount>
            //step3: update Staff Biodata, set available to false. hired will be set to true when PO is sorted out





        }
        [HttpGet]
        public async Task<IActionResult> MyCart(int Id)
        {
            var username = HttpContext.User.Identity.Name;
            ShoppingCartItemViewModel SPC = new ShoppingCartItemViewModel();
            if (!string.IsNullOrEmpty(username))
            {
                string empid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;//.


                //spSPC.ShoppingCartTotal= "45000.00";

                SPC.Cartitems = await _shoppingCartItem.getMyCartItems(empid);
                SPC.ShoppingCartTotal = await _shoppingCartItem.GetShoppingCartTotal(empid);// decimal.Parse("25,00.00");
                SPC.EmployerId = empid;

            }

            //var mycat = await _shoppingCartItem.getMyCartItems(empid);

            return View(SPC);





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
        [HttpGet]
        public async Task<IActionResult> EditCareer2(int Id)
        {
            //[FromBody] Customer cust, 
            //Id = cust.Id;
            //Id = 1;
            //Alert("Yoo", NotificationType.success);

            CareerViewModel CVM = new CareerViewModel();
            //load Career category
            ViewBag.listofCategory = await loadCategories();
            //ViewBag.listofCategory = await loadCategories();
            //get aLL Careers
            CVM = await _career.GetCareeredit(Id);
            //CVM.CareerImgfile.FileName = String.Empty;
            // CVM.
            CVM.isActive = false;

            //if (CVM.isActive == true)
            //{
            //    ViewBag.iSactive = true;
            //}
            //set selected listofCategory to default based on Id

            // return View(CVM);
           
            return PartialView("_EditCareerPartial", CVM);
        }


        //public async Task<IActionResult> EditCareerJson(int Id)
        //{
        //    //Id = 1;
        //    CareerViewModel CVM = new CareerViewModel();
        //    //load Career category
        //    ViewBag.listofCategory = await loadCategories();
        //    //get aLL Careers
        //    CVM = await _career.GetCareeredit(Id);
        //    if (CVM.isActive == true)
        //    {
        //        ViewBag.iSactive = true;
        //    }
        //    string value = string.Empty;
        //    var ed = new EditViewData
        //    {
        //        CareerID = CVM.CareerID,
        //        CareerName = CVM.CareerName,
        //        CareerDesc = CVM.CareerDesc,
        //        CategoryID = CVM.CategoryID,
        //        CategoryName = CVM.CategoryName,
        //        CareerImageUrl=CVM.CareerImageUrl,
        //        CategoryName1 = await loadCategories()

        //    };

        //    value = JsonConvert.SerializeObject(ed, Formatting.Indented, new JsonSerializerSettings
        //    {
        //        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        //    });
        //    return Json(value);

        //    // return Json (CVM);
        //}
        ////MyApplication
        [HttpPost]
        public async Task<IActionResult> EditCareer(CareerViewModel CVM, IFormCollection collection, IFormFile file)
        {



            //dlete exsisting image from folder
            int id = CVM.CareerID;
            string uniqueFileName = "";
            //var formFile = CVM.CareerImgfile;
            //foreach (IFormFile postedFile in CVM.CareerImgfile)
            //{
            //}

            try
            {
                //int n = CVM.CareerImgfile.Length;


                //var collection = Request.Form;
                //var mp_apt = collection["CareerImgfile2"];
                //long size = file.Length;
                if (file ==null || file.Length == 0)
                {
                    uniqueFileName = CVM.CareerImageUrl;
                }
                else
                {
                    long size = file.Length;
                    CVM.CareerImgfile = file;
                    var ext = Path.GetExtension(CVM.CareerImgfile.FileName).ToLowerInvariant();

                    if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
                    {
                        //Add to model state, not permited ext
                        ViewBag.listofCategory = await loadCategories();
                        return View(CVM);
                    }
                    //Try to upload file and get the URL for DB 
                    //get the mimetype only pdf or word is ALLOWED
                    uniqueFileName = await UploadedFile(CVM);
                }
            }
            catch (System.NullReferenceException ex)
            {

                uniqueFileName = CVM.CareerImageUrl;
            }



            ////if (formFile == null)
            ////{
            ////    //return View(CVM);
            ////    uniqueFileName = CVM.CareerImageUrl;
            ////}
            ////else
            ////{
            ////    //.Sum(f => f.Length);

            ////    long size = CVM.CareerImgfile.Length;

            ////    var ext = Path.GetExtension(CVM.CareerImgfile.FileName).ToLowerInvariant();

            ////    if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
            ////    {
            ////        //Add to model state, not permited ext
            ////        ViewBag.listofCategory = await loadCategories();
            ////        return View(CVM);
            ////    }
            ////    //Try to upload file and get the URL for DB 
            ////    //get the mimetype only pdf or word is ALLOWED
            ////    uniqueFileName = await UploadedFile(CVM);
            ////}



            var mmapper = _mapper.Map<Career>(CVM);
            mmapper.CareerImageUrl = uniqueFileName;//add the cv path for DB
            var newCr = await _career.UpdateCareer(mmapper);

            if (newCr)
            {

                //TempData["Message"] = "Update Successful";

                //dynamic transRef = TempData["Message"];

                //Alert("success", transRef, NotificationType.success);
                //Alert("Update successful", NotificationType.success);

                // Alert(("This is success message", NotificationType.success);
                //Alert("success", TempData["Message"], NotificationType.success);

                //if sucess go to list page of existing
                //return View(bioDataViewModel);
                ModelState.Clear();
                CareerViewModel CVM2 = new CareerViewModel();
                ViewBag.listofCategory = await loadCategories();
                CVM2.CareerName = string.Empty;
                CVM2.CareerDesc = string.Empty;

                CVM2.AllCareers = await _career.GetCareers();
                return RedirectToAction("CreateCareer", CVM2);
                //return View(CVM2);
            }
            else
            {
                ViewBag.listofCategory = await loadCategories();
                return View(CVM);
            }



            //string imgpath = CVM.CareerImageUrl;


            //return View(CVM);
        }
    }
}
