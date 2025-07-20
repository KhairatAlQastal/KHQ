using AutoMapper;
using KHQ.Domain.DTOs;
using KHQ.Domain.Entities;
using KHQ.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KHQ.Srv.Mapper
{
    public class BaseHomeProfile : Profile
    {
        public BaseHomeProfile()
        {
            CreateMap<BaseHome, BaseHomeDto>().ForMember(dest => dest.Title, opt => opt.MapFrom(src =>
                CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar"
                    ? src.TitleAr
                    : src.TitleEn
            ));

            CreateMap<BaseHome, BaseHomeVM>().ReverseMap();
            CreateMap<BaseHomeVM, BaseHome>().ReverseMap();

            CreateMap<Slider, SliderVM>().ReverseMap();
            CreateMap<SliderVM, Slider>().ReverseMap();
        }
    }

}
