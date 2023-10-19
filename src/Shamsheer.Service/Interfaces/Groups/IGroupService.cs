using Shamsheer.Service.DTOs.Groups;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Shamsheer.Service.Interfaces.Groups;

public interface IGroupService
{
    public Task<bool> RemoveAsync(long id);
    public Task<GroupForResultDto> RetrieveByIdAsync(long id);
    public Task<GroupForResultDto> ModifyTitleAsync(string title);
    public Task<IEnumerable<GroupForResultDto>> RetrieveAllAsync();
    public Task<GroupForResultDto> ModifyUsernameAsync(string username);
    public Task<GroupForResultDto> CreateAsync(GroupForCreationDto dto);
    public Task<GroupForResultDto> ModifyDescriptionAsync(string description);
    public Task<GroupForResultDto> ModifyAsync(long id, GroupForUpdateDto dto);
}
