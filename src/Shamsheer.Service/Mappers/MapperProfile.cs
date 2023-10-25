using AutoMapper;
using Shamsheer.Service.DTOs.Users;
using Shamsheer.Service.DTOs.Groups;
using Shamsheer.Domain.Entities.Chats;
using Shamsheer.Domain.Entities.Assets;
using Shamsheer.Service.DTOs.UserAssets;
using Shamsheer.Service.DTOs.UserGroup;
using Shamsheer.Domain.Entities.Authorizations.Groups;
using Shamsheer.Service.DTOs.Authorizations.Groups;
using Shamsheer.Service.DTOs.Authorizations.GroupPermissions;
using Shamsheer.Service.DTOs.Channels;
using Shamsheer.Service.DTOs.UserChannels;
using Shamsheer.Domain.Entities.Authorizations.Channels;
using Shamsheer.Service.DTOs.Authorizations.ChannelPermissions;
using Shamsheer.Service.DTOs.Authorizations.Channels;
using Shamsheer.Service.DTOs.Authorizations.ChannelRolePermissions;
using Shamsheer.Service.DTOs.Authorizations.GroupRolePermissions;

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

            // GroupRole
            CreateMap<GroupRole, GroupRoleForResultDto>().ReverseMap();

            // ChannelRole
            CreateMap<ChannelRole, ChannelRoleForResultDto>().ReverseMap();

            // GroupPermission
            CreateMap<GroupPermission,GroupPermissionForResultDto>().ReverseMap();

            // ChannelPermission
            CreateMap<ChannelPermission, ChannelPermissionForResultDto>().ReverseMap();

            //Channel Mapping
            CreateMap<Channel, ChannelForCreationDto>().ReverseMap();
            CreateMap<Channel, ChannelForResultDto>().ReverseMap();
            CreateMap<Channel, ChannelForUpdateDto>().ReverseMap();

            //UserChannel Mapping
            CreateMap<UserChannel, UserChannelForCreationDto>().ReverseMap();
            CreateMap<UserChannel, UserChannelForResultDto>().ReverseMap();
            CreateMap<UserChannel, UserChannelForUpdateDto>().ReverseMap();

            //ChannelRolePermission
            CreateMap<ChannelRolePermission, ChannelRolePermissionForCreationDto>().ReverseMap();
            CreateMap<ChannelRolePermission, ChannelRolePermissionForResultDto>().ReverseMap();
            CreateMap<ChannelRolePermission, ChannelRolePermissionForUpdateDto>().ReverseMap();

            //GroupRolePermission
            CreateMap<GroupRolePermission, GroupRolePermissionForCreationDto>().ReverseMap();
            CreateMap<GroupRolePermission, GroupRolePermissionForResultDto>().ReverseMap();
            CreateMap<GroupRolePermission, GroupRolePermissionForUpdateDto>().ReverseMap();
        }
    }
}
