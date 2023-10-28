using System.Threading.Tasks;
using System.Collections.Generic;
using Shamsheer.Service.DTOs.UserChannels;
using Shamsheer.Service.Configurations;

namespace Shamsheer.Service.Interfaces.UserChannel;
public interface IUserChannelService
{
    Task<bool> RemoveAsync(long id);
    Task<UserChannelForResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<UserChannelForResultDto>> RetrieveAllAsync(PaginationParams @params);
    Task<UserChannelForResultDto> CreateAsync(UserChannelForCreationDto dto);
    Task<UserChannelForResultDto> ModifyAsync(long id, UserChannelForUpdateDto dto);
}
