using System.Threading.Tasks;
using System.Collections.Generic;
using Shamsheer.Service.DTOs.Groups;
using Shamsheer.Service.DTOs.Channels;

namespace Shamsheer.Service.Interfaces.Channels;
public interface IChannelService
{
    Task<bool> RemoveAsync(long id);
    Task<ChannelForResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<ChannelForResultDto>> RetrieveAllAsync();
    public Task<GroupForResultDto> ModifyTitleAsync(string title);
    Task<ChannelForResultDto> AddAsync(ChannelForCreationDto dto);
    public Task<GroupForResultDto> ModifyUsernameAsync(string username);
    Task<ChannelForResultDto> ModifyAsync(long id, ChannelForUpdateDto dto);
    public Task<GroupForResultDto> ModifyDescriptionAsync(string description);
}