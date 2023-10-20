using Shamsheer.Domain.Enums.Chats;
using Shamsheer.Service.DTOs.Authorizations.GroupPermissions;
using Shamsheer.Service.DTOs.Authorizations.Groups;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shamsheer.Service.Interfaces.Authorizations;

public interface IGroupPermissionService
{
    public Task<bool> RemoveAsync(long id);
    public Task<GroupPermissionForResultDto> RetrieveByIdAsync(long id);
    public Task<IEnumerable<GroupPermissionForResultDto>> RetrieveAllAsync();
    public Task<GroupPermissionForResultDto> CreateAsync(GroupPermissionType type);
    public Task<GroupPermissionForResultDto> ModifyAsync(long id, GroupPermissionType type);
}
