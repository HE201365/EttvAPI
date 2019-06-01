using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EttvAPI.Data.Models;
using EttvAPI.Models;
using Profile = AutoMapper.Profile;

namespace EttvAPI.Mappers
{
    public class ApiModelToDataModel : Profile
    {
        public ApiModelToDataModel()
        {
            CreateMap<AppUserModel, AppUser>();
            CreateMap<ProfileModel, Data.Models.Profile>();
            CreateMap<VideoContentModel, VideoContent>();
        }
    }
}
