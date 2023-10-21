using System.Threading.Tasks;
using System.Collections.Generic;
using Shamsheer.Service.DTOs.Channels;

namespace Shamsheer.Service.Interfaces.Channels;
public interface IChannelService
{
    Task<bool> RemoveAsync(long id);
    Task<ChannelForResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<ChannelForResultDto>> RetrieveAllAsync();
    Task<ChannelForResultDto> AddAsync(ChannelForCreationDto dto);
    Task<ChannelForResultDto> ModifyAsync(long id, ChannelForUpdateDto dto);
}