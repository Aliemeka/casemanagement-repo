using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ministryofjusticeDomain.Entities;
using ministryofjusticeWebUi.Models;

namespace ministryofjusticeWebUi.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Department, DepartmentViewModel>().ReverseMap().ForMember(dest => dest.Users, opt => opt.Ignore());
        }
    }
}