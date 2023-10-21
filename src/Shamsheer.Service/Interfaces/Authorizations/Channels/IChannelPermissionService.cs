using Shamsheer.Domain.Enums.Chats;
using Shamsheer.Service.DTOs.Authorizations.ChannelPermissions;
using Shamsheer.Service.DTOs.Authorizations.GroupPermissions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shamsheer.Service.Interfaces.Authorizations.Channels;

public interface IChannelPermissionService
{
    public Task<bool> RemoveAsync(long id);
    public Task<ChannelPermissionForResultDto> RetrieveByIdAsync(long id);
    public Task<IEnumerable<ChannelPermissionForResultDto>> RetrieveAllAsync();
    public Task<ChannelPermissionForResultDto> CreateAsync(ChannelPermissionType type);
    public Task<ChannelPermissionForResultDto> ModifyAsync(long id, ChannelPermissionType type);
}
