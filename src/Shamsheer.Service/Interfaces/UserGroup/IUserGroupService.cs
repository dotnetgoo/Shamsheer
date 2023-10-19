using System.Threading.Tasks;
using System.Collections.Generic;
using Shamsheer.Service.DTOs.UserGroup;

namespace Shamsheer.Service.Interfaces.UserGroup;

public interface IUserGroupService
{
    public Task<bool> RemoveAsync(long id);
    public Task<UserGroupForResultDto> RetrieveByIdAsync(long id);
    public Task<IEnumerable<UserGroupForResultDto>> RetrieveAllAsync();
    public Task<UserGroupForResultDto> CreateAsync(UserGroupForCreationDto dto);
    public Task<UserGroupForResultDto> ModifyAsync(long id, UserGroupForUpdateDto dto);
}
