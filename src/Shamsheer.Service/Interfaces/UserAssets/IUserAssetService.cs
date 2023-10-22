using System.Threading.Tasks;
using System.Collections.Generic;
using Shamsheer.Service.DTOs.UserAssets;

namespace Shamsheer.Service.Interfaces.UserAssets;

public interface IUserAssetService
{
    public Task<bool> RemoveAsync(long id);
    public Task<UserAssetForResultDto> RetrieveByIdAsync(long userId, long id);
    public Task<UserAssetForResultDto> CreateAsync(UserAssetForCreationDto dto);
    public Task<IEnumerable<UserAssetForResultDto>> RetrieveAllAsync(long userId);
}