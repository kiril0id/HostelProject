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
            CreateMap<ClientWebView, ClientFullInformation>()
                .ForMember(dest =>
                    dest.Email,
                    opt => opt.MapFrom(src => src.Email))
                .ForMember(dest =>
                    dest.Password,
                    opt => opt.MapFrom(src => src.Password));
            CreateMap<ClientFullInformation, ClientFullInformationView>();
            CreateMap< ClientFullInformationView,ClientFullInformation >();
            CreateMap<BusinessLogic.Models.LoginModel, Models.LoginModel>();
            CreateMap<Models.LoginModel, BusinessLogic.Models.LoginModel>();
            //CreateMap<ClientFullInformation, ClientFullInformationView>();
        }
    }
}
