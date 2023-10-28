using System.Threading.Tasks;
using System.Collections.Generic;
using Shamsheer.Service.DTOs.UserGroup;
using Shamsheer.Service.Configurations;

namespace Shamsheer.Service.Interfaces.UserGroup;

public interface IUserGroupService
{
    Task<bool> RemoveAsync(long id);
    Task<UserGroupForResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<UserGroupForResultDto>> RetrieveAllAsync(PaginationParams @params);
    Task<UserGroupForResultDto> CreateAsync(UserGroupForCreationDto dto);
    Task<UserGroupForResultDto> ModifyAsync(long id, UserGroupForUpdateDto dto);
}
