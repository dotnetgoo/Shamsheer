using AutoMapper;
using Shamsheer.Service.DTOs.Users;
using Shamsheer.Service.DTOs.Groups;
using Shamsheer.Domain.Entities.Chats;
using Shamsheer.Domain.Entities.Assets;
using Shamsheer.Service.DTOs.UserAssets;
using Shamsheer.Service.DTOs.UserGroup;

namespace Shamsheer.Service.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // User
            CreateMap<User, UserForUpdateDto>().ReverseMap();
            CreateMap<User, UserForResultDto>().ReverseMap();
            CreateMap<User, UserForCreationDto>().ReverseMap();


            // UserAsset
            CreateMap<UserAsset, UserAssetForResultDto>().ReverseMap();

            // Group
            CreateMap<Group, GroupForResultDto>().ReverseMap();
            CreateMap<Group, GroupForUpdateDto>().ReverseMap();
            CreateMap<Group, GroupForCreationDto>().ReverseMap();

            // UserGroup
            CreateMap<UserGroup, UserGroupForUpdateDto>().ReverseMap();
            CreateMap<UserGroup, UserGroupForResultDto>().ReverseMap();
            CreateMap<UserGroup, UserGroupForCreationDto>().ReverseMap();
        }
    }
}
