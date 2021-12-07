using Microsoft.AspNetCore.Mvc;
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
        public CareerController(ICareer career, IMapper mapper, ICategory category, ISkills skills, IWebHostEnvironment webHostEnvironment, IApplication application)
        {
            _career = career;
            _mapper = mapper;
            _category = category;
            _skills = skills;
            _webHostEnvironment = webHostEnvironment;
            _application = application;
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
        public async Task<IActionResult> existedApplications()
        {
            //ApplicationViewModel ApVM = new ApplicationViewModel();
          //  ApplicationDetails APD = new ApplicationDetails();

            var allapp = await _application.GetAllApplications();
            //ApVM.CareerID = CRw.CareerID;
            //ApVM.CategoryID = CRw.CategoryID;


            //get career along with Kills
            //var existed = await _career.GetCareer(Id);


            //ViewBag.Imagerul = existed.CareerImageUrl;

            return View(allapp);


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
