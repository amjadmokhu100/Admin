using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test3.Data;
using test3.Models;

namespace test3
{
    public static class AutoMapperConfig
    {
        public static IMapper Mapper { get; private set; }
        public static void Init()
        {
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<Service, ServiceModel>().ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
                .ForMember(dst => dst.Name, src => src.MapFrom(e => e.Name))
                .ForMember(dst => dst.Description, src => src.MapFrom(e => e.Description))
                .ForMember(dst => dst.NormalPrice, src => src.MapFrom(e => e.NormalPrice))
                .ForMember(dst => dst.NormalHour, src => src.MapFrom(e => e.NormalHour))
                .ForMember(dst => dst.FastPrice, src => src.MapFrom(e => e.FastPrice))
                .ForMember(dst => dst.FastHour, src => src.MapFrom(e => e.FastHour))
                .ForMember(dst => dst.Photo, src => src.MapFrom(e => e.Photo))
                .ForMember(dst => dst.Sale, src => src.MapFrom(e => e.Sale))
                .ReverseMap();

                cfg.CreateMap<Employee, EmployeeModel>().ReverseMap();
            });

            Mapper = config.CreateMapper();
        }
    }
}