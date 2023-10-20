using Shamsheer.Domain.Enums.Chats;
using Shamsheer.Service.DTOs.Authorizations.Groups;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shamsheer.Service.Interfaces.Authorizations;

public interface IGroupRoleService
{
    public Task<bool> RemoveAsync(long id);
    public Task<GroupRoleForResultDto> RetrieveByIdAsync(long id);
    public Task<GroupRoleForResultDto> CreateAsync(ChatRole chatRole);
    public Task<IEnumerable<GroupRoleForResultDto>> RetrieveAllAsync();
    public Task<GroupRoleForResultDto> ModifyAsync(long id, ChatRole chatRole);
}
