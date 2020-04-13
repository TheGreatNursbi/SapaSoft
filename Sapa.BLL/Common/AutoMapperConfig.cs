using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Sapa.DAL.Models;
using Sapa.BLL.Dtos;

namespace Sapa.BLL.Common
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Builder, BuilderDto>();
            //.ForMember(x => x.Id, x => x.MapFrom(m => m.Id))
            //.ForMember(x => x.Name, x => x.MapFrom(m => m.Name))
            //.ForMember(x => x.BIN, x => x.MapFrom(m => m.BIN))
            //.ForMember(x => x.ActivityStartDate, x => x.MapFrom(m => m.ActivityStartDate))
            //.ForMember(x => x.Address, x => x.MapFrom(m => m.Address))
            //.ForMember(x => x.IsDeleted, x => x.MapFrom(m => m.IsDeleted))
            //.ForMember(x => x.Buildings, x => x.MapFrom(m => m.Buildings));

            CreateMap<BuilderDto, Builder>();
                //.ForMember(x => x.Id, x => x.MapFrom(m => m.Id))
                //.ForMember(x => x.Name, x => x.MapFrom(m => m.Name))
                //.ForMember(x => x.BIN, x => x.MapFrom(m => m.BIN))
                //.ForMember(x => x.ActivityStartDate, x => x.MapFrom(m => m.ActivityStartDate))
                //.ForMember(x => x.Address, x => x.MapFrom(m => m.Address))
                //.ForMember(x => x.IsDeleted, x => x.MapFrom(m => m.IsDeleted))
                //.ForMember(x => x.Buildings, x => x.MapFrom(m => m.Buildings));

            CreateMap<Building, BuildingDto>();
            CreateMap<BuildingDto, Building>();
        }
    }
}
