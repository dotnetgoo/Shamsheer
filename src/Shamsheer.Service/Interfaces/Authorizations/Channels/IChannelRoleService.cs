using Shamsheer.Domain.Enums.Chats;
using Shamsheer.Service.DTOs.Authorizations.Channels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shamsheer.Service.Interfaces.Authorizations.Channels;

public interface IChannelRoleService
{
    public Task<bool> RemoveAsync(long id);
    public Task<ChannelRoleForResultDto> RetrieveByIdAsync(long id);
    public Task<ChannelRoleForResultDto> CreateAsync(ChatRole chatRole);
    public Task<IEnumerable<ChannelRoleForResultDto>> RetrieveAllAsync();
    public Task<ChannelRoleForResultDto> ModifyAsync(long id, ChatRole chatRole);
}
