using Shamsheer.Domain.Enums.Chats;
using Shamsheer.Service.DTOs.Authorizations.ChannelPermissions;
using Shamsheer.Service.DTOs.Authorizations.ChannelRolePermissions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shamsheer.Service.Interfaces.Authorizations.Channels;

public interface IChannelRolePermissionService
{
    Task<bool> RemoveAsync(long id);
    Task<ChannelRolePermissionForResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<ChannelRolePermissionForResultDto>> RetrieveAllAsync();
    Task<ChannelRolePermissionForResultDto> CreateAsync(ChannelRolePermissionForCreationDto dto);
    Task<ChannelRolePermissionForResultDto> ModifyAsync(long id, ChannelRolePermissionForUpdateDto dto);
}
