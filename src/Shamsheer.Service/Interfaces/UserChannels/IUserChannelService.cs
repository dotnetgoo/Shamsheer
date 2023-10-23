using System.Threading.Tasks;
using System.Collections.Generic;
using Shamsheer.Service.DTOs.UserChannels;

namespace Shamsheer.Service.Interfaces.UserChannel;
public interface IUserChannelService
{
    Task<bool> RemoveAsync(long id);
    Task<UserChannelForResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<UserChannelForResultDto>> RetrieveAllAsync();
    Task<UserChannelForResultDto> CreateAsync(UserChannelForCreationDto dto);
    Task<UserChannelForResultDto> ModifyAsync(long id, UserChannelForUpdateDto dto);
}
