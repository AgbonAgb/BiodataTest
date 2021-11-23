using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BiodataTest.Models;
using BiodataTest.ViewModels;

namespace BiodataTest.Helper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BioData, BioDataViewModel>().ReverseMap();
            CreateMap<Dept,DeptViewModel>().ReverseMap();
        }
    }
}
