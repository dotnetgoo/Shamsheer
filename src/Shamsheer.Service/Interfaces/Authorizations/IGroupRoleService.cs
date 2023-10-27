using Shamsheer.Domain.Enums.Chats;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.DTOs.Authorizations.Groups;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shamsheer.Service.Interfaces.Authorizations;

public interface IGroupRoleService
{
    Task<bool> RemoveAsync(long id);
    Task<GroupRoleForResultDto> RetrieveByIdAsync(long id);
    Task<GroupRoleForResultDto> CreateAsync(ChatRole chatRole);
    Task<IEnumerable<GroupRoleForResultDto>> RetrieveAllAsync(PaginationParams @params);
    Task<GroupRoleForResultDto> ModifyAsync(long id, ChatRole chatRole);
}
