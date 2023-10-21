using System.Threading.Tasks;
using System.Collections.Generic;
using Shamsheer.Service.DTOs.Channels;

namespace Shamsheer.Service.Interfaces.Channels;
public interface IChannelService
{
    Task<bool> RemoveAsync(long id);
    Task<ChannelForResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<ChannelForResultDto>> RetrieveAllAsync();
    public Task<ChannelForResultDto> ModifyTitleAsync(string title);
    Task<ChannelForResultDto> AddAsync(ChannelForCreationDto dto);
    public Task<ChannelForResultDto> ModifyUsernameAsync(string username);
    Task<ChannelForResultDto> ModifyAsync(long id, ChannelForUpdateDto dto);
    public Task<ChannelForResultDto> ModifyDescriptionAsync(string description);
}