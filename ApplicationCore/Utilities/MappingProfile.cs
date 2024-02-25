using ApplicationCore.Services.DTOs.Request;
using AutoMapper;
using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services.Utilities
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeBasicInfoDto, EmployeeBasicInfo>().ReverseMap();
        }
        
    }
}
