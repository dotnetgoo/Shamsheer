using Shamsheer.Domain.Enums.Chats;
using Shamsheer.Service.DTOs.Authorizations.Channels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shamsheer.Service.Interfaces.Authorizations.Channels;

public interface IChannelRoleService
{
    Task<bool> RemoveAsync(long id);
    Task<ChannelRoleForResultDto> RetrieveByIdAsync(long id);
    Task<ChannelRoleForResultDto> CreateAsync(ChatRole chatRole);
    Task<IEnumerable<ChannelRoleForResultDto>> RetrieveAllAsync();
    Task<ChannelRoleForResultDto> ModifyAsync(long id, ChatRole chatRole);
}
