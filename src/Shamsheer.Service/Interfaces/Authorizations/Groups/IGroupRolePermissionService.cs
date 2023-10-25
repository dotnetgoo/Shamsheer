using Shamsheer.Service.DTOs.Authorizations.ChannelRolePermissions;
using Shamsheer.Service.DTOs.Authorizations.GroupRolePermissions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shamsheer.Service.Interfaces.Authorizations.Groups;

public interface IGroupRolePermissionService
{
    Task<bool> RemoveAsync(long id);
    Task<GroupRolePermissionForResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<GroupRolePermissionForResultDto>> RetrieveAllAsync();
    Task<GroupRolePermissionForResultDto> CreateAsync(GroupRolePermissionForCreationDto dto);
    Task<GroupRolePermissionForResultDto> ModifyAsync(long id, GroupRolePermissionForUpdateDto dto);
}
