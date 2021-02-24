using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ministryofjusticeDomain.Entities;
using ministryofjusticeDomain.IdentityEntities;
using ministryofjusticeWebUi.Models;

namespace ministryofjusticeWebUi.Infrastructures
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Department, DepartmentViewModel>().ReverseMap();
            Mapper.CreateMap<ProfileViewModel, ApplicationUser>().ReverseMap();
            Mapper.CreateMap<ProfileViewModel, Lawyer>();
            Mapper.CreateMap<CreateAccountViewModel, ApplicationUser>();
        }
    }
}