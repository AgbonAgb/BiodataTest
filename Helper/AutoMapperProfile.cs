using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BiodataTest.AccountsModels;
using BiodataTest.Data;
using BiodataTest.Models;
using BiodataTest.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace BiodataTest.Helper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BioData, BioDataViewModel>().ReverseMap();
            CreateMap<Dept,DeptViewModel>().ReverseMap();
            CreateMap<ApplicationUser, RegisterUser>().ReverseMap();
            CreateMap<CategoryViewModel, Category>().ReverseMap();
            //UsersViewModels

            //< ApplicationUser > (Ruser);
        }
    }
}
