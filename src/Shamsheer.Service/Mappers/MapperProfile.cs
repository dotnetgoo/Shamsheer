using AutoMapper;
using Shamsheer.Domain.Entities.Assets;
using Shamsheer.Domain.Entities.Chats;
using Shamsheer.Service.DTOs.UserAssets;
using Shamsheer.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Service.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // User
            CreateMap<User, UserForCreationDto>().ReverseMap();
            CreateMap<User, UserForUpdateDto>().ReverseMap();
            CreateMap<User, UserForResultDto>().ReverseMap();


            // UserAsset
            CreateMap<UserAsset, UserAssetForResultDto>().ReverseMap();
        }
    }
}
