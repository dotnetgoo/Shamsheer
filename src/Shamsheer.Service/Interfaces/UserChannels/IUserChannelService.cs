using System.Threading.Tasks;
using System.Collections.Generic;
using Shamsheer.Service.DTOs.UserChannels;

namespace Shamsheer.Service.Interfaces.UserChannel;
public interface IUserChannelService
{
    public Task<bool> RemoveAsync(long id);
    public Task<UserChannelForResultDto> RetrieveByIdAsync(long id);
    public Task<IEnumerable<UserChannelForResultDto>> RetrieveAllAsync();
    public Task<UserChannelForResultDto> AddAsync(UserChannelForCreationDto dto);
    public Task<UserChannelForResultDto> ModifyAsync(long id, UserChannelForUpdateDto dto);
}
