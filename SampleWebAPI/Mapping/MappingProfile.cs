using AutoMapper;
using SampleWebAPI.Controllers.Resources;
using SampleWebAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResource>();
            CreateMap<Department, DepartmentResource>();
            CreateMap<User, KeyValuePairUserResource>();

            //API Resource to Domain
            CreateMap<UserResource, User>()
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<KeyValuePairUserResource, User>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
