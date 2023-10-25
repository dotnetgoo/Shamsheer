using Shamsheer.Domain.Enums.Chats;
using Shamsheer.Service.DTOs.Authorizations.GroupPermissions;
using Shamsheer.Service.DTOs.Authorizations.Groups;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shamsheer.Service.Interfaces.Authorizations.Groups;

public interface IGroupPermissionService
{
    Task<bool> RemoveAsync(long id);
    Task<GroupPermissionForResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<GroupPermissionForResultDto>> RetrieveAllAsync();
    Task<GroupPermissionForResultDto> CreateAsync(GroupPermissionType type);
    Task<GroupPermissionForResultDto> ModifyAsync(long id, GroupPermissionType type);
}
