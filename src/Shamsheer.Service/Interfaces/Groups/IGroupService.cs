using Shamsheer.Service.Configurations;
using Shamsheer.Service.DTOs.Groups;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Shamsheer.Service.Interfaces.Groups;

public interface IGroupService
{
    Task<bool> RemoveAsync(long id);
    Task<GroupForResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<GroupForResultDto>> RetrieveAllAsync(PaginationParams @params);
    Task<GroupForResultDto> CreateAsync(GroupForCreationDto dto);
    Task<GroupForResultDto> ModifyAsync(long id, GroupForUpdateDto dto);
}
