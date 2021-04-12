using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hostel.BusinessLogic.Models;
using Hostel.Data.Models;
using Hostel.Web.Models;

namespace Hostel.Web
{
    public class ProfileManager : Profile
    {
        public ProfileManager()
        {
            CreateMap<ClientWebView, ClientBl>()
                .ForMember(dest =>
                    dest.Email,
                    opt => opt.MapFrom(src => src.Email))
                .ForMember(dest =>
                    dest.Password,
                    opt => opt.MapFrom(src => src.Password));
            CreateMap<ClientBl, ClientViewModel>();
            CreateMap< ClientViewModel,ClientBl >();
            CreateMap<LoginModel, LoginViewModel>();
            CreateMap<LoginViewModel, LoginModel>();
            //CreateMap<ClientFullInformation, ClientFullInformationView>();
            CreateMap<RoomBl, RoomViewModel>();
            CreateMap<RoomViewModel, RoomBl>();
            CreateMap<HandlingBl, HandlingViewModel>();
            CreateMap<HandlingViewModel,HandlingBl>();
        }
    }
}
