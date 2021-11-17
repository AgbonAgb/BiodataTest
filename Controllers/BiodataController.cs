using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiodataTest.Interfaces;
using BiodataTest.ViewModels;
using BiodataTest.Models;

namespace BiodataTest.Controllers
{
    public class BiodataController : Controller
    {
        private IBiodata _bioData;
        public BiodataController(IBiodata bioData)
        {
            _bioData = bioData;
        }

        public async Task<IActionResult> existedBiodata()
        {

            var existing = await _bioData.GetexistingBiodata();

            return View(existing);
        }
        public IActionResult CreateBiodata()
        {
            BioDataViewModel Bid = new BioDataViewModel();


            return View(Bid);
        }

        //[FromBody] 
        //("CreateBiodata")
        //Biodata/CreateBiodata
        [HttpPost]
        public async Task<IActionResult> CreateBiodata(BioDataViewModel bioDataViewModel)
        {

            BioData bio = new BioData();

            bio.StaffId = bioDataViewModel.StaffId;
            bio.FirstName = bioDataViewModel.FirstName;
            bio.LastName = bioDataViewModel.LastName;
            bio.Address = bioDataViewModel.Address;
            bio.DOB = bioDataViewModel.DOB;

            var newbio = await _bioData.CreateBiodata(bio);
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
            BioData bio2 = new BioData();
            bio2 = await _bioData.GetBiodata(Id);

            BioDataViewModel bio = new BioDataViewModel();
            bio.Id = bio2.Id;
            bio.StaffId = bio2.StaffId;
            bio.FirstName = bio2.FirstName;
            bio.LastName = bio2.LastName;
            bio.Address = bio2.Address;
            bio.DOB = bio2.DOB;

            return View(bio);
        }
        [HttpPost]
        public async Task<IActionResult> EditBiodata(BioDataViewModel bioDataViewModel)
        {

            BioData bio = new BioData();
            bio.Id = bioDataViewModel.Id;
            bio.StaffId = bioDataViewModel.StaffId;
            bio.FirstName = bioDataViewModel.FirstName;
            bio.LastName = bioDataViewModel.LastName;
            bio.Address = bioDataViewModel.Address;
            bio.DOB = bioDataViewModel.DOB;

            var newbio = await _bioData.UpdateBiodata(bio);
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
