using Shamsheer.Domain.Enums.Chats;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.DTOs.Authorizations.ChannelPermissions;
using Shamsheer.Service.DTOs.Authorizations.GroupPermissions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shamsheer.Service.Interfaces.Authorizations.Channels;

public interface IChannelPermissionService
{
    Task<bool> RemoveAsync(long id);
    Task<ChannelPermissionForResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<ChannelPermissionForResultDto>> RetrieveAllAsync(PaginationParams @params);
    Task<ChannelPermissionForResultDto> CreateAsync(ChannelPermissionType type);
    Task<ChannelPermissionForResultDto> ModifyAsync(long id, ChannelPermissionType type);
}
